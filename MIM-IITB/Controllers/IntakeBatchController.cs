using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("Intake-Batch")]
    public class IntakeBatchController : BaseController
    {
        private IIntakeBatchRepository _intakeBatch;
        public IntakeBatchController(IIntakeBatchRepository intakeBatchRepository,DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
            _intakeBatch = intakeBatchRepository;
        }

        [HttpGet]
        public IEnumerable<IntakeBatchBaseViewModel> Get()
        {
            return _context.IntakeBatches.Select(c => _mapper.Map(c, new IntakeBatchBaseViewModel())).ToList();
        }

        [HttpGet("{id}")]
        public IntakeBatchWithAllIncludeViewModel Get(Guid id)
        {
            var intakeBatch = _context.IntakeBatches.Include(c=>c.Intakes).Include(c=>c.Vendor).FirstOrDefault(c=>c.Id == id);
            return _mapper.Map(intakeBatch, new IntakeBatchWithAllIncludeViewModel());
        }

        [HttpPost]
        public IntakeBatchWithAllIncludeViewModel Post([FromBody] IntakeBatchRequest request)
        {
            var intakeBatch = _mapper.Map(request, new IntakeBatch());
            _intakeBatch.Create(intakeBatch);
            return _mapper.Map(intakeBatch, new IntakeBatchWithAllIncludeViewModel());
        }

        [HttpPut]
        public IntakeBatchWithAllIncludeViewModel Put([FromBody] IntakeBatchUpdateRequest request)
        {
            var intakeBatch = _intakeBatch.FindById(request.Id);
            _intakeBatch.Update(_mapper.Map(request, intakeBatch));
            return _mapper.Map(intakeBatch, new IntakeBatchWithAllIncludeViewModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _intakeBatch.Delete(_intakeBatch.FindById(id));
            return Ok();
        }
    }
}