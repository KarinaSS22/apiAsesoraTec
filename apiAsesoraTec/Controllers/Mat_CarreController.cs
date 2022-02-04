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
    public class Mat_CarreController : ControllerBase
    {
        private readonly AppDbContext context;

        public Mat_CarreController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Mat_CarreController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var matCarre = (from Mat_Carre in context.matCarre
                               join Materia in context.materia on Mat_Carre.idMateria equals Materia.idMateria
                               join Carrera in context.carrera on Mat_Carre.idCarrera equals Carrera.idCarrera
                               select new
                               {
                                   Mat_Carre.idMatCarre,
                                   Mat_Carre.claveInterna,
                                   Mat_Carre.idMateria,
                                   Materia.claveMat,
                                   Materia.idNombreMat,
                                   Materia.idCreditos,
                                   Mat_Carre.idCarrera,
                                   Carrera.claveCarre,
                                   NombreCarre = Carrera.nombre,
                                   AbreviaturaCarre = Carrera.abreviatura,
                               }).ToList();
                return Ok(matCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<Mat_CarreController>/5
        [HttpGet("{id}", Name = "GetMatCarre")]
        public ActionResult Get(int id)
        {
            try
            {
                var matCarre = context.matCarre.FirstOrDefault(mC => mC.idMatCarre == id);
                return Ok(matCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Mat_CarreController>
        [HttpPost]
        public ActionResult Post([FromBody] Mat_Carre matCarre)
        {
            try
            {
                context.matCarre.Add(matCarre);
                context.SaveChanges();
                return CreatedAtRoute("GetMatCarre", new { id = matCarre.idMatCarre }, matCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<Mat_CarreController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Mat_Carre matCarre)
        {
            try
            {
                if (matCarre.idMatCarre == id)
                {
                    context.Entry(matCarre).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMatCarre", new { id = matCarre.idMatCarre }, matCarre);
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

        // DELETE api/<Mat_CarreController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var matCarre = context.matCarre.FirstOrDefault(mC => mC.idMatCarre == id);
                if (matCarre != null)
                {
                    context.matCarre.Remove(matCarre);
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
