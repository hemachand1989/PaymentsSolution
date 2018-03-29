using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Services.Data
{
    public class DBInitializer
    {
        public static void Initialize(PaymentDBContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Payments.Any())
            //{
            //    return;
            //}
        }
    }
}
