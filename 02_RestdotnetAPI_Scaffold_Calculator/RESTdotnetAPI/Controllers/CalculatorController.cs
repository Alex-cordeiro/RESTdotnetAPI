using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult soma(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("invalid input");
            
        }

        [HttpGet("sub/{sub1}/{sub2}")]
        public IActionResult subtracao(string sub1, string sub2)
        {
            if(IsNumeric(sub1) && IsNumeric(sub2))
            {
                var sub = ConvertToDecimal(sub1) - ConvertToDecimal(sub2);
                return Ok(sub.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("mult/{mult1}/{mult2}")]
        public IActionResult multiplicacao(string mult1, string mult2)
        {
            if (IsNumeric(mult1) && IsNumeric(mult2))
            {
                var mult = ConvertToDecimal(mult1) * ConvertToDecimal(mult2);
                return Ok(mult.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("div/{div1}/{div2}")]
        public IActionResult divisao(string div1, string div2)
        {
            if (IsNumeric(div1) && IsNumeric(div2))
            {
                var mult = ConvertToDecimal(div1) / ConvertToDecimal(div2);
                return Ok(mult.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }

            return BadRequest("invalid input");

        }

        [HttpGet("sqr/{firstNumber}")]
        public IActionResult RaizQuadrada(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("invalid input");

        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
