﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : Controller
    {
        IRentalService _rentalManager;

        public RentalsController(IRentalService rentalManager)
        {
            _rentalManager = rentalManager;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_rentalManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result=_rentalManager.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalManager.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalManager.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllRentalDetails")]
        public IActionResult GetAllRentalDetails()
        {
            var result = _rentalManager.GetAllRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserental")]
        public IActionResult Get(int UserId)
        {
            var result = _rentalManager.GetUserRental(UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("isrentable")]
        public IActionResult IsRentable(DateTime rentDate, DateTime returnDate, int carId)
        {
            var result = _rentalManager.IsRentable(rentDate, returnDate, carId);
            return Ok(result);
        }
        [HttpPost("CheckRentableAndRental")]
        public IActionResult CheckRentableAndRental(Rental rental)
        {
            var result = _rentalManager.CheckRentableAndRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
