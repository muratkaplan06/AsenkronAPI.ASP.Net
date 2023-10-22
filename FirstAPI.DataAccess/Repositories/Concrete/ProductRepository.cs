using FirstAPI.DataAccess.Entity;
using FirstAPI.DataAccess.Repositories.Abstract;

namespace FirstAPI.DataAccess.Repositories.Concrete
{
    public class ProductRepository : GenericRepository<Product,ShopContext>,IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}
