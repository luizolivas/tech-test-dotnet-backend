using Microsoft.EntityFrameworkCore;
using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Moonpig.PostOffice.Api.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbContext _context;

        public SupplierRepository(IDbContext context)
        {
            _context = context;
        }

        public Supplier GetSupplierAsync(int idSup)
        {
            return  _context.Suppliers.SingleOrDefault(s => s.SupplierId == idSup);
        }
    }
}
