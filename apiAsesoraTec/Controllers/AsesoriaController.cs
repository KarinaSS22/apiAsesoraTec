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
    public class AsesoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public AsesoriaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AsesoriaController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var asesoria = (from Asesoria in context.asesoria
                              join Alumno in context.alumno on Asesoria.idAlumno equals Alumno.idAlumno
                              join Asesor in context.asesor on Asesoria.idAsesor equals Asesor.idAsesor
                              join Calificacion in context.calificacion on Asesoria.idCalificacion equals Calificacion.idCalificacion
                              join ModoImpa in context.modoImpa on Asesoria.idModoImpa equals ModoImpa.idModoImpa
                              join Materia in context.materia on Asesoria.idMateria equals Materia.idMateria
                              select new
                              {
                                  Asesoria.idAsesoria,
                                  Asesoria.fechaImpa,
                                  Asesoria.fechaSoli,
                                  Asesoria.lugar,
                                  Asesoria.comentario,
                                  Asesoria.horaInicio,
                                  Asesoria.horaFin,
                                  Asesoria.tema,
                                  Asesoria.idAlumno,
                                  numControlAlu = Alumno.numControl,
                                  nombreAlu = Alumno.nombre,
                                  apePatAlu = Alumno.apellidoPat,
                                  apeMatAlu = Alumno.apellidoMat,
                                  idSexoAlu = Alumno.idSexo,
                                  idUsuAlu = Alumno.idUsuario,
                                  idCarreAlu = Alumno.idCarrera,
                                  idSemestreAlu = Alumno.idSemestre,
                                  idEspeAlu = Alumno.idEspecialidad,
                                  Asesoria.idAsesor,
                                  numRelojAse = Asesor.numReloj,
                                  nombreAse = Asesor.nombre,
                                  apePatAse = Asesor.apellidoPat,
                                  apeMatAse = Asesor.apellidoMat,
                                  infoAse = Asesor.informacion,
                                  idTitAse = Asesor.idTitulo,
                                  idSexoAse = Asesor.idSexo,
                                  idUsuAse = Asesor.idUsuario,
                                  Asesoria.idCalificacion,
                                  Calificacion.calificacion,
                                  Asesoria.idModoImpa,
                                  ModoImpa.modoImpa,
                                  Asesoria.idMateria,
                                  Materia.claveMat,
                                  Materia.idNombreMat,
                                  creditosMat=Materia.idCreditos
                              }).ToList();
                return Ok(asesoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AsesoriaController>/5
        [HttpGet("{id}", Name = "GetAsesoria")]
        public ActionResult Get(int id)
        {
            try
            {
                var asesoria = context.asesoria.FirstOrDefault(a => a.idAsesoria == id);
                return Ok(asesoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AsesoriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Asesoria asesoria)
        {
            try
            {
                context.asesoria.Add(asesoria);
                context.SaveChanges();
                return CreatedAtRoute("GetAsesoria", new { id = asesoria.idAsesoria }, asesoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AsesoriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Asesoria asesoria)
        {
            try
            {
                if (asesoria.idAsesoria == id)
                {
                    context.Entry(asesoria).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAsesoria", new { id = asesoria.idAsesoria }, asesoria);
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

        // DELETE api/<AsesoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var asesoria = context.asesoria.FirstOrDefault(a => a.idAsesoria == id);
                if (asesoria != null)
                {
                    context.asesoria.Remove(asesoria);
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
