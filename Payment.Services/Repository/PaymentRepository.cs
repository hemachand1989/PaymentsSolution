using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Payment.Services.Data;
using Payment.Services.Models;

namespace Payment.Services.Repository
{
    public class PaymentRepository : BaseRepository<Models.Payment>, IPaymentRepository
    {
        private readonly ILogger _logger;
        public PaymentRepository(PaymentDBContext dbContext,ILogger<PaymentRepository> logger) : base(dbContext,logger)
        {
            _logger = logger;
        }
        public override bool Insert(Models.Payment newItem)
        {
            newItem.CreatedDate = DateTime.Now;
            newItem.UpdatedDate = DateTime.Now;
            return base.Insert(newItem);
        }

        public override bool Update(Models.Payment Item)
        {
            Item.UpdatedDate = DateTime.Now;
            return base.Update(Item);
        }

        
    }
}
