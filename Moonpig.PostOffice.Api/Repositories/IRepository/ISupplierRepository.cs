using Moonpig.PostOffice.Data;
using System.Threading.Tasks;

namespace Moonpig.PostOffice.Api.Repositories.IRepository
{
    public interface ISupplierRepository
    {
        public Supplier GetSupplierAsync(int idSup);
    }
}
