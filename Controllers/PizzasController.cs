using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using byteant.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace byteant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        // GET: api/<PizzasController>
        [HttpGet]
        public List<CountedPizza> Get()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"./pizzas.json");
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            List<CountedPizza> filteredPizzas = Sorter.find(pizzas);
            return filteredPizzas;
        }

        // GET api/<PizzasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PizzasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PizzasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PizzasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //public IEnumerable Index()
        //{
        //    var webClient = new WebClient();
        //    var json = webClient.DownloadString(@"C:\Users\oleh\Downloads\pizzas 1.json");
        //    var countries = JsonConvert.DeserializeObject<Pizzas>(json);
        //    return countries;
        //}
    }
}
