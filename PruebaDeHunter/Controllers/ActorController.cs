using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HunterMoviesData;
using Microsoft.EntityFrameworkCore;
namespace PruebaDeHunter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly DataBaseContext context;
        public ActorController(DataBaseContext context)
        {
            this.context = context;
            
        }
        // GET: api/<ActorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Actors.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}", Name = "GetActor")]
        public ActionResult Get(int id)
        {
            try
            {
                var actor = context.Actors.FirstOrDefault(f => f.ID == id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //Get Actors with Movies
        [HttpGet("{Nombre}", Name = "GetActorAndMovies")]
        public ActionResult Get(string Nombre)
        {
            try
            {
                return Ok(context.Actors.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // POST api/<ActorController>
        [HttpPost]
        public ActionResult Post([FromBody] Actors Actor)
        {
            try
            {

                context.Actors.Add(Actor);
                context.SaveChanges();
                return CreatedAtRoute("GetActor", new { id = Actor.ID }, Actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Actors Actor)
        {
            try
            {
                if (Actor.ID == id)
                {

                    context.Entry(Actor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetActor", new { id = Actor.ID }, Actor);
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

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                var actor = context.Actors.FirstOrDefault(f => f.ID == id);
                if (actor != null)
                {
                    context.Actors.Remove(actor);
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
