using Moonpig.PostOffice.Api.Model;
using Moonpig.PostOffice.Data;
using System;
using System.Threading.Tasks;

namespace Moonpig.PostOffice.Api.Services.Contracts
{
    public interface IDespatchService
    {
        public DespatchDate GetDespatchDate(int idProduct, DateTime orderDate);
        public Supplier GetSupplierById(int id);
        public int GetIdSupplierByProduct(int productId);
        public DateTime ProcessDate(DateTime orderDate, int leadTime);
        public DateTime AdjustDateForWeekend(DateTime date);

    }
}
