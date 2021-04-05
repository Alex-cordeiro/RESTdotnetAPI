﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTdotnetAPI.Model;
using RESTdotnetAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
  
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            
            if (person == null) return BadRequest("Deu ruim aqui fera");

            return Ok(_personService.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return NoContent();
        }
    }
}