using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Data;

namespace Moonpig.PostOffice.Api.Repositories
{
    public class DespatchRepository : IDespatchRepository
    {
        private readonly IDbContext _context;
    }
}
