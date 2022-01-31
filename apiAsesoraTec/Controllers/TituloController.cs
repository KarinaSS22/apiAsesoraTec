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
    public class TituloController : ControllerBase
    {

        private readonly AppDbContext context;
        public TituloController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<TituloController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.titulo.ToList());
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TituloController>/5
        [HttpGet("{id}", Name = "GetTitulo")]
        public ActionResult Get(int id)
        {
            try
            {
                var titulo = context.titulo.FirstOrDefault(t => t.idTitulo == id);
                return Ok(titulo);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TituloController>
        [HttpPost]
        public ActionResult Post([FromBody] Titulo titulo)
        {
            try
            {
                context.titulo.Add(titulo);
                context.SaveChanges();
                return CreatedAtRoute("GetTitulo", new { id = titulo.idTitulo }, titulo);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TituloController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Titulo titulo)
        {
            try
            {
                if (titulo.idTitulo == id)
                {
                    context.Entry(titulo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTitulo", new { id = titulo.idTitulo }, titulo);
                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TituloController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var titulo = context.titulo.FirstOrDefault(t => t.idTitulo == id);
                if (titulo != null)
                {
                    context.titulo.Remove(titulo);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest(); 
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
