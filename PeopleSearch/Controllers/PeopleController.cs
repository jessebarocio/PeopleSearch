using PeopleSearch.Data;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    [RoutePrefix("people")]
    public class PeopleController : Controller
    {
        private IPeopleRepository _peopleRepository;
        private IPhotoRepository _photoRepository;

        public PeopleController() : this(new EFPeopleRepository(), new EFPhotoRepository()) { }

        public PeopleController(IPeopleRepository peopleRepo, IPhotoRepository photoRepo)
        {
            _peopleRepository = peopleRepo;
            _photoRepository = photoRepo;
        }

        /// <summary>
        /// Searches for people with names that contain the given string.
        /// </summary>
        /// <param name="searchStr">The string to search for.</param>
        /// <returns>A collection of people with matching names.</returns>
        [HttpGet, Route("search/{searchStr}")]
        public async Task<JsonResult> SearchByNameAsync(string searchStr)
        {
            // Retrieve matches from the repository and map to a DTO so unnecessary properties aren't 
                // sent to the client.
            var people = (await _peopleRepository.SearchByNameAsync(searchStr))
                .Select(p => MapToDto(p));
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Retrieves the profile photo for the given person.
        /// </summary>
        /// <param name="id">The ID of the person whose photo is being requested.</param>
        /// <returns>The profile photo or a default if no profile photo is set.</returns>
        [HttpGet, Route("{id}/photo")]
        public async Task<FileResult> GetPhotoAsync(int id)
        {
            var person = await _peopleRepository.GetPersonAsync(id);
            // If the person has a PhotoId set then retrieve and return their photo from the repository.
            if (person.PhotoId.HasValue)
            {
                var photo = await _photoRepository.GetPhotoAsync(person.PhotoId.Value);
                return File(photo.Data, photo.ContentType);
            }
            else // Else use this default photo.
            {
                return File(Server.MapPath("~/Content/default.png"), "image/png");
            }
        }

        [HttpPost, Route("")]
        public async Task<PersonDTO> PostPersonAsync(PersonDTO person)
        {
            var result = await _peopleRepository.InsertPersonAsync(MapToEntity(person));
            person.PersonId = result.PersonId;
            return person;
        }

        private static PersonDTO MapToDto(Person person)
        {
            return new PersonDTO()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                City = person.City,
                State = person.State,
                Zip = person.Zip,
                Age = person.Age,
                Interests = person.Interests
            };
        }

        private static Person MapToEntity(PersonDTO person)
        {
            return new Person()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                City = person.City,
                State = person.State,
                Zip = person.Zip,
                Age = person.Age,
                Interests = person.Interests
            };
        }
    }
}