namespace Moonpig.PostOffice.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using Moonpig.PostOffice.Api.Services.Contracts;

    [Route("api/[controller]")]
    public class DespatchDateController : Controller
    {

        private readonly IDespatchService _despatchService;

        public DespatchDateController(IDespatchService despatchService)
        {
            _despatchService = despatchService;
        }

        public DateTime _mlt;

        [HttpGet]
        public ActionResult<DespatchDate> Get(int productId, DateTime orderDate)
        {
            try
            {
                DespatchDate result = _despatchService.GetDespatchDate(productId, orderDate);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Falha: {ex.Message}");
            }
        }

        //[HttpGet]
        //public DespatchDate Get(List<int> productIds, DateTime orderDate)
        //{
        //    _mlt = orderDate; // max lead time
        //    foreach (var ID in productIds)
        //    {
        //        DbContext dbContext = new DbContext();
        //        var s = dbContext.Products.Single(x => x.ProductId == ID).SupplierId;
        //        var lt = dbContext.Suppliers.Single(x => x.SupplierId == s).LeadTime;
        //        if (orderDate.AddDays(lt) > _mlt)
        //            _mlt = orderDate.AddDays(lt);
        //    }
        //    if (_mlt.DayOfWeek == DayOfWeek.Saturday)
        //    {
        //        return new DespatchDate { Date = _mlt.AddDays(2) };
        //    }
        //    else if (_mlt.DayOfWeek == DayOfWeek.Sunday) return new DespatchDate { Date = _mlt.AddDays(1) };
        //    else return new DespatchDate { Date = _mlt };
        //}
    }
}
