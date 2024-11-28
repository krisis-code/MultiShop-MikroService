using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {

        Task<List<ResultProductImageDto>> GetProductImagesAsync();
         
        Task CreateProductImage(CreateProductImageDto productImageDto);

        Task UpdateProductImageAsync(UpdateProductImageDto productImageDto);

        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);



    }
}
