using apiAsesoraTec.Context;
using apiAsesoraTec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiAsesoraTec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {

        private readonly AppDbContext context;
        public CarreraController (AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CarreraController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.carrera.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CarreraController>/5
        [HttpGet("{id}", Name = "GetCarrera")]
        public ActionResult Get(int id)
        {
            try
            {
                var carrera = context.carrera.FirstOrDefault(c => c.idCarrera == id);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CarreraController>
        [HttpPost]
        public ActionResult Post([FromBody] Carrera carrera)
        {
            try
            {
                context.carrera.Add(carrera);
                context.SaveChanges();
                return CreatedAtRoute("GetCarrera", new { id = carrera.idCarrera }, carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarreraController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carrera carrera)
        {
            try
            {
                if (carrera.idCarrera == id)
                {
                    context.Entry(carrera).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCarrera", new { id = carrera.idCarrera }, carrera);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<CarreraController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var carrera = context.carrera.FirstOrDefault(c => c.idCarrera == id);
                if (carrera != null)
                {
                    context.carrera.Remove(carrera);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
