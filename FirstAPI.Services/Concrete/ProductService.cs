
using AutoMapper;
using FirstAPI.DataAccess.Entity;
using FirstAPI.DataAccess.Repositories.Abstract;
using FirstAPI.Services.Abstract;
using FirstAPI.Services.Models;

namespace FirstAPI.Services.concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var productList = await _productRepository.GetAll();
            var productModelList = _mapper.Map<List<ProductModel>>(productList);
            return productModelList;
        }

        public  ProductModel GetById(int id)
        {
            var product= _productRepository.GetById(id);
            var productModel = _mapper.Map<ProductModel>(product);
            return productModel;
        }

        public ProductModel Create(ProductModel product)
        {
            var productEntity=_mapper.Map<Product>(product);
            _productRepository.Add(productEntity);
           
             return product;
        }

        public ProductModel Update(int id, ProductModel product)
        {
            var productEntity=_mapper.Map<Product>(product);
             _productRepository.Update(id, productEntity);
             return product;
        }

        public Task Delete(int id)
        {
            _productRepository.Delete(id);
            return Task.CompletedTask;
        }

        public List<Product> DeleteMultible(int[] ids)
        {
            var products = new List<Product>();

            foreach (var id in ids)
            {

                var product = _productRepository.GetById(id);
                
                if (product != null)
                {
                    products.Add(product);
                }
                
            }
            _productRepository.DeleteMultible(products);
            return products;
        }

    }
}
