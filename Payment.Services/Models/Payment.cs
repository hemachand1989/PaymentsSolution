using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Services.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BSB { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public enum PaymentStatus
    {
        Initiated,
        Processing,
        Cancelled,
        Completed
    }
}
