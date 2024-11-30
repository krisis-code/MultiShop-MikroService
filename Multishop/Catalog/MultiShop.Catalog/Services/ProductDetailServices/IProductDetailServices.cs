using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailServices
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();

        Task CreateProductDetailAsyc(CreateProductDetailDto createProductDetailDto);

        Task UpdateProductDetailAsyc(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsyc(string id);

        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
