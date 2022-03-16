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
                    adresa=probnaPijaca.adresa,
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
                    
                    p.naziv,
                    p.lokacija,
                    p.adresa,
                    p.telefon
                    // }
                }).ToListAsync());
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }


        [Route("DodajPijacu/{nazivPijace}/{lokacijaPijace}/{adresaPijace}/{telefonPijace}")]
        [HttpPost]

        public async Task<ActionResult> DodajPijacu(string nazivPijace, string lokacijaPijace, string adresaPijace, string telefonPijace){
            if(string.IsNullOrWhiteSpace(nazivPijace)){
                return BadRequest("Nevalidan naziv");
            }

            if(string.IsNullOrWhiteSpace(lokacijaPijace)){
                return BadRequest("Nevalidna lokacija");
            }

            if(string.IsNullOrWhiteSpace(adresaPijace)){
                return BadRequest("Nevalidna adresa");
            }

            if(string.IsNullOrWhiteSpace(telefonPijace)){
                return BadRequest("Nevalidan telefon");
            }

            try{

                var probnaPijaca= await Context.Pijace.Where(p=>p.naziv==nazivPijace).FirstOrDefaultAsync();
                if(probnaPijaca!=null){
                    return BadRequest("Pijaca sa datim imenom vec postoji");
                }

                var novaPijaca = new Pijaca{
                    naziv=nazivPijace,
                    lokacija=lokacijaPijace,
                    adresa=adresaPijace,
                    telefon=telefonPijace
                };

                Context.Pijace.Add(novaPijaca);
                await Context.SaveChangesAsync();

                return Ok(new{
                    naziv=novaPijaca.naziv,
                    lokacija=novaPijaca.lokacija,
                    adresa=novaPijaca.adresa,
                    telefon=novaPijaca.telefon
                });
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }


        }

        [Route("IzmeniPijacu/{nazivPijace}/{telefonPijace}")]
        [HttpPut]

        public async Task<ActionResult> IzmeniPijacu(string nazivPijace, string telefonPijace){



            if(string.IsNullOrWhiteSpace(nazivPijace)){
                return BadRequest("Nevalidan naziv");
            }        

            if(string.IsNullOrWhiteSpace(telefonPijace)){
                return BadRequest("Nevalidan telefon");
            }

            try{
                var pijaca = await Context.Pijace.Where(p=> p.naziv==nazivPijace).FirstOrDefaultAsync();
                if (pijaca==null){
                    return BadRequest("Pijaca ne postoji");
                }

                if(telefonPijace!="-"){
                    pijaca.telefon=telefonPijace;
                }

                await Context.SaveChangesAsync();

                return Ok(new{
                    naziv=pijaca.naziv,
                    lokacija=pijaca.lokacija,
                    adresa=pijaca.adresa,
                    telefon=pijaca.telefon
                });           
            } 
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }


        [Route("ObrisiPijacu/{nazivPijace}")]
        [HttpDelete]

        public async Task<ActionResult> ObrisiPijacu(string nazivPijace){
            if (string.IsNullOrWhiteSpace(nazivPijace)){
                return BadRequest("Nevalidan naziv pijace");
            }

            try{
                var probnaPijaca = await Context.Pijace.Where(p=>p.naziv==nazivPijace).FirstOrDefaultAsync();
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
