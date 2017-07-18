using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.API
{
    public class CityController : ApiController
    {
        IRepository<SavedCity> _city;

        public CityController(IRepository<SavedCity> city)
        {
            _city = city;
        }
        
        //Get api/city/id
        [ResponseType(typeof(City))]
        public IHttpActionResult Get(int Id)
        {
            var cityById = _city.GetById(Id);

            return Ok(cityById);
        }

        //Get  api/city
        public IEnumerable<SavedCity> GetCities()
        {
            return _city.Get();
        }

        // POST api/city
        [HttpPost]
        public StatusCodeResult PostCity([FromBody]SavedCity city)
        {
            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                _city.Add(city);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.Created, this);
            }
            else
            {
                return new StatusCodeResult(HttpStatusCode.BadRequest, this);
            }
        }

        // PUT api/city
        [HttpPut]
        public IHttpActionResult Put([FromBody]SavedCity city)
        {
            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                _city.EditCity(city);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            return BadRequest(ModelState);
        }

        // Delete api/city/24
        [HttpDelete]
        public IHttpActionResult HttpDelete([FromBody]SavedCity city)
        {
            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                _city.Delete(city.Id);
                _city.Save();
                return new StatusCodeResult(HttpStatusCode.OK, this);
            }
            return BadRequest(ModelState);
        }
    }
}
