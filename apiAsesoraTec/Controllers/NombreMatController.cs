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
    public class NombreMatController : ControllerBase
    {

        private readonly AppDbContext context;
        public NombreMatController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<NombreMatController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.nombreMat.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<NombreMatController>/5
        [HttpGet("{id}", Name = "GetNombreMat")]
        public ActionResult Get(int id)
        {
            try
            {
                var nombreMat = context.nombreMat.FirstOrDefault(nM => nM.idNombreMat == id);
                return Ok(nombreMat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<NombreMatController>
        [HttpPost]
        public ActionResult Post([FromBody] NombreMat nombreMat)
        {
            try
            {
                context.nombreMat.Add(nombreMat);
                context.SaveChanges();
                return CreatedAtRoute("GetNombreMat", new { id = nombreMat.idNombreMat }, nombreMat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NombreMatController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NombreMat nombreMat)
        {
            try
            {
                if (nombreMat.idNombreMat == id)
                {
                    context.Entry(nombreMat).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetNombreMat", new { id = nombreMat.idNombreMat }, nombreMat);
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

        // DELETE api/<NombreMatController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var nombreMat = context.nombreMat.FirstOrDefault(nM => nM.idNombreMat == id);
                if (nombreMat!= null)
                {
                    context.nombreMat.Remove(nombreMat);
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
