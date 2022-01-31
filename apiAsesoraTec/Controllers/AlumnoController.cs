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
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext context;

        public AlumnoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var alumno = (from Alumno in context.alumno
                              join Usuario in context.usuario on Alumno.idUsuario equals Usuario.idUsuario
                              join Semestre in context.semestre on Alumno.idSemestre equals Semestre.idSemestre
                              join Carrera in context.carrera on Alumno.idCarrera equals Carrera.idCarrera
                              join Especialidad in context.especialidad on Alumno.idEspecialidad equals Especialidad.idEspecialidad
                              select new
                                    {
                                       Alumno.idAlumno,
                                       Alumno.numControl,
                                       Alumno.idUsuario,
                                       Usuario.nombre,
                                       Usuario.apellidoPat,
                                       Usuario.apellidoMat,
                                       Usuario.correo,
                                       Usuario.contrasenia,
                                       Usuario.foto,
                                       Usuario.idSexo,
                                       Alumno.idSemestre,
                                       Semestre.semestre,
                                       Alumno.idCarrera,
                                       //Carrera.nombre,
                                       Carrera.abreviatura,
                                       Alumno.idEspecialidad,
                                       Especialidad.idNombreEspe
                                    }).ToList();
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}", Name = "GetAlumno")]
        public ActionResult Get(int id)
        {
            try
            {
                var alumno = context.alumno.FirstOrDefault(a => a.idAlumno == id);
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<AlumnoController>
        [HttpPost]
        public ActionResult Post([FromBody] Alumno alumno)
        {
            try
            {
                context.alumno.Add(alumno);
                context.SaveChanges();
                return CreatedAtRoute("GetAlumno", new { id = alumno.idAlumno }, alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            try
            {
                if (alumno.idAlumno == id)
                {
                    context.Entry(alumno).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAlumno", new { id = alumno.idAlumno }, alumno);
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

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var alumno = context.alumno.FirstOrDefault(a => a.idAlumno == id);
                if (alumno != null)
                {
                    context.alumno.Remove(alumno);
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
