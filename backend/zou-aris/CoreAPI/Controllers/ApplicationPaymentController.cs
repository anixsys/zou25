using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services.PaynowService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webdev.Payments;

namespace Administration.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationPaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IPaynowHelper _paynow;
        public ApplicationPaymentController(IUnitOfWork unitofwork,IPaynowHelper paynow ,ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _paynow = paynow;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPayments(int id)
        {
            var response = _unitOfWork.applicationPaymentRepository.Find(q => q.applicationId == id).ToList();
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ApplicationPaymentDto dto)
        {
            var application = _unitOfWork.applicationRepository.GetOne(q => q.Id == dto.applicationId, new List<string>() { "applicant" });
            if (application == null)
            {
                _response.Status = false;
                _response.Message = "Application not found";
            }
            else
            {
                var checkpayments = _unitOfWork.applicationPaymentRepository.Find(q => q.applicationId == application.Id).OrderBy(q => q.Id).LastOrDefault();
                if (checkpayments != null)
                {
                    if (checkpayments.status == "PAID" || checkpayments.status == "AWAITING")
                    {
                        _response.Status = false;
                        _response.Message = "Application has payment attempts awaiting verification or already paid";
                       
                    }
                }


                var admissionfee = await _unitOfWork.admissionfeeRepository.getFee(application.ApplicanttypeId, application.ProgrammeTypeId, dto.CurrencyId);
                if (admissionfee == null)
                {
                    _response.Status = false;
                    _response.Message = "Application Fee not set please contact System Administrator";
                }
                else
                {
                    
                    if (dto.PaymentMethod == "ECOCASH" || dto.PaymentMethod == "ONEMONEY" || dto.PaymentMethod == "TELECASH")
                    {
                        var paynowresponse = await _paynow.InitiatePayment(admissionfee.Currency.Name, application.applicant.Email, dto.Phonenumber, dto.PaymentMethod, int.Parse(admissionfee.amount.ToString()), application.uuid);
                        if (paynowresponse.status)
                        {

                            ApplicationPayment applicationPayment = new ApplicationPayment();

                            applicationPayment.uuid = application.uuid;
                            applicationPayment.applicantId = application.applicantId;
                            applicationPayment.applicationId = application.Id;
                            applicationPayment.admissionsessionId = application.AdmissionSessionId;
                            applicationPayment.pollUrl = paynowresponse.url;
                            applicationPayment.currency = admissionfee.Currency.Name;
                            applicationPayment.amount = int.Parse(admissionfee.amount.ToString());
                            applicationPayment.status = "AWAITING";
                            applicationPayment.paymentmethod = dto.PaymentMethod;
                            _unitOfWork.applicationPaymentRepository.Add(applicationPayment);
                            var result = await _unitOfWork.Save();
                            if (result > 0)
                            {
                                _response.Status = true;
                                _response.Message = paynowresponse.message;

                            }
                            else
                            {
                                _response.Status = false;
                                _response.Message = "An error has ocurred";
                            }

                        }
                        else
                        {
                            _response.Status = false;
                            _response.Message = paynowresponse.message;
                        }
                    }
                    else if (dto.PaymentMethod == "VISA")
                    {
                        var paynowresponse = await _paynow.InitiateRegularPayment(admissionfee.Currency.Name, application.applicant.Email, int.Parse(admissionfee.amount.ToString()), application.uuid);
                        if (paynowresponse.status)
                        {
                            ApplicationPayment applicationPayment = new ApplicationPayment();

                            applicationPayment.uuid = application.uuid;
                            applicationPayment.applicantId = application.applicantId;
                            applicationPayment.applicationId = application.Id;
                            applicationPayment.admissionsessionId = application.AdmissionSessionId;
                            applicationPayment.pollUrl = paynowresponse.url;
                            applicationPayment.currency = admissionfee.Currency.Name;
                            applicationPayment.amount = int.Parse(admissionfee.amount.ToString());
                            applicationPayment.status = "AWAITING";
                            applicationPayment.paymentmethod = dto.PaymentMethod;
                            _unitOfWork.applicationPaymentRepository.Add(applicationPayment);
                            var result = await _unitOfWork.Save();
                            if (result > 0)
                            {
                                _response.Status = true;
                                _response.Message = paynowresponse.message;
                                _response.Data = paynowresponse.url;

                            }
                            else
                            {
                                _response.Status = false;
                                _response.Message = "An error has ocurred";
                            }
                        }
                    }
                    else
                    {
                        ApplicationPayment applicationPayment = new ApplicationPayment();

                        applicationPayment.uuid = application.uuid;
                        applicationPayment.applicantId = application.applicantId;
                        applicationPayment.applicationId = application.Id;
                        applicationPayment.admissionsessionId = application.AdmissionSessionId;
                        applicationPayment.pollUrl = "";
                        applicationPayment.currency = admissionfee.Currency.Name;
                        applicationPayment.amount = int.Parse(admissionfee.amount.ToString());
                        applicationPayment.status = "PAID";
                        applicationPayment.paymentmethod = dto.PaymentMethod;
                        applicationPayment.referencenumber = dto.receiptnumber;
                        _unitOfWork.applicationPaymentRepository.Add(applicationPayment);
                        var result = await _unitOfWork.Save();
                        if (result > 0)
                        {

                            if (application != null)
                            {
                                application.PaymentStatus = "PAID";
                                _unitOfWork.applicationRepository.Update(application);
                                await _unitOfWork.Save();
                                _response.Status = true;
                                _response.Message = "Application Successfully Paid";
                            }


                        }

                    }
                }

            }
            return Ok(_response);
        }

        [HttpGet("Check/{id:int}")]
        public async Task<ActionResult> CheckPayments(int id)
        {
            var payment = _unitOfWork.applicationPaymentRepository.GetOne(q => q.Id == id);
            if (payment == null)
            {
                _response.Status = false;
                _response.Message = "Payment not found";
            }
            else
            {
                var paynowresponse = await _paynow.CheckPayment(payment.pollUrl);
                if (paynowresponse.response != string.Empty)
                {
                    payment.status = paynowresponse.response;
                    _unitOfWork.applicationPaymentRepository.Update(payment);
                    await _unitOfWork.Save();
                    if (paynowresponse.status)
                    {
                        var application = _unitOfWork.applicationRepository.GetOne(q => q.Id == payment.applicationId);
                        if (application != null)
                        {
                            application.PaymentStatus = "PAID";
                            _unitOfWork.applicationRepository.Update(application);
                            await _unitOfWork.Save();
                            _response.Status = true;
                            _response.Message = paynowresponse.message;
                        }
                        else
                        {
                            _response.Status = false;
                            _response.Message = "Application Not Found";
                        }

                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = (string)paynowresponse.message;
                    }
                }

            }
            return Ok(_response);
        }

    }
}
