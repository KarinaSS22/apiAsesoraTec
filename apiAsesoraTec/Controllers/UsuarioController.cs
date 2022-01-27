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
    public class UsuarioController : ControllerBase
    {

        private readonly AppDbContext context;
        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<string> Get() { 
            try
            {
                return Ok(context.Usuario.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<UsuarioController>/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public ActionResult Get(int id)
        {
            try
            {
                var Usuario = context.Usuario.FirstOrDefault(u => u.idUsuario == id);
                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuarios usuario)
        {
            try
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return CreatedAtRoute("GeUsuario", new { id = usuario.idUsuario}, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                if (usuario.idUsuario == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUsuario", new { id = usuario.idUsuario }, usuario);
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

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.idUsuario == id);
                if (usuario != null)
                {
                    context.Usuario.Remove(usuario);
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
