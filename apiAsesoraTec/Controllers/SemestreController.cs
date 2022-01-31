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
    public class SemestreController : ControllerBase
    {

        private readonly AppDbContext context;

        public SemestreController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<SemestreController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.semestre.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SemestreController>/5
        [HttpGet("{id}", Name = "GetSemestre")]
        public ActionResult Get(int id)
        {
            try
            {
                var semestre = context.semestre.FirstOrDefault(s => s.idSemestre == id);
                return Ok(semestre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SemestreController>
        [HttpPost]
        public ActionResult Post([FromBody] Semestre semestre)
        {
            try
            {
                context.semestre.Add(semestre);
                context.SaveChanges();
                return CreatedAtRoute("GetSemestre", new { id = semestre.idSemestre }, semestre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SemestreController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Semestre semestre)
        {
            try
            {
                if (semestre.idSemestre == id)
                {
                    context.Entry(semestre).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSemestre", new { id = semestre.idSemestre }, semestre);
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
        // DELETE api/<SemestreController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var semestre = context.semestre.FirstOrDefault(s => s.idSemestre == id);
                if (semestre != null)
                {
                    context.semestre.Remove(semestre);
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
