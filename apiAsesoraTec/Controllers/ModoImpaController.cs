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
    public class ModoImpaController : ControllerBase
    {
        private readonly AppDbContext context;
        public ModoImpaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ModoImpaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.modoImpa.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ModoImpaController>/5
        [HttpGet("{id}", Name = "GetModoImpa")]
        public ActionResult Get(int id)
        {
            try
            {
                var modoImpa = context.modoImpa.FirstOrDefault(mI => mI.idModoImpa == id);
                return Ok(modoImpa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ModoImpaController>
        [HttpPost]
        public ActionResult Post([FromBody] ModoImpa modoImpa)
        {
            try
            {
                context.modoImpa.Add(modoImpa);
                context.SaveChanges();
                return CreatedAtRoute("GetModoImpa", new { id = modoImpa.idModoImpa }, modoImpa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ModoImpaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ModoImpa modoImpa)
        {
            try
            {
                if (modoImpa.idModoImpa == id)
                {
                    context.Entry(modoImpa).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetModoImpa", new { id = modoImpa.idModoImpa }, modoImpa);
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

        // DELETE api/<ModoImpaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var modoImpa = context.modoImpa.FirstOrDefault(mI => mI.idModoImpa == id);
                if (modoImpa != null)
                {
                    context.modoImpa.Remove(modoImpa);
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
