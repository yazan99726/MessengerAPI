using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public void AddPayments(Payments payment)
        {
            paymentRepository.AddPayments(payment);
        }

        public void DeletePayments(int id)
        {
            paymentRepository.DeletePayments(id);
        }

        public IList<Payments> GetAllPayments()
        {
            return paymentRepository.GetAllPayments();
        }

        public Payments GetPaymentsById(int id)
        {
            return paymentRepository.GetPaymentsById(id);
        }

        public async Task<IList<Payments>> GetPaymentsByUserId(int userId)
        {
            return await paymentRepository.GetPaymentsByUserId(userId);
        }

        public void UpDatePayments(Payments payment)
        {
            paymentRepository.UpDatePayments(payment);
        }
        public List<GetPaymentsByName> GetPaymentsByDetails()
        {
            return paymentRepository.GetPaymentsByDetails();
        }
        public List<GetRevenue> GetRevenue()
        {
            return   paymentRepository.GetRevenue();
        }
        public List<GetRevenueByMonth> GetRevenueByMonth()
        {
            return paymentRepository.GetRevenueByMonth();
        }
    }
}
