using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("Vendor")]
    public class VendorController : BaseController
    {
        private readonly IVendorRepository _vendor;
        public VendorController(DatabaseContext context,IVendorRepository vendor, IMapper mapper) : base(context, mapper)
        {
            _vendor = vendor;
        }

        [HttpGet("{id}")]
        public VendorWithAllIncludesViewModel Get(Guid id) =>
            _mapper.Map(_vendor.FindById(id), new VendorWithAllIncludesViewModel());

        [HttpGet]
        public ICollection<VendorBaseViewModel> Get() =>
            _vendor.GetAll().Select(c => _mapper.Map(c, new VendorBaseViewModel())).ToList();

        [HttpPost]
        public VendorWithAllIncludesViewModel Post(VendorWithAllIncludesRequest request)
        {
            var vendor = _mapper.Map(request, new Vendor());
            _vendor.Create(vendor);
            return _mapper.Map(vendor, new VendorWithAllIncludesViewModel());
        }

        [HttpPut]
        public VendorWithAllIncludesViewModel Put(VendorUpdateRequest request)
        {
            var vendor = _vendor.FindById(request.Id);
            _mapper.Map(request, vendor);
            _vendor.Update(vendor);
            return _mapper.Map(vendor, new VendorWithAllIncludesViewModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _vendor.Delete(_vendor.FindById(id));
            return Ok();
        }
    }
}