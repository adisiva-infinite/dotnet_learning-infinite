﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_1.Models;

namespace WebApi_1.Controllers
{
    [RoutePrefix("api/User")]
    public class PersonController : ApiController
    {
        List<Person> Personlist = new List<Person>()
        {
            new Person
            {
                Id = 1,
                Personname = "Adi Siva Naidu",
                PersonJob = "King",
                Gender = "Male"
            },
            new Person
            {
                Id = 2,
                Personname = "Girl",
                PersonJob = "Queen",
                Gender = "Female"
            },
            new Person
            {
                Id = 3,
                Personname = "Bheem",
                PersonJob = "Defence Minister",
                Gender = "Male"
            },
            new Person
            {
                Id = 4,
                Personname = "Arjun",
                PersonJob = "Archerer",
                Gender = "Male"
            },
             new Person
             {
                 Id = 5,
                 Personname = "Nakul Sahadev",
                 PersonJob = "Operator",
                 Gender = "Male"
             },
        };
        //Get 1
        [HttpGet]
        [Route("All")]
        public IEnumerable<Person> Get()
        {
            return Personlist;
        }

        //Get 2
        [HttpGet]
        [Route("Bymsg")]
        public HttpResponseMessage GetAllPersons()
        {
            //creating response with both data and status
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Personlist);

            //creating just a response and no data 
            //HttpResponseMessage response = response.Content = new StringContent("Received Request, Thanks..");
            return response;
        }

        //Get 3
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetPersonNameById(int pId)
        {
            string pname = Personlist.Where(p => p.Id == pId).SingleOrDefault()?.Personname;
            if (pname == null)
            {
                return NotFound();
            }
            return Ok(pname);

        }
    }
}