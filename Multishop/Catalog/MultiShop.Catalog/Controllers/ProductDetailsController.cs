using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;

        public ProductDetailsController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var valeus = await _productDetailServices.GetAllProductDetailsAsync();
            return Ok(valeus);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetail(string id)
        {

            var value = await _productDetailServices.GetByIdProductDetailAsync(id);
            return Ok(value);


        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailServices.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailServices.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdataProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailServices.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
