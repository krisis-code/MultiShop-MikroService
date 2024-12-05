using Dapper;
using Multishop.Discount.Context;
using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateDiscountCouponAsync(CreateCouponDto coupon)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", coupon.Code);
            parameters.Add("@rate", coupon.Rate);
            parameters.Add("@isActive", coupon.IsActive);
            parameters.Add("@validDate", coupon.ValidDate);

            using (var conection = _dapperContext.CreateConnection())
            { 
                await conection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

       

        public async Task<List<ResultCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values =    await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
              var values =   await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
                
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateCouponDto coupon)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", coupon.CouponId);
            parameters.Add("@code", coupon.Code);
            parameters.Add("@rate", coupon.Rate);
            parameters.Add("@isActive", coupon.IsActive);
            parameters.Add("@validDate", coupon.ValidDate);

            using (var conection = _dapperContext.CreateConnection())
            {
                await conection.ExecuteAsync(query, parameters);
            }
        }
    }
}
