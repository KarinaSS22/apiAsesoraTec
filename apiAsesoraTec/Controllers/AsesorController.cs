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
    public class AsesorController : ControllerBase
    {
        private readonly AppDbContext context;
        public AsesorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AsesorController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var asesor = (from Asesor in context.asesor
                                      join Titulo in context.titulo on Asesor.idTitulo equals Titulo.idTitulo
                                      join Sexo in context.sexo on Asesor.idSexo equals Sexo.idSexo
                                      join Usuario in context.usuario on Asesor.idUsuario equals Usuario.idUsuario
                                      select new
                                      {
                                          Asesor.idAsesor,
                                          Asesor.numReloj,
                                          Asesor.nombre,
                                          Asesor.apellidoPat,
                                          Asesor.apellidoMat,
                                          Asesor.informacion,
                                          Asesor.idTitulo,
                                          Titulo.titulo,
                                          Asesor.idSexo,
                                          Sexo.sexo,
                                          Asesor.idUsuario,
                                          Usuario.correo,
                                          Usuario.contrasenia,
                                          Usuario.foto
                                      }).ToList();
                return Ok(asesor);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                                 

        // GET api/<AsesorController>/5
        [HttpGet("{id}", Name ="GetAsesor")]
        public ActionResult Get(int id)
        {
            try
            {
                var Asesor = context.asesor.FirstOrDefault(a => a.idAsesor == id);
                return Ok(Asesor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AsesorController>
        [HttpPost]
        public ActionResult Post([FromBody] Asesor asesor)
        {
            try
            {
                context.asesor.Add(asesor);
                context.SaveChanges();
                return CreatedAtRoute("GetAsesor", new { id = asesor.idAsesor }, asesor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AsesorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Asesor asesor)
        {
            try
            {
                if (asesor.idAsesor == id)
                {
                    context.Entry(asesor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAsesor", new { id = asesor.idAsesor }, asesor);
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

        // DELETE api/<AsesorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var asesor = context.asesor.FirstOrDefault(a => a.idAsesor == id);
                if (asesor != null)
                {
                    context.asesor.Remove(asesor);
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
