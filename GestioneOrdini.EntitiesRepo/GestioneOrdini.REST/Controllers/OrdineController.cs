using GestioneOrdini.EntitiesRepo.BusinessLayer;
using GestioneOrdini.EntitiesRepo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneOrdini.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {

        private readonly IGestioneOrdiniBL bl;

        public OrdineController(IGestioneOrdiniBL bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        public ActionResult GetAllOrdini()
        {


            return Ok(bl.FetchOrdini());
        }

        [HttpGet("{code}")]
        public ActionResult GetOrdineByCode(string code)
        {
            var ordine = bl.GetOrdineByCode(code);
            if (ordine == null) return NotFound();

            return Ok(ordine);
        }


        [HttpDelete("{code}")]
        public ActionResult DeleteOrdine(string code)
        {
            var ordine = bl.GetOrdineByCode(code);
            if (ordine == null) return NotFound();
            if (!bl.DeleteOrdine(ordine)) return BadRequest();
            return Ok();
        }



        //PER PUT E POST

        //in input json del tipo:
        //(in client necessario il codiceCliente)

        //{
        //"codiceOrdine": "0504",
        //"codiceProdotto": "1c",
        //"importo": 12.6,
        //"cliente": {"codiceCliente":"12a"},
        //"dataOrdine": "2020-12-11"
        //}



        [HttpPut] 
        public ActionResult UpdateOrdine( [FromBody] Ordine ordine)
        {
            if (ordine == null) return BadRequest();

            if (!bl.EditOrdine(ordine)) return BadRequest();

            return Ok();

        }

        [HttpPost]
        public ActionResult CreateNewOrdine([FromBody] Ordine newOrdine)
        {
            if (newOrdine == null) return BadRequest();

            if (!bl.CreateOrdine(newOrdine)) return BadRequest();

            return Ok();

        }



}
}
