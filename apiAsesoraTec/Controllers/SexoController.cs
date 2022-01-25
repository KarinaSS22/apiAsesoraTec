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
    public class SexoController : ControllerBase
    {

        private readonly AppDbContext context;
        public SexoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<SexoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Sexo.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SexoController>/5
        [HttpGet("{id}", Name = "GetSexo")]
        public ActionResult Get(int id)
        {
            try
            {
                var Sexo = context.Sexo.FirstOrDefault(s => s.idSexo == id);
                return Ok(Sexo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SexoController>
        [HttpPost]
        public ActionResult Post([FromBody] Sexo sexo)
        {
            try
            {
                context.Sexo.Add(sexo);
                context.SaveChanges();
                return CreatedAtRoute("GetSexo", new { id = sexo.idSexo }, sexo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SexoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sexo sexo)
        {
            try
            {
                if (sexo.idSexo == id)
                {
                    context.Entry(sexo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSexo", new { id = sexo.idSexo }, sexo);
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

        // DELETE api/<SexoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var sexo = context.Sexo.FirstOrDefault(s => s.idSexo == id);
                if (sexo != null)
                {
                    context.Sexo.Remove(sexo);
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
