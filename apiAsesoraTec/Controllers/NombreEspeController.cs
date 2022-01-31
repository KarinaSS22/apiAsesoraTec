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
    public class NombreEspeController : ControllerBase
    {

        private readonly AppDbContext context;
        public NombreEspeController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<NombreEspeController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.nombreEspe.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<NombreEspeController>/5
        [HttpGet("{id}", Name = "GetNombreEspe")]
        public ActionResult Get(int id)
        {
            try
            {
                var nombreEspe = context.nombreEspe.FirstOrDefault(nE => nE.idNombreEspe == id);
                return Ok(nombreEspe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NombreEspeController>
        [HttpPost]
        public ActionResult Post([FromBody] NombreEspe nombreEspe)
        {
            try
            {
                context.nombreEspe.Add(nombreEspe);
                context.SaveChanges();
                return CreatedAtRoute("GetNombreEspe", new { id = nombreEspe.idNombreEspe }, nombreEspe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NombreEspeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NombreEspe nombreEspe)
        {
            try
            {
                if (nombreEspe.idNombreEspe == id)
                {
                    context.Entry(nombreEspe).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetNombreEspe", new { id = nombreEspe.idNombreEspe }, nombreEspe);
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

        // DELETE api/<NombreEspeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var nombreEspe = context.nombreEspe.FirstOrDefault(nE => nE.idNombreEspe == id);
                if (nombreEspe != null)
                {
                    context.nombreEspe.Remove(nombreEspe);
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
