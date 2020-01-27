using System;
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
    [Route("Intake")]
    public class IntakeController : BaseController
    {
        public IIntakeRepository _intake;
        public IntakeController(IIntakeRepository intake ,DatabaseContext context, IMapper mapper) : base(context, mapper) 
            => _intake = intake;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Intakes.Select(c=>_mapper.Map(c,new IntakeBaseViewModel())));

        [HttpGet("{id}")]
        public IntakeWithAllIncludes Get(Guid id)
        {
            var intake =  _intake.FindWithIncludes(c => c.Id == id).FirstOrDefault();
            return _mapper.Map(intake, new IntakeWithAllIncludes());
        }

        [HttpPost]
        public IntakeBaseViewModel Post([FromBody] IntakeRequest request)
        {
            var intake = _mapper.Map(request, new Intake());
            _context.Add(intake);
            _context.SaveChanges();
            return _mapper.Map(intake, new IntakeBaseViewModel());
        }

        [HttpPut]
        public IntakeWithAllIncludes Put([FromBody] IntakeUpdateRequest request)
        {
            var intake = _context.Intakes.Find(request.Id);
            _context.Update(intake);
            _context.SaveChanges();
            return _mapper.Map(_intake.FindWithIncludes(c => c.Id == intake.Id).First(), new IntakeWithAllIncludes());
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _context.Remove(_context.Intakes.Find(id));
            return Ok();
        }
    }
}