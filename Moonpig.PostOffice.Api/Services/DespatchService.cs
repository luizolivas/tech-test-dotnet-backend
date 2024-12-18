﻿using Moonpig.PostOffice.Api.Model;
using Moonpig.PostOffice.Api.Repositories.IRepository;
using Moonpig.PostOffice.Api.Services.Contracts;
using Moonpig.PostOffice.Data;
using System;
using System.Threading.Tasks;

namespace Moonpig.PostOffice.Api.Services
{
    public class DespatchService : IDespatchService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public DespatchService(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public DespatchDate GetDespatchDate(int idProduct, DateTime orderDate) 
        {
            int codSup = GetIdSupplierByProduct(idProduct);
            Supplier sup = GetSupplierById(codSup);

            DateTime mlt = ProcessDate(AdjustDateForWeekend(orderDate), sup.LeadTime);

            return new DespatchDate { Date = mlt };
        }

        public Supplier GetSupplierById(int id)
        {
            return _supplierRepository.GetSupplier(id);
        }

        public int GetIdSupplierByProduct(int productId)
        {
            Product prod = _productRepository.GetProductById(productId);

            if(prod == null)
            {
                throw new Exception("Produto não encontrado");
            }

            return prod.SupplierId;
        }

        public DateTime ProcessDate(DateTime orderDate, int leadTime)
        {
            DateTime dt = orderDate.AddDays(leadTime);
            return AdjustDateForWeekend(dt);
        }

        public DateTime AdjustDateForWeekend(DateTime date)
        {
            if(date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(1);
            }
            if(date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(2);
            }

            return date;
        }
    }
}
