namespace PhoneApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Description;
    using PhoneLibrary;
    using PhoneLibrary.Repository;

    public class PhoneController : ApiController
    {
        private Repository repository = new Repository(HttpContext.Current.Server.MapPath("~/bin/PersonsBinaryFile.dat"));   
        private List<Person> personsNew = new List<Person>();

        // GET api/phone
        public IEnumerable<Person> Get()
        {
            return repository.GetAll();
        }

        // GET api/Phone?orderByField={orderByField}&orderByCriteria={orderByCriteria}
        // orderByField = "firstname" or "lastname"
        // orderByCriteria = "a-z or z-a"
        public IEnumerable<Person> Get(string orderByField, string orderByCriteria)
        {
            return repository.GetAll(orderByField, orderByCriteria);
        }
         
        // GET api/phone/5
        public IHttpActionResult Get(int id)
        {
            Person person = repository.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        public IHttpActionResult Get(string name)
        {
            personsNew = repository.GetByName(name);

            if (!personsNew.Any())
            {
                return NotFound();
            }

            return Ok(personsNew);
        }

        // POST api/phone
        [HttpPost]
        [ResponseType(typeof(Person))]
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Create(person);
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // PUT api/phone/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult Put(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!repository.Update(person))
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

         // DELETE api/phone/
        [ResponseType(typeof(Person))]
        public IHttpActionResult Delete(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!repository.Delete(person))
            {
                return NotFound();
            }

            return Ok(person);
        }

        public IHttpActionResult Delete(int id)
        {
            Person person = repository.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            repository.DeleteByID(id);
            return Ok(person);
        }
    }
}
