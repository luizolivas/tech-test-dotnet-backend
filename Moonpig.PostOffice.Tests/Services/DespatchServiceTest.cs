using System;
using Moonpig.PostOffice.Api.Model;
using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Api.Services;
using Moonpig.PostOffice.Api.Services.Contracts;
using Moonpig.PostOffice.Data;
using Moq;
using Xunit;

namespace Moonpig.PostOffice.Tests.Services
{
    public class DespatchServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ISupplierRepository> _supplierRepositoryMock;
        private readonly IDespatchService _despatchService;

        public DespatchServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _supplierRepositoryMock = new Mock<ISupplierRepository>();
            _despatchService = new DespatchService(_supplierRepositoryMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnDayAfterWeekend()
        {
            
            DateTime dateSaturday = new DateTime(2024, 10, 26);
            DateTime dateSunday = new DateTime(2024, 10, 27);
            DateTime expectedDate = new DateTime(2024, 10, 28);

            
            DateTime resultSaturday = _despatchService.AdjustDateForWeekend(dateSaturday);
            DateTime resultSunday = _despatchService.AdjustDateForWeekend(dateSunday);

            
            Assert.Equal(expectedDate, resultSaturday);
            Assert.Equal(expectedDate, resultSunday);
        }

        [Fact]
        public void ShouldAddLeadTimeAndWeekend()
        {
            
            int leadTime = 1;
            DateTime startDate = new DateTime(2024, 10, 28);
            DateTime expectedDate = new DateTime(2024, 10, 29);

            
            DateTime resultDate = _despatchService.ProcessDate(startDate, leadTime);

           
            Assert.Equal(expectedDate, resultDate);
        }

        [Fact]
        public void ShouldReturnSupplierById()
        {
            int id = 2;
            var expectedSupplier = new Supplier { SupplierId = id, Name = "Supplier Test" };

            _supplierRepositoryMock.Setup(repo => repo.GetSupplier(id)).Returns(expectedSupplier);
            
            var result = _supplierRepositoryMock.Object.GetSupplier(id);
            
            Assert.Equal(expectedSupplier, result);
            Assert.Equal(id, result.SupplierId);
            Assert.Equal("Supplier Test", result.Name);
        }

        [Fact]
        public void ShouldReturnSuppilerIdByProduct()
        {
            int id = 3;
            
            var prod = new Product { ProductId = 1, Name = "Product Teste", SupplierId = id };

            _productRepositoryMock.Setup(repo => repo.GetProductById(id)).Returns(prod);

            int result = _despatchService.GetIdSupplierByProduct(id);
            Assert.Equal(id, result);
        }

        [Fact]
        public void ShouldReturnDespatchDate()
        {

            int idSup = 2;
            var expectedSupplier = new Supplier { SupplierId = idSup, Name = "Supplier Test", LeadTime = 2 };
            _supplierRepositoryMock.Setup(repo => repo.GetSupplier(idSup)).Returns(expectedSupplier);

            int idProd = 1;
            var prod = new Product { ProductId = 1, Name = "Product Teste", SupplierId = idSup };
            _productRepositoryMock.Setup(repo => repo.GetProductById(idProd)).Returns(prod);

            DateTime dtOrder = new DateTime(2024, 10, 28);
            DateTime dtExpected = new DateTime(2024, 10, 30);

            DespatchDate dtResult = _despatchService.GetDespatchDate(idProd, dtOrder);

            Assert.NotNull(dtResult);
            Assert.Equal(dtExpected, dtResult.Date);
        }

    }
}
