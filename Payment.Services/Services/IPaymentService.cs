using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Services.Services
{
    public interface IPaymentService
    {
        IEnumerable<Models.Payment> GetAllPayments();

        Models.Payment GetPaymentInfo(int Id);

        bool CreatePayment(Models.Payment Item);

        bool UpdatePayment(Models.Payment Item);

        bool DeletePayment(int Id);
    }
}
