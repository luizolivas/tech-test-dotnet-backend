using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Data;
using System.Linq;

namespace Moonpig.PostOffice.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == id);
        }
    }
}
