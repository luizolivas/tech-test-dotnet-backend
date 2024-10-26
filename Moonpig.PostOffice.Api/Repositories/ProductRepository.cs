using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Data;

namespace Moonpig.PostOffice.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }
    }
}
