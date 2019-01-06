using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Eksamen.Data;
using API_Eksamen.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Eksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UnitOfWork _unit;
        public ValuesController(UnitOfWork unit)
        {
            _unit = unit;
        }
        // GET api/values
        [HttpGet]
        [Route("GetAllValues")]
        public async Task<IActionResult> Get()
        {
           

          var values=  await _unit.TestObjects.GetAllAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _unit.TestObjects.GetAsync(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post([FromBody] TestObject testObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            testObject.Posted = DateTime.Now;
            await _unit.TestObjects.AddAsync(testObject);
             _unit.Complete();
            var value = await _unit.TestObjects.FindAsync(x => x.Text == testObject.Text && x.Posted == testObject.Posted);
            // return CreatedAtAction("GetById",new { id = value.Id },value);
            return Ok(value);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TestObject testObject)
        {
            if (id != testObject.Id)
            {
                return BadRequest();
            }
           await _unit.TestObjects.UpdateAsync(testObject);
             _unit.Complete();


            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _unit.TestObjects.GetAsync(id);
            if (value == null)
            {
                return NotFound();
            }
          await _unit.TestObjects.RemoveAsync(value);

            _unit.Complete();

            return NoContent();
        }
    }


}
