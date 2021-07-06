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
    public class MoviesController : ControllerBase
    {
        private readonly DataBaseContext context;
        public MoviesController(DataBaseContext context)
        {
            this.context = context;

        }
        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Movies.Where(x=> x.ID == 1).Include(x=> x.Gender).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}", Name = "GetMovies")]
        public ActionResult Get(int id)
        {
            try
            {
                var actor = context.Movies.FirstOrDefault(f => f.ID == id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult Post([FromBody] Movies movies)
        {
            try
            {

                context.Movies.Add(movies);
                context.SaveChanges();
                return CreatedAtRoute("GetMovies", new { id = movies.ID }, movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Movies movies)
        {
            try
            {
                if (movies.ID == id)
                {

                    context.Entry(movies).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMovies", new { id = movies.ID }, movies);
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

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                var movies = context.Movies.FirstOrDefault(f => f.ID == id);
                if (movies != null)
                {
                    context.Movies.Remove(movies);
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
