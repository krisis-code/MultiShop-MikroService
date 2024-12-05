using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllDiscountCouponsAsync();
        
        Task CreateDiscountCouponAsync(CreateCouponDto coupon);

        Task UpdateDiscountCouponAsync(UpdateCouponDto coupon);

        Task DeleteDiscountCouponAsync(int id);
        
        Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}
