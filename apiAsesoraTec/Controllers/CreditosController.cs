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
    public class CreditosController : ControllerBase
    {

        private readonly AppDbContext context;
        public CreditosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CreditosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.creditos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CreditosController>/5
        [HttpGet("{id}", Name = "GetCreditos")]
        public ActionResult Get(int id)
        {
            try
            {
                var creditos = context.creditos.FirstOrDefault(c => c.idCreditos == id);
                return Ok(creditos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<CreditosController>
        [HttpPost]
        public ActionResult Post([FromBody] Creditos creditos)
        {
            try
            {
                context.creditos.Add(creditos);
                context.SaveChanges();
                return CreatedAtRoute("GetCreditos", new { id = creditos.idCreditos }, creditos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<CreditosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Creditos creditos)
        {
            try
            {
                if (creditos.idCreditos == id)
                {
                    context.Entry(creditos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCreditos", new { id = creditos.idCreditos }, creditos);
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


        // DELETE api/<CreditosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var creditos = context.creditos.FirstOrDefault(c => c.idCreditos == id);
                if (creditos != null)
                {
                    context.creditos.Remove(creditos);
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
