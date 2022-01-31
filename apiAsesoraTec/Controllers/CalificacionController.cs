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
    public class CalificacionController : ControllerBase
    {
        private readonly AppDbContext context;
        public CalificacionController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CalificacionController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.calificacion.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCalificacion")]
        public ActionResult Get(int id)
        {
            try
            {
                var calificacion = context.calificacion.FirstOrDefault(c => c.idCalificacion == id);
                return Ok(calificacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CalificacionController>
        [HttpPost]
        public ActionResult Post([FromBody] Calificacion calificacion)
        {
            try
            {
                context.calificacion.Add(calificacion);
                context.SaveChanges();
                return CreatedAtRoute("GetCalificacion", new { id = calificacion.idCalificacion }, calificacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CalificacionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Calificacion calificacion)
        {
            try
            {
                if (calificacion.idCalificacion == id)
                {
                    context.Entry(calificacion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCalificacion", new { id = calificacion.idCalificacion }, calificacion);
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

        // DELETE api/<CalificacionController>/5
        public ActionResult Delete(int id)
        {
            try
            {
                var calificacion = context.calificacion.FirstOrDefault(c => c.idCalificacion == id);
                if (calificacion != null)
                {
                    context.calificacion.Remove(calificacion);
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
