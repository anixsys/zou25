using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicationPaymentDto
    {
     public int applicationId { get; set; }
    public string? PaymentMethod { get; set; }

    public  int  CurrencyId { get; set; }
    public string? Phonenumber { get; set; }

    public string? receiptnumber { get; set;}

    public int? AdmissionFeeId { get; set; }
    }
}
