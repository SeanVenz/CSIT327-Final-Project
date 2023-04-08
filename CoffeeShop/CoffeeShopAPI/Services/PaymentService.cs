using AutoMapper;
using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Dtos.Payment;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDto> CreatePayment(PaymentCreationDto PaymentDto)
        {
            var paymentModel = _mapper.Map <Payment>(PaymentDto);
            paymentModel.Id = await _repository.CreatePayment(paymentModel);

            return _mapper.Map<PaymentDto>(paymentModel);
        }

        public async Task<bool> DeletePayment(int id)
        {
            return await _repository.DeletePayment(id);
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPayments()
        {
            var paymentModel =  await _repository.GetAllPayments();
            return _mapper.Map<IEnumerable<PaymentDto>>(paymentModel);
        }

        public async Task<PaymentDto?> GetPayment(int id)
        {
            var paymentModel = await _repository.GetPayment(id);
            if (paymentModel == null) return null;

            return _mapper.Map<PaymentDto>(paymentModel);
        }

        public async Task UpdatePayment(int paymentId, PaymentCreationDto paymentToUpdate)
        {
            var paymentModel = new Payment
            {
                Id = paymentId,
                Amount = paymentToUpdate.Amount,
                PaymentDate = paymentToUpdate.PaymentDate,
                OrdersId = paymentToUpdate.OrdersId
            };
            var payment = await _repository.UpdatePayment(paymentModel);
        }
    }
}
