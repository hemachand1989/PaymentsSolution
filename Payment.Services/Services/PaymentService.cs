using Payment.Services.Models;
using Payment.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public bool CreatePayment(Models.Payment Item)
        {
           return  _paymentRepository.Insert(Item);
        }

        public bool DeletePayment(int Id)
        {
            return _paymentRepository.Delete(_paymentRepository.Single(Id));
        }

        public IEnumerable<Models.Payment> GetAllPayments()
        {
            return _paymentRepository.GetAll();
        }

        public Models.Payment GetPaymentInfo(int id)
        {
            return _paymentRepository.SingleOrDefault(id);
        }

        public bool UpdatePayment(Models.Payment Item)
        {
            return _paymentRepository.Update(Item);
        }
    }
}
