using Moonpig.PostOffice.Data;

namespace Moonpig.PostOffice.Api.Repositories.IRepository
{
    public interface IProductRepository
    {
        public Product GetProductById(int id);
    }
}
