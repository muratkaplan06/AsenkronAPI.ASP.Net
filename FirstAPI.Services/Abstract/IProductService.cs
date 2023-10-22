using FirstAPI.DataAccess.Entity;
using FirstAPI.Services.Models;

namespace FirstAPI.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
        ProductModel GetById(int id);
        ProductModel Create(ProductModel product);
        ProductModel Update(int id, ProductModel product);
        Task Delete(int id);
        List<Product> DeleteMultible(int[] ids);
    }
}
