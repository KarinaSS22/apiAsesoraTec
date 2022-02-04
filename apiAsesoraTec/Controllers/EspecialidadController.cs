using apiAsesoraTec.Context;
using apiAsesoraTec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiAsesoraTec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {

        private readonly AppDbContext context;

        public EspecialidadController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EspecialidadController>
        [HttpGet]
        public ActionResult<string> Get() { 
            try
            {
                var especialidad = (from Especialidad in context.especialidad
                                     join NombreEspe in context.nombreEspe on Especialidad.idNombreEspe equals NombreEspe.idNombreEspe
                                     join Carrera in context.carrera on Especialidad.idCarrera equals Carrera.idCarrera
                                    select new
                                     {
                                        Especialidad.idEspecialidad,
                                        Especialidad.claveEspe,
                                        Especialidad.idNombreEspe,
                                        NombreEspe.nombre,
                                        Especialidad.idCarrera,
                                        Carrera.claveCarre,
                                        //Carrera.nombre,-->Corregir el nombre de variable
                                        Carrera.abreviatura
                                     }).ToList();
                return Ok(especialidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<EspecialidadController>/5
        [HttpGet("{id}", Name = "GetEspecialidad")]
        public ActionResult Get(int id)
        {
            try
            {
                var especialidad = context.especialidad.FirstOrDefault(e => e.idEspecialidad == id);
                return Ok(especialidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<EspecialidadController>
        [HttpPost]
        public ActionResult Post([FromBody] Especialidad especialidad)
        {
            try
            {
                context.especialidad.Add(especialidad);
                context.SaveChanges();
                return CreatedAtRoute("GetEspecialidad", new { id = especialidad.idEspecialidad}, especialidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EspecialidadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            try
            {
                if (especialidad.idEspecialidad == id)
                {
                    context.Entry(especialidad).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEspecialidad", new { id = especialidad.idEspecialidad }, especialidad);
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

        // DELETE api/<EspecialidadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var especilidad = context.especialidad.FirstOrDefault(e => e.idEspecialidad == id);
                if (especilidad != null)
                {
                    context.especialidad.Remove(especilidad);
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
