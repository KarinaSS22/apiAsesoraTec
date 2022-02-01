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
    public class Mat_EspeController : ControllerBase
    {
        private readonly AppDbContext context;

        public Mat_EspeController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Mat_EspeController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var matEspe = (from Mat_Espe in context.matEspe
                                join Materia in context.materia on Mat_Espe.idMateria equals Materia.idMateria
                                join Especialidad in context.especialidad on Mat_Espe.idEspecialidad equals Especialidad.idEspecialidad
                                select new
                                {
                                    Mat_Espe.idMatEspe,
                                    Mat_Espe.claveInterna,
                                    Mat_Espe.idMateria,
                                    Materia.claveMat,
                                    Materia.idNombreMat,
                                    Materia.idCreditos,
                                    Mat_Espe.idEspecialidad,
                                    Especialidad.claveEspe,
                                    Especialidad.idNombreEspe,
                                    Especialidad.idCarrera
                                }).ToList();
                return Ok(matEspe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<Mat_EspeController>/5
        [HttpGet("{id}", Name = "GetMatEspe")]
        public ActionResult Get(int id)
        {
            try
            {
                var matEspe = context.matEspe.FirstOrDefault(mE => mE.idMatEspe == id);
                return Ok(matEspe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Mat_EspeController>
        [HttpPost]
        public ActionResult Post([FromBody] Mat_Espe matEspe)
        {
            try
            {
                context.matEspe.Add(matEspe);
                context.SaveChanges();
                return CreatedAtRoute("GetMatEspe", new { id = matEspe.idMatEspe }, matEspe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Mat_EspeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Mat_Espe matEspe)
        {
            try
            {
                if (matEspe.idMatEspe == id)
                {
                    context.Entry(matEspe).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMatEspe", new { id = matEspe.idMatEspe }, matEspe);
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

        // DELETE api/<Mat_EspeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var matEspe = context.matEspe.FirstOrDefault(mE => mE.idMatEspe == id);
                if (matEspe != null)
                {
                    context.matEspe.Remove(matEspe);
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
