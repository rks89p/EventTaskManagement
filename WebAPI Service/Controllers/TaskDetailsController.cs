using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Service;

namespace WebAPI_Service.Controllers
{
    public class TaskDetailsController : ApiController
    {
        private DBTestEntities db = new DBTestEntities();

        // GET: api/TaskDetails
        public IQueryable<TaskDetail> GetTaskDetails()
        {
            return db.TaskDetails;
        }

        // GET: api/TaskDetails/5
        [ResponseType(typeof(TaskDetail))]
        public async Task<IHttpActionResult> GetTaskDetail(int id)
        {
            TaskDetail taskDetail = await db.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return Ok(taskDetail);
        }

        // PUT: api/TaskDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaskDetail(int id, TaskDetail taskDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskDetail.Task_ID)
            {
                return BadRequest();
            }

            db.Entry(taskDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TaskDetails
        [ResponseType(typeof(TaskDetail))]
        public async Task<IHttpActionResult> PostTaskDetail(TaskDetail taskDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskDetails.Add(taskDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taskDetail.Task_ID }, taskDetail);
        }

        // DELETE: api/TaskDetails/5
        [ResponseType(typeof(TaskDetail))]
        public async Task<IHttpActionResult> DeleteTaskDetail(int id)
        {
            TaskDetail taskDetail = await db.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            db.TaskDetails.Remove(taskDetail);
            await db.SaveChangesAsync();

            return Ok(taskDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskDetailExists(int id)
        {
            return db.TaskDetails.Count(e => e.Task_ID == id) > 0;
        }
    }
}