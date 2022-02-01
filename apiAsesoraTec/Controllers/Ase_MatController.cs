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
    public class Ase_MatController : ControllerBase
    {

        private readonly AppDbContext context;

        public Ase_MatController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<Ase_MatController>
        public ActionResult<string> Get()
        {
            try
            {
                var aseMat = (from Ase_Mat in context.aseMat
                                join Asesor in context.asesor on Ase_Mat.idAsesor equals Asesor.idAsesor
                                join Materia in context.materia on Ase_Mat.idMateria equals Materia.idMateria
                                join Departamento in context.departamento on Ase_Mat.idDepartamento equals Departamento.idDepartamento
                              select new
                                {
                                    Ase_Mat.idAseMat,
                                    Ase_Mat.idAsesor,
                                    Asesor.numReloj,
                                    Asesor.nombre,
                                    Asesor.apellidoPat,
                                    Asesor.apellidoMat,
                                    Asesor.informacion,
                                    Asesor.idTitulo,
                                    Asesor.idSexo,
                                    Asesor.idUsuario,
                                    Ase_Mat.idMateria,
                                    Materia.claveMat,
                                    Materia.idNombreMat,
                                    Materia.idCreditos,
                                    Ase_Mat.idDepartamento,
                                    Departamento.departamento
                                }).ToList();
                return Ok(aseMat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Ase_MatController>/5
        [HttpGet("{id}", Name = "GetAseMat")]
        public ActionResult Get(int id)
        {
            try
            {
                var aseMat = context.aseMat.FirstOrDefault(aM => aM.idAseMat == id);
                return Ok(aseMat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Ase_MatController>
        [HttpPost]
        public ActionResult Post([FromBody] Ase_Mat aseMat)
        {
            try
            {
                context.aseMat.Add(aseMat);
                context.SaveChanges();
                return CreatedAtRoute("GetAseMat", new { id = aseMat.idAseMat }, aseMat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Ase_MatController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ase_Mat aseMat)
        {
            try
            {
                if (aseMat.idAseMat == id)
                {
                    context.Entry(aseMat).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAseMat", new { id = aseMat.idAseMat }, aseMat);
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

        // DELETE api/<Ase_MatController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var aseMat = context.aseMat.FirstOrDefault(aM => aM.idAseMat == id);
                if (aseMat != null)
                {
                    context.aseMat.Remove(aseMat);
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
