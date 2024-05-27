using System;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPIs.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly Calculator.ICalculator _calculator;

        public CalculatorController(Calculator.ICalculator calculator)
        {
            _calculator = calculator;
        }


        [HttpGet]
        [ApiVersion("1.0")]
        [Route("get")]
        public IActionResult GetStatus()
        {
            return Ok("We're all good");
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("add")]
        public IActionResult Add(CalculatorRequest request)
        {
            var result = _calculator.Add(request.First, request.Second);
            return Ok(result);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("subtract")]
        public IActionResult Subtract(CalculatorRequest request)
        {
            var result = _calculator.Subtract(request.First, request.Second);
            return Ok(result);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("multiply")]
        public IActionResult Multiply(CalculatorRequest request)
        {
            var result = _calculator.Multiply(request.First, request.Second);
            return Ok(result);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("divide")]
        public IActionResult Divide(CalculatorRequest request)
        {
            IActionResult response;
            try
            {
                var result = _calculator.Divide(request.First, request.Second);
                return Ok(result);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("mod")]
        public IActionResult Mod(CalculatorRequest request)
        {
            IActionResult response;
            try
            {
                var result = _calculator.Mod(request.First, request.Second);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex.Message);
            }

            return response;
        }


        [HttpPost]
        [ApiVersion("1.0")]
        [Route("foo")]
        public IActionResult Foo(CalculatorRequest request)
        {
            IActionResult response;
            try
            {
                var result = _calculator.Foo(request.Bar);
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = BadRequest(ex.Message);
            }

            return response;
        }
    }
}
