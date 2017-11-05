using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using sport_workouts_web_api.Classes;
using sport_workouts_web_api.Models;
using System.Web.Http.Cors;

namespace sport_workouts_web_api.Controllers
{
    [Authorize]
    [EnableCorsAttribute("http://localhost:4200", "*", "*")]
    public class MuscleGroupsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MuscleGroups
        public List<MuscleGroupsGetDto> GetMuscleGroups()
        {
            var list = db.MuscleGroups.ToList();
            var resultList = AutoMapper.Mapper.Map<List<MuscleGroupsGetDto>>(list);

            return resultList;
        }

        // GET: api/MuscleGroups/5
        [ResponseType(typeof(MuscleGroup))]
        public IHttpActionResult GetMuscleGroup(int id)
        {
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            MuscleGroupsGetDto result = AutoMapper.Mapper.Map<MuscleGroupsGetDto>(muscleGroup);
            return Ok(result);
        }

        // PUT: api/MuscleGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMuscleGroup(int id, MuscleGroupsUpdateDto muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muscleGroup.MuscleGroupId)
            {
                return BadRequest();
            }

            var muscle = db.MuscleGroups.Find(id);
            AutoMapper.Mapper.Map(muscleGroup, muscle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var updatedMuscle = db.MuscleGroups.Find(id);
            MuscleGroupsGetDto result = AutoMapper.Mapper.Map<MuscleGroupsGetDto>(updatedMuscle);
            return Ok(result);
        }

        // POST: api/MuscleGroups
        [ResponseType(typeof(MuscleGroup))]
        public IHttpActionResult PostMuscleGroup(MuscleGroupsPostDto muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var insertItem = AutoMapper.Mapper.Map<MuscleGroup>(muscleGroup);
            db.MuscleGroups.Add(insertItem);
            db.SaveChanges();

            var muscleGroupDto = AutoMapper.Mapper.Map<MuscleGroupsGetDto>(insertItem);

            return CreatedAtRoute("DefaultApi", new { id = muscleGroupDto.MuscleGroupId }, muscleGroupDto);
        }

        // DELETE: api/MuscleGroups/5
        //[ResponseType(typeof(MuscleGroup))]
        [Route("api/musclegroups/delete/{id}")]
        public IHttpActionResult DeleteMuscleGroup(int id)
        {
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

             db.MuscleGroups.Remove(muscleGroup);
             db.SaveChanges();
            MuscleGroupsGetDto result = AutoMapper.Mapper.Map<MuscleGroupsGetDto>(muscleGroup);
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuscleGroupExists(int id)
        {
            return db.MuscleGroups.Count(e => e.MuscleGroupId == id) > 0;
        }
    }
}