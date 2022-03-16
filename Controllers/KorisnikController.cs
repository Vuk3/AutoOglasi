using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Web_Projekat_18036.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {
        public AutoOglasiContext Context { get; set; }

        public KorisnikController(AutoOglasiContext context)
        {
            Context=context;
        }

        [Route("PreuzmiKorisnike")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKorisnike()
        {
            try{
                return Ok(await Context.Korisnici.Select(p=>
                new{
                    p.ID,
                    p.JMBG,
                    p.username,
                    p.sifra,
                    p.ime,
                    p.prezime,
                    p.grad,
                    p.adresa,
                    p.telefon,
                    p.email,
                    p.slika
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [Route("PrikaziSvojePonude/{usernameKorisnika}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziSvojePonude(string usernameKorisnika){

            

            
            try{

                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidan JMBG");
                }

                var probniKorisnik = await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();

                if(probniKorisnik==null){
                    return BadRequest("Korisnik sa datim korisnickim imenom ne postoji");
                }
                return Ok(await Context.Oglasi
                .Include(p=>p.automobil)
                .Include(p=>p.vlasnikOglasa)
                .Include(p=>p.pijaca)
                .Where(p=>p.vlasnikOglasa.username==usernameKorisnika)
                .Select(p=>
                new{

                        // InformacijeOOglasu = new{
                        cena=p.cena,
                        datum=p.datumPostavljanja,
                        sifraOglasa=p.sifraOglasa,
                        // },


                        // Vlasnik = new{
                        JMBGkorisnika=p.vlasnikOglasa.JMBG,
                        usernamekorisnika=p.vlasnikOglasa.username,
                        imeKorisnika=p.vlasnikOglasa.ime,
                        prezimeKorisnika=p.vlasnikOglasa.prezime,
                        telefonKorisnika=p.vlasnikOglasa.telefon,
                        gradKorisnika=p.vlasnikOglasa.grad,
                        adresaKorisnika=p.vlasnikOglasa.adresa,
                        emailKorisnika=p.vlasnikOglasa.email,
                        slikaKorisnika=p.vlasnikOglasa.slika,
                        // },

                        // Automobil = new{
                        brojSasijeAutomobila=p.automobil.brojSasije,
                        markaAutomobila=p.automobil.marka,
                        modelAutomobila=p.automobil.model,
                        godisteAutomobila=p.automobil.godiste,
                        kilometrazaAutomobila=p.automobil.kilometraza,
                        karoserijaAutomobila=p.automobil.karoserija,
                        gorivoAutomobila=p.automobil.gorivo,
                        kubikazaAutomobila=p.automobil.kubikaza,
                        snagaMotoraAutomobila=p.automobil.snagaMotora,
                        // },


                        // Pijaca = new{
                        nazivPijace=p.pijaca.naziv,
                        lokacijaPijace=p.pijaca.lokacija,
                        telefonPijace=p.pijaca.telefon

                    
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






        [Route("DodajKorisnika/{JMBGKorisnika}/{usernameKorisnika}/{sifraKorisnika}/{imeKorisnika}/{prezimeKorisnika}/{gradKorisnika}/{adresaKorisnika}/{telefonKorisnika}/{emailKorisnika}/{slikaKorisnika}")]
        [HttpPost]
        


        public async Task<ActionResult> DodajKorisnika(string JMBGKorisnika, string usernameKorisnika, string sifraKorisnika, string imeKorisnika, string prezimeKorisnika, string gradKorisnika, string adresaKorisnika, string telefonKorisnika, string emailKorisnika, string slikaKorisnika){
            
            try{
                if(JMBGKorisnika.Length!=13){
                    return BadRequest("Nevalidan JMBG");
                }

                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidno korisnicko ime");
                }

                if(string.IsNullOrWhiteSpace(sifraKorisnika)){
                    return BadRequest("Nevalidna sifra");
                }

                if(imeKorisnika.Length>30 || string.IsNullOrWhiteSpace(imeKorisnika)){
                    return BadRequest("Nevalidno ime");
                }        

                if(prezimeKorisnika.Length>30 || string.IsNullOrWhiteSpace(prezimeKorisnika)){
                    return BadRequest("Nevalidno prezime");
                }  

                if(gradKorisnika.Length>40 || string.IsNullOrWhiteSpace(gradKorisnika)){
                    return BadRequest("Nevalidan grad");
                }

                if(string.IsNullOrWhiteSpace(adresaKorisnika)){
                    return BadRequest("Nevalidna adresa");
                }

                if(string.IsNullOrWhiteSpace(telefonKorisnika)){
                    return BadRequest("Nevalidan telefon");
                }

                if(string.IsNullOrWhiteSpace(emailKorisnika)){
                    return BadRequest("Nevalidan email");
                }

                if(string.IsNullOrWhiteSpace(slikaKorisnika)){
                    return BadRequest("Nevalidna slika");
                }



                var probniKorisnik = await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();

                if (probniKorisnik!=null){
                    return BadRequest("Korisnicko ime zauzeto");
                }

                probniKorisnik = await Context.Korisnici.Where(p=>p.JMBG==JMBGKorisnika).FirstOrDefaultAsync();
                if (probniKorisnik!=null){
                    return BadRequest("Postoji korisnik sa JMBG-om" + JMBGKorisnika);
                }

                Korisnik korisnik = new Korisnik{
                    JMBG=JMBGKorisnika,
                    username=usernameKorisnika,
                    sifra=sifraKorisnika,
                    ime=imeKorisnika,
                    prezime=prezimeKorisnika,
                    grad=gradKorisnika,
                    adresa=adresaKorisnika,
                    telefon=telefonKorisnika,
                    email=emailKorisnika,
                    slika=slikaKorisnika
                };


                Context.Korisnici.Add(korisnik);

                await Context.SaveChangesAsync();

                return Ok(
                    new
                    {
                    JMBG=JMBGKorisnika,
                    username=usernameKorisnika,
                    sifra=sifraKorisnika,
                    ime=imeKorisnika,
                    prezime=prezimeKorisnika,
                    grad=gradKorisnika,
                    adresa=adresaKorisnika,
                    telefon=telefonKorisnika,
                    email=emailKorisnika,
                    slika=slikaKorisnika
                });     
            }                               
            catch (Exception e){
                return BadRequest(e.Message);
            }

        }

        
        [Route("NadjiKorisnika/{usernameKorisnika}/{sifraKorisnika}")]
        [HttpGet]
        public async Task<ActionResult> NadjiKorisnika(string usernameKorisnika, string sifraKorisnika){
            try{


                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidno korisnicko ime");
                }

                if(string.IsNullOrWhiteSpace(sifraKorisnika)){
                    return BadRequest("Nevalidna sifra");
                }


                var probniKorisnik = await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();

                if (probniKorisnik==null){
                    return BadRequest("Ovaj korisnik ne postoji u bazi");
                }

                var probniKorisnik2 = await Context.Korisnici.Where(p=>p.username==usernameKorisnika && p.sifra==sifraKorisnika).FirstOrDefaultAsync();
                
                if(probniKorisnik2==null){
                    return BadRequest("Pogresna sifra, pokusajte ponovo");
                }

                return Ok(
                    new{
                        jmbg=probniKorisnik2.JMBG,
                        username=probniKorisnik2.username,
                        ime=probniKorisnik2.ime,
                        prezime=probniKorisnik2.prezime,
                        grad=probniKorisnik2.grad,
                        adresa=probniKorisnik2.adresa,
                        telefon=probniKorisnik2.telefon,
                        email=probniKorisnik2.email,
                        slika=probniKorisnik2.slika    
                    }
                );

            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }




        [Route("NadjiAdmina/{usernameKorisnika}/{sifraKorisnika}")]
        [HttpGet]
        public async Task<ActionResult> NadjiAdmina(string usernameKorisnika, string sifraKorisnika){
            try{


                var user = await Context.Korisnici.Where(p=>p.username==usernameKorisnika && p.sifra==sifraKorisnika).FirstOrDefaultAsync();

                if(usernameKorisnika=="Admin" && sifraKorisnika!="admin"){
                    return BadRequest("Admine, pogresna sifra!");
                }


                if(user!=null){
                    if(usernameKorisnika!="Admin"){
                        return BadRequest("Samo admin moze da uredjuje pijacu");
                    }
                }
                else{
                    return BadRequest("Korisnik ne postoji");
                }

                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidno korisnicko ime");
                }

                if(string.IsNullOrWhiteSpace(sifraKorisnika)){
                    return BadRequest("Nevalidna sifra");
                }

        
                return Ok();

            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [Route("NadjiKorisnikaBezSifre/{usernameKorisnika}")]
        [HttpGet]
        public async Task<ActionResult> NadjiKorisnikaBezSifre(string usernameKorisnika){
            try{


                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidno korisnicko ime");
                }

                var probniKorisnik = await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();

                if (probniKorisnik==null){
                    return BadRequest("Ovaj korisnik ne postoji u bazi");
                }

                return Ok(
                    new{
                        jmbg=probniKorisnik.JMBG,
                        username=probniKorisnik.username,
                        ime=probniKorisnik.ime,
                        prezime=probniKorisnik.prezime,
                        grad=probniKorisnik.grad,
                        adresa=probniKorisnik.adresa,
                        telefon=probniKorisnik.telefon,
                        email=probniKorisnik.email,
                        slika=probniKorisnik.slika    
                    }
                );

            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }


        [Route("IzmeniKorisnika/{usernameKorisnika}/{noviGrad}/{novaAdresa}/{noviTelefon}/{noviEmail}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniKorisnika(string usernameKorisnika, string noviGrad, string novaAdresa, string noviTelefon, string noviEmail){


            if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                return BadRequest("Nevalidan JMBG");
            }

            if(noviGrad.Length>40){
                return BadRequest("Nevalidan grad");
            }


            try{
                var probniKorisnik=await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();
                if(probniKorisnik==null)
                {
                    return BadRequest("Korisnik ne postoji");
                }

                if(noviGrad!="-"){
                    probniKorisnik.grad=noviGrad;
                }

                if(novaAdresa!="-"){
                    probniKorisnik.adresa=novaAdresa;
                }

                if(noviTelefon!="-"){
                    probniKorisnik.telefon=noviTelefon;
                }

                if(noviEmail!="-"){
                    probniKorisnik.email=noviEmail;
                }


                await Context.SaveChangesAsync();
                
                return Ok(
                    new{
                        jmbg=probniKorisnik.JMBG,
                        username=probniKorisnik.username,
                        sifra=probniKorisnik.sifra,
                        ime=probniKorisnik.ime,
                        prezime=probniKorisnik.prezime,
                        grad=probniKorisnik.grad,
                        adresa=probniKorisnik.adresa,
                        telefon=probniKorisnik.telefon,
                        email=probniKorisnik.email,
                        slika=probniKorisnik.slika 
                    }
                );
            }
            
            catch(Exception e){
                return BadRequest(e.Message);
            }

        }






        [Route("ObrisiKorisnika/{usernameKorisnika}")]
        [HttpDelete]

        public async Task<ActionResult> ObrisiKorisnika(string usernameKorisnika){
            if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                return BadRequest("Nevalidno korisnicko ime");
            }

            try{
                var probniKorisnik = await Context.Korisnici.Where(p=>p.username==usernameKorisnika).FirstOrDefaultAsync();
                if(probniKorisnik==null)
                {
                    return BadRequest("Korisnik ne postoji");
                }
                var oglasiKorisnika = await Context.Oglasi.Where(p=>p.vlasnikOglasa.username==usernameKorisnika).ToListAsync();

                oglasiKorisnika.ForEach(p=> Context.Oglasi.Remove(p));



                var automobiliKorisnika = await Context.Automobili.Where(p=>p.vlasnikAutomobila.username==usernameKorisnika).ToListAsync();

                automobiliKorisnika.ForEach(p=> Context.Automobili.Remove(p));


                
                Context.Korisnici.Remove(probniKorisnik);
                await Context.SaveChangesAsync();
                
                return Ok("Korisnik obrisan");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }                
            
        }

        [Route("VratiSifru/{JMBGKorisnika}/{usernameKorisnika}/{imeKorisnika}/{prezimeKorisnika}/{gradKorisnika}/{adresaKorisnika}/{telefonKorisnika}/{emailKorisnika}")]
        [HttpGet]

        public async Task<ActionResult> VratiSifru(string JMBGKorisnika, string usernameKorisnika, string imeKorisnika, string prezimeKorisnika, string gradKorisnika, string adresaKorisnika, string telefonKorisnika, string emailKorisnika){
            try{
                if(JMBGKorisnika.Length!=13){
                    return BadRequest("Nevalidan JMBG");
                }
                if(string.IsNullOrWhiteSpace(usernameKorisnika)){
                    return BadRequest("Nevalidno korisnicko ime");
                }
                if(string.IsNullOrWhiteSpace(imeKorisnika)){
                    return BadRequest("Nevalidno ime");
                }
                if(string.IsNullOrWhiteSpace(prezimeKorisnika)){
                    return BadRequest("Nevalidno prezime");
                }
                if(string.IsNullOrWhiteSpace(gradKorisnika)){
                    return BadRequest("Nevalidan grad");
                }
                if(string.IsNullOrWhiteSpace(adresaKorisnika)){
                    return BadRequest("Nevalidna adresa");
                }
                if(string.IsNullOrWhiteSpace(telefonKorisnika)){
                    return BadRequest("Nevalidan telefon");
                }
                if(string.IsNullOrWhiteSpace(emailKorisnika)){
                    return BadRequest("Nevalidan email");
                }


                var probniKorisnik = await Context.Korisnici
                .Where(p=>
                p.JMBG==JMBGKorisnika &&
                p.username==usernameKorisnika &&
                p.ime==imeKorisnika &&
                p.prezime==prezimeKorisnika &&
                p.grad==gradKorisnika &&
                p.adresa==adresaKorisnika &&
                p.telefon==telefonKorisnika &&
                p.email==emailKorisnika
                ).FirstOrDefaultAsync();

                if (probniKorisnik==null){
                    return BadRequest("Korisnik sa ovim podacima ne postoji u");
                }

                return Ok(
                    new{
                        sifra=probniKorisnik.sifra  
                    }
                );


            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
  
    }


}
