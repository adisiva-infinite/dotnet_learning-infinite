using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assessment.Models;

namespace Assessment.Controllers
{
    [RoutePrefix("api/User")]
    public class CountryController : ApiController
    {
        List<Country> CountryList = new List<Country>()
        {
             new Country{CountryId = 1,  CountryName = "India" , Capital = "Delhi"},
              new Country{CountryId = 2, CountryName = "Sri Lanka" , Capital = "Colombo"},
                new Country{CountryId = 3, CountryName = "Swaziland" , Capital = "Mbabane"},
        };

        // Get 1

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCountries()
        {
            return Ok(CountryList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCountryById(int id)
        {
            var country = CountryList.FirstOrDefault(c => c.CountryId == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");
            CountryList.Add(country);
            return Ok(country);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCountry(int id, [FromBody] Country updateCountry)
        {
            var country = CountryList.FirstOrDefault(c => c.CountryId == id);
            if (country == null)
                return NotFound();

            country.CountryName = updateCountry.CountryName;
            country.Capital = updateCountry.Capital;
            return Ok(country);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = CountryList.FirstOrDefault(c => c.CountryId == id);
            if (country == null)
                return NotFound();

            CountryList.Remove(country);
            return Ok();
        }
    }
}