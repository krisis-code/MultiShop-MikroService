using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCoupons();
        
        Task CreateCoupon(ResultCouponDto coupon);

        Task UpdateCoupon(ResultCouponDto coupon);

        Task DeleteCoupon(int id);
        
        Task<GetByIdCouponDto> GetByIdCoupon(int id);
    }
}
