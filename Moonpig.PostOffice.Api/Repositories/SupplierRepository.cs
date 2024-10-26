using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Data;

namespace Moonpig.PostOffice.Api.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbContext _context;

        public SupplierRepository(IDbContext context)
        {
            _context = context;
        }
    }
}
