using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Web_Projekat_18036.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PijacaController : ControllerBase
    {
        public AutoOglasiContext Context { get; set; }

        public PijacaController(AutoOglasiContext context)
        {
            Context=context;
        }

        [Route("PreuzmiPijacu/{nazivPijace}")]
        [HttpGet]

        public async Task<ActionResult> PreuzmiPijacu(string nazivPijace){
            try{
                var probnaPijaca= await Context.Pijace.Where(p=>p.naziv==nazivPijace).FirstOrDefaultAsync();
                
                if(probnaPijaca==null){
                    return BadRequest("Ne postoji pijaca sa datim imenom");
                }
               
                
                return Ok(new{
                    naziv=probnaPijaca.naziv,
                    lokacija=probnaPijaca.lokacija,
                    telefon=probnaPijaca.telefon
                });
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }




        [Route("PreuzmiPijace")]
        [HttpGet]

        public async Task<ActionResult> PreuzmiPijace(){
            try{
                return Ok(await Context.Pijace.Select(p=>
                new
                {
                    // Pijaca = new{
                    NoviID=p.ID,
                    p.naziv,
                    p.lokacija,
                    p.telefon
                    // }
                }).ToListAsync());
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }


        [Route("DodajPijacu")]
        [HttpPost]

        public async Task<ActionResult> DodajPijacu([FromBody] Pijaca pijaca){
                if(string.IsNullOrWhiteSpace(pijaca.naziv)){
                return BadRequest("Nevalidan naziv");
            }

            if(string.IsNullOrWhiteSpace(pijaca.lokacija)){
                return BadRequest("Nevalidna lokacija");
            }

            if(string.IsNullOrWhiteSpace(pijaca.telefon)){
                return BadRequest("Nevalidan telefon");
            }

            try{

                var probnaPijaca=Context.Pijace.Where(p=>p.naziv==pijaca.naziv).FirstOrDefaultAsync();
                if(probnaPijaca!=null){
                    return BadRequest("Pijaca sa datim imenom vec postoji");
                }
                Context.Pijace.Add(pijaca);
                await Context.SaveChangesAsync();

                return Ok($"Dodata je pijaca sa ID: {pijaca.ID}.");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }


        }

        [Route("IzmeniPijacu")]
        [HttpPut]

        public async Task<ActionResult> IzmeniPijacu([FromBody] Pijaca novaPijaca){



            if(string.IsNullOrWhiteSpace(novaPijaca.naziv)){
                return BadRequest("Nevalidan naziv");
            }        

            if(string.IsNullOrWhiteSpace(novaPijaca.lokacija)){
                return BadRequest("Nevalidna lokacija");
            }  

            if(string.IsNullOrWhiteSpace(novaPijaca.telefon)){
                return BadRequest("Nevalidan telefon");
            }

            try{
                var pijaca = await Context.Pijace.FindAsync(novaPijaca.ID);
                if (pijaca==null){
                    return StatusCode(201,"Pijaca ne postoji");
                }

                pijaca.naziv=novaPijaca.naziv;
                pijaca.lokacija=novaPijaca.lokacija;
                pijaca.telefon=novaPijaca.telefon;

                await Context.SaveChangesAsync();

                return Ok("Uspesno promenjena Pijaca!");               
            } 
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }


        [Route("ObrisiPijacu/{id}")]
        [HttpDelete]

        public async Task<ActionResult> ObrisiPijacu(int id){
            if (id<0){
                return BadRequest("Nevalidan ID");
            }

            try{
                var probnaPijaca = await Context.Pijace.FindAsync(id);
                if (probnaPijaca==null){
                    return BadRequest("Pijaca ne postoji");
                }

                Context.Pijace.Remove(probnaPijaca);

                await Context.SaveChangesAsync();
                
                return Ok("Pijaca obrisana");
            }

            catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
