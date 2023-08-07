using CoreAPI.Dto;

namespace CoreAPI.Services.PaynowService
{
    public interface IPaynowHelper
    {
        Task<PaynowInitiationDto> InitiatePayment(string currency, string email, string phone, string method, int amount, string referencenumber);
        Task<PaynowInitiationDto> InitiateRegularPayment(string currency, string email, int amount, string referencenumber);
        Task<PaynowResponseDto> CheckPayment(string pollUrl);
    }
}
