using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productColletion;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper , IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var databse = client.GetDatabase(_databaseSettings.DatabaseName);
            _productColletion = databse.GetCollection<ProductImage>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto productImageDto)
        {
            var value = _mapper.Map<ProductImage>(productImageDto);
            await _productColletion.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productColletion.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {   
            var value = await _productColletion.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task<List<ResultProductImageDto>> GetProductImagesAsync()
        {
           var values = await _productColletion.Find(x=> true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
        {
            var values = _mapper.Map<ProductImage>(productImageDto);
            await _productColletion.FindOneAndReplaceAsync(x => x.ProductId == productImageDto.ProductImageId, values);
        }
    }
}
