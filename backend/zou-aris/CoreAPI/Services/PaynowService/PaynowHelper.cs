using CoreAPI.Dto;
using Webdev.Payments;

namespace CoreAPI.Services.PaynowService
{
    public class PaynowHelper : IPaynowHelper
    {
        private readonly IConfiguration _config;
        public PaynowHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<PaynowResponseDto> CheckPayment(string pollUrl)
        {
            var paynow = new Paynow(_config.GetSection("PAYNOW_INTERGRATION").Value, _config.GetSection("PAYNOW_KEY").Value);
            PaynowResponseDto response = new PaynowResponseDto();
            try
            {
                var status = paynow.PollTransaction(pollUrl);
                var data = status.GetData();
                var newstatus = data["status"];
                if (status.WasPaid || newstatus.ToLower() == "awaiting delivery")
                {
                    response.status = true;
                    response.response = "PAID";
                    response.message = "Transaction Successfully Setteled";

                }
                else
                {
                    response.status = false;
                    response.response = newstatus;
                    response.message = $"Transaction Not Setteled with status:  {newstatus}";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.response = "";
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<PaynowInitiationDto> InitiatePayment(string currency, string email, string phone, string method, int amount, string referencenumber)
        {
            var paynow = new Paynow(_config.GetSection("PAYNOW_INTERGRATION").Value, _config.GetSection("PAYNOW_KEY").Value);
            paynow.ResultUrl = _config.GetSection("RETURN_URL").Value + "/" + referencenumber;
            paynow.ReturnUrl = _config.GetSection("UPDATE_UPDATE").Value + "/" + referencenumber;

            var env = bool.Parse(_config.GetSection("DEV").Value);
            var checkemail = env ? "benson.misi@outlook.com" : email;
            var payment = paynow.CreatePayment(referencenumber, checkemail);
            payment.Add("APPLICATION", amount);
            PaynowInitiationDto responseDto = new PaynowInitiationDto();
            try
            {
                var response = paynow.SendMobile(payment, phone, method);
                if (response.Success())
                {
                    var pollurl = response.PollUrl();
                    responseDto.status = true;
                    responseDto.url = pollurl;
                    responseDto.message = "Payment successfull initiated awaiting client authorization";

                }
                else
                {

                    responseDto.status = false;
                    responseDto.message = response.GetData()["error"];
                }

            }
            catch (Exception ex)
            {

                responseDto.status = false;
                responseDto.url = "";
                responseDto.message = ex.Message;
            }

            return responseDto;
        }

        public async Task<PaynowInitiationDto> InitiateRegularPayment(string currency, string email, int amount, string referencenumber)
        {
            var intergration = currency == "USD" ? _config.GetSection("PAYNOW_INTERGRATION_USD").Value : _config.GetSection("PAYNOW_INTERGRATION").Value;
            var key = currency == "USD" ? _config.GetSection("PAYNOW_KEY_USD").Value : _config.GetSection("PAYNOW_KEY").Value;

            var paynow = new Paynow(intergration, key);
            paynow.ResultUrl = _config.GetSection("RETURN_URL").Value + "/" + referencenumber;
            paynow.ReturnUrl = _config.GetSection("UPDATE_UPDATE").Value + "/" + referencenumber;

            var env = bool.Parse(_config.GetSection("DEV").Value);
            var checkemail = env ? "benson.misi@outlook.com" : email;
            var payment = paynow.CreatePayment(referencenumber, checkemail);
            payment.Add(referencenumber, amount);
            PaynowInitiationDto responseDto = new PaynowInitiationDto();
            try
            {
                var response = paynow.Send(payment);
                if (response.Success())
                {
                    var pollurl = response.PollUrl();
                    var redirectlink = response.RedirectLink();
                    responseDto.status = true;
                    responseDto.url = pollurl;
                    responseDto.link = redirectlink;
                    responseDto.message = "Payment successfull initiated awaiting client authorization";

                }
                else
                {

                    responseDto.status = false;
                    responseDto.message = response.GetData()["error"];
                }

            }
            catch (Exception ex)
            {

                responseDto.status = false;
                responseDto.url = "";
                responseDto.message = ex.Message;
            }

            return responseDto;
        }
    }
}
