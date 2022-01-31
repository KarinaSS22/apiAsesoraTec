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
    public class AdministradorController : ControllerBase
    {
        private readonly AppDbContext context;
        public AdministradorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AdministradorController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var administrador = (from Administrador in context.administrador
                                     join Usuario in context.usuario on Administrador.idUsuario equals Usuario.idUsuario
                                     select new
                                     {
                                       Administrador.idAdministrador,
                                       Administrador.numEmpleado,
                                       Administrador.puesto,
                                       Administrador.idUsuario,
                                       Usuario.nombre,
                                       Usuario.apellidoPat,
                                       Usuario.apellidoMat,
                                       Usuario.correo,
                                       Usuario.contrasenia,
                                       Usuario.foto,
                                       Usuario.idSexo,
                                     }).ToList();
                return Ok(administrador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<AdministradorController>/5
        [HttpGet("{id}",Name ="GetAdministrador")]
        public ActionResult Get(int id)
        {
            try
            {
                var administrador = context.administrador.FirstOrDefault(a => a.idAdministrador == id);
                return Ok(administrador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdministradorController>
        [HttpPost]
        public ActionResult Post([FromBody] Administrador administrador)
        {
            try
            {
                context.administrador.Add(administrador);
                context.SaveChanges();
                return CreatedAtRoute("GetAdministrador", new { id = administrador.idAdministrador }, administrador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AdministradorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Administrador administrador)
        {
            try
            {
                if (administrador.idAdministrador == id)
                {
                    context.Entry(administrador).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAdministrador", new { id = administrador.idAdministrador }, administrador);
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

        // DELETE api/<AdministradorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var administrador = context.administrador.FirstOrDefault(a => a.idAdministrador == id);
                if (administrador != null)
                {
                    context.administrador.Remove(administrador);
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
