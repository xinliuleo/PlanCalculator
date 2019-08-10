using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanCalculator.Models;
using PlanCalculator.Services;

namespace PlanCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IMapper _mapper;
        public CalculatorController(ICalculator calculator, IMapper mapper)
        {
            _calculator = calculator;
            _mapper = mapper;
        }

        // GET api/calculator/
        [HttpGet]
        public IActionResult Get([FromQuery]PlanInputDto input)
        {
            PlanInput planInput = _mapper.Map<PlanInput>(input);
            var result = _calculator.CalculatePaymentPlan(planInput);
            if (result == null)
                return NotFound("Plans not offered");
            else
                return Ok(_mapper.Map<List<PlanOutputDto>>(result));
        }
    }
}