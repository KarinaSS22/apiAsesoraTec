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
    public class Ase_CarreController : ControllerBase
    {
        private readonly AppDbContext context;

        public Ase_CarreController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Ase_CarreController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var aseCarre = (from Ase_Carre in context.aseCarre
                              join Asesor in context.asesor on Ase_Carre.idAsesor equals Asesor.idAsesor
                              join Carrera in context.carrera on Ase_Carre.idCarrera equals Carrera.idCarrera
                              select new
                              {
                                  Ase_Carre.idAseCarre,
                                  Ase_Carre.idAsesor,
                                  Asesor.numReloj,
                                  Asesor.nombre,
                                  Asesor.apellidoPat,
                                  Asesor.apellidoMat,
                                  Asesor.informacion,
                                  Asesor.idTitulo,
                                  Asesor.idSexo,
                                  Asesor.idUsuario,
                                  Ase_Carre.idCarrera,
                                  Carrera.claveCarrera,
                                  NombreCarre = Carrera.nombre,
                                  AbreviaturaCarre = Carrera.abreviatura,
                              }).ToList();
                return Ok(aseCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<Ase_CarreController>/5
        [HttpGet("{id}", Name = "GetAseCarre")]
        public ActionResult Get(int id)
        {
            try
            {
                var aseCarre = context.aseCarre.FirstOrDefault(aC => aC.idAseCarre == id);
                return Ok(aseCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Ase_CarreController>
        [HttpPost]
        public ActionResult Post([FromBody] Ase_Carre aseCarre)
        {
            try
            {
                context.aseCarre.Add(aseCarre);
                context.SaveChanges();
                return CreatedAtRoute("GetAseCarre", new { id = aseCarre.idAseCarre }, aseCarre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Ase_CarreController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ase_Carre aseCarre)
        {
            try
            {
                if (aseCarre.idAseCarre == id)
                {
                    context.Entry(aseCarre).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAseCarre", new { id = aseCarre.idAseCarre }, aseCarre);
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

        // DELETE api/<Ase_CarreController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var aseCarre = context.aseCarre.FirstOrDefault(aC => aC.idAseCarre == id);
                if (aseCarre != null)
                {
                    context.aseCarre.Remove(aseCarre);
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
