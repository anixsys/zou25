using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class EmailQueue
    {
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public string Email { get; set; }=string.Empty;

        public string Url { get; set; }=string.Empty;


        public string Subject { get; set; } =string.Empty;

        public string BodyHtml { get; set; } = string.Empty;

        public string Status { get; set; } =string.Empty;
    }
}
