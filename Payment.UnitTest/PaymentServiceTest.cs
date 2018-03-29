using Moq;
using Payment.Services.Repository;
using Payment.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Payment.UnitTest
{
    public class PaymentServiceTest
    {
        public PaymentServiceTest()
        {

        }

        [Fact]
        public void ReturnFalseGivenEmptyPaymentModelForPost()
        {
            var paymentRepo = new Mock<IPaymentRepository>();
            paymentRepo.Setup(x => x.Insert(new Services.Models.Payment())).Returns(false);
            var _paymentService = new PaymentService(paymentRepo.Object);
            var result = _paymentService.CreatePayment(new Services.Models.Payment());
            Assert.False(result, "Payment Model Should not be Empty");
        }

        [Fact]
        public void ReturnTrueGivenValidPaymentModelForPost()
        {
            var paymentRepo = new Mock<IPaymentRepository>();
            var model = new Services.Models.Payment()
            {
                AccountName = "Sowmya",
                AccountNumber = "124123123213",
                Amount = 14331.11M,
                Reference = "Hem",
                BSB = "123-456",
            };
            paymentRepo.Setup(x => x.Insert(model)).Returns(true);
            var _paymentService = new PaymentService(paymentRepo.Object);
            var result = _paymentService.CreatePayment(model);
            Assert.True(result, "Payment Model Is Valid");
        }
        
        [Fact]
        public void ReturnEmptyListWhenNoDataForGet()
        {
            var paymentRepo = new Mock<IPaymentRepository>();
            paymentRepo.Setup(x => x.GetAll()).Returns((IEnumerable<Services.Models.Payment>)null);
            var _paymentService = new PaymentService(paymentRepo.Object);
            var result = _paymentService.GetAllPayments();
            Assert.True(result == null, "Payment Model Is Valid");
        }

        [Fact]
        public void ReturnTrueWhenUpdatingDataForPUT()
        {
            var paymentRepo = new Mock<IPaymentRepository>();
            var model = new Services.Models.Payment()
            {
                Id = 1,
                AccountName = "Hem",
                AccountNumber = "124123423213",
                Amount = 14331.11M,
                Reference = "sujan",
                BSB = "456-123",
            };
            paymentRepo.Setup(x => x.Update(model)).Returns(true);
            var _paymentService = new PaymentService(paymentRepo.Object);
            var result = _paymentService.UpdatePayment(model);
            Assert.True(result, "Update Payment Model Is Valid");
        }

        [Fact]
        public void ReturnFalseWhenDeletingFailed()
        {
            var paymentRepo = new Mock<IPaymentRepository>();
            var model = new Services.Models.Payment()
            {
                Id = 1,
                AccountName = "Hem",
                AccountNumber = "124123423213",
                Amount = 14331.11M,
                Reference = "sujan",
                BSB = "456-123",
            };
            paymentRepo.Setup(x => x.Delete(model)).Returns(false);
            var _paymentService = new PaymentService(paymentRepo.Object);
            var result = _paymentService.DeletePayment(model.Id);
            Assert.False(result, "Delete Payment Model Failed");
        }
    }
}
