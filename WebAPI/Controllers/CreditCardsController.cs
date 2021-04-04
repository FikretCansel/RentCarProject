using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CreditCardsController : Controller
        {
            ICreditCardService _creditCardService;

            public CreditCardsController(ICreditCardService creditCardService)
            {
                _creditCardService = creditCardService;
            }

        [HttpGet("getbyuserid")]
        public IActionResult GetAll(int userId)
        {
            var result = _creditCardService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _creditCardService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            [HttpPost("add")]
            public IActionResult Add(CreditCard creditCard)
            {
                var result = _creditCardService.Add(creditCard);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            [HttpDelete("delete")]
            public IActionResult Delete(CreditCard creditCard)
            {
                var result = _creditCardService.Delete(creditCard);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            [HttpPut("update")]
            public IActionResult Update(CreditCard creditCard)
            {
                var result = _creditCardService.Update(creditCard);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
    }
