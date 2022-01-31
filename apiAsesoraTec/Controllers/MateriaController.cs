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
    public class MateriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public MateriaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MateriaController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var materia = (from Materia in context.materia
                                     join NombreMat in context.nombreMat on Materia.idNombreMat equals NombreMat.idNombreMat
                                     join Creditos in context.creditos on Materia.idCreditos equals Creditos.idCreditos
                               select new
                                     {
                                        Materia.idMateria,
                                        Materia.claveMat,
                                        Materia.idNombreMat,
                                        NombreMat.nombre,
                                        Materia.idCreditos,
                                        Creditos.creditos                         
                                     }).ToList();
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MateriaController>/5
        [HttpGet("{id}", Name = "GetMateria")]
        public ActionResult Get(int id)
        {
            try
            {
                var materia = context.materia.FirstOrDefault(m => m.idMateria == id);
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MateriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Materia materia)
        {
            try
            {
                context.materia.Add(materia);
                context.SaveChanges();
                return CreatedAtRoute("GeMateria", new { id = materia.idMateria }, materia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MateriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Materia materia)
        {
            try
            {
                if (materia.idMateria == id)
                {
                    context.Entry(materia).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMateria", new { id = materia.idMateria }, materia);
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

        // DELETE api/<MateriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var materia = context.materia.FirstOrDefault(m => m.idMateria == id);
                if (materia != null)
                {
                    context.materia.Remove(materia);
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
