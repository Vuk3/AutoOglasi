import { Automobil } from "./Automobil.js";
import { Korisnik } from "./Korisnik.js";
import { Pijaca } from "./Pijaca.js";

export class Oglas{

    constructor(usernameKorisnika, adresaKorisnika, brojSasijeAutomobila, cenaOglasa, datumOglasa, emailKorisnika, godisteAutomobila, gorivoAutomobila, gradKorisnika, imeKorisnika, jmbgKorisnika, karoserijaAutomobila, kilometrazaAutomobila, kubikazaAutomobila, lokacijaPijace, markaAutomobila, modelAutomobila, nazivPijace, prezimeKorisnika, sifraOglasa, snagaMotoraAutomobila, telefonKorisnika, telefonPijace, slikaKorisnika, adresaPijace){
        this.usernameKorisnika=usernameKorisnika;
        // this.sifraKorisnika=sifraKorisnika;
        this.adresaKorisnika=adresaKorisnika;
        this.brojSasijeAutomobila=brojSasijeAutomobila;
        this.cenaOglasa=cenaOglasa;
        this.datumOglasa=datumOglasa;
        this.emailKorisnika=emailKorisnika;
        this.godisteAutomobila=godisteAutomobila;
        this.gorivoAutomobila=gorivoAutomobila;
        this.gradKorisnika=gradKorisnika;
        this.imeKorisnika=imeKorisnika;
        this.jmbgKorisnika=jmbgKorisnika;
        this.karoserijaAutomobila=karoserijaAutomobila;
        this.kilometrazaAutomobila=kilometrazaAutomobila;
        this.kubikazaAutomobila=kubikazaAutomobila;
        this.lokacijaPijace=lokacijaPijace;
        this.markaAutomobila=markaAutomobila;
        this.modelAutomobila=modelAutomobila;
        this.nazivPijace=nazivPijace;
        this.prezimeKorisnika=prezimeKorisnika;
        this.sifraOglasa=sifraOglasa;
        this.snagaMotoraAutomobila=snagaMotoraAutomobila;
        this.telefonKorisnika=telefonKorisnika;
        this.telefonPijace=telefonPijace;
        this.adresaPijace=adresaPijace;
        this.slikaKorisnika=slikaKorisnika;
    }


    crtajOglas(host){
        
        
        host.innerHTML="";

        let l;

        let d = document.createElement("div");
        d.className="divNoviOglas";
        host.appendChild(d);


        d = document.createElement("div");
        d.className="divNoviOglasCena";
        host.querySelector(".divNoviOglas").appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Cena";
        host.querySelector(".divNoviOglasCena").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.cenaOglasa+" €";
        host.querySelector(".divNoviOglasCena").appendChild(l);





        d = document.createElement("div");
        d.className="divNoviOglasMarkaModel";
        host.querySelector(".divNoviOglas").appendChild(d);


        // l = document.createElement("label");
        // l.innerHTML="Marka i model";
        // host.querySelector(".divNoviOglasMarkaModel"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.markaAutomobila+"\n"+this.modelAutomobila;
        host.querySelector(".divNoviOglasMarkaModel").appendChild(l);



        d = document.createElement("div");
        d.className="divNoviOglasGodiste";
        host.querySelector(".divNoviOglas").appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Godiste";
        host.querySelector(".divNoviOglasGodiste").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.godisteAutomobila;
        host.querySelector(".divNoviOglasGodiste").appendChild(l);


        d = document.createElement("div");
        d.className="divNoviOglasKilometraza";
        host.querySelector(".divNoviOglas").appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Kilometraza";
        host.querySelector(".divNoviOglasKilometraza").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.kilometrazaAutomobila+" km";
        host.querySelector(".divNoviOglasKilometraza").appendChild(l);




        d = document.createElement("div");
        d.className="divNoviOglasKaroserija";
        host.querySelector(".divNoviOglas").appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Karoserija";
        host.querySelector(".divNoviOglasKaroserija").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.karoserijaAutomobila;
        host.querySelector(".divNoviOglasKaroserija").appendChild(l);





        d = document.createElement("div");
        d.className="divNoviOglasGorivo";
        host.querySelector(".divNoviOglas").appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Gorivo";
        host.querySelector(".divNoviOglasGorivo").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.gorivoAutomobila;
        host.querySelector(".divNoviOglasGorivo").appendChild(l);


        host.querySelector(".divNoviOglas").onclick=()=>{

            let novaPijaca = new Pijaca(this.nazivPijace, this.lokacijaPijace, this.adresaPijace, this.telefonPijace);
            novaPijaca.crtajPijacu(host);

            let noviAutomobil= new Automobil(this.brojSasijeAutomobila, this.markaAutomobila, this.modelAutomobila, this.godisteAutomobila, this.kilometrazaAutomobila, this.karoserijaAutomobila, this.gorivoAutomobila, this.kubikazaAutomobila, this.snagaMotoraAutomobila, this.usernameKorisnika, this.nazivPijace);
            noviAutomobil.crtajAutomobil(host);



            let noviKorisnik = new Korisnik(this.jmbgKorisnika, this.usernameKorisnika, this.imeKorisnika, this.prezimeKorisnika, this.gradKorisnika, this.adresaKorisnika, this.telefonKorisnika, this.emailKorisnika, this.slikaKorisnika);
            noviKorisnik.crtajKorisnika(host);


            this.crtajMiniOglas(host.querySelector(".divNoviOglas"));


        }


    }

    crtajOglase(host, index){
        
        if(index==0){
            host.innerHTML="";
        }

        let l;

        let d = document.createElement("div");
        d.className="divNoviOglas"+index;
        host.appendChild(d);


        d = document.createElement("div");
        d.className="divNoviOglasCena"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Cena";
        host.querySelector(".divNoviOglasCena"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.cenaOglasa+" €";
        host.querySelector(".divNoviOglasCena"+index).appendChild(l);





        d = document.createElement("div");
        d.className="divNoviOglasMarkaModel"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        // l = document.createElement("label");
        // l.innerHTML="Marka i model";
        // host.querySelector(".divNoviOglasMarkaModel"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.markaAutomobila;
        host.querySelector(".divNoviOglasMarkaModel"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.modelAutomobila;
        host.querySelector(".divNoviOglasMarkaModel"+index).appendChild(l);
        



        d = document.createElement("div");
        d.className="divNoviOglasGodiste"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Godiste";
        host.querySelector(".divNoviOglasGodiste"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.godisteAutomobila;
        host.querySelector(".divNoviOglasGodiste"+index).appendChild(l);


        d = document.createElement("div");
        d.className="divNoviOglasKilometraza"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Kilometraza";
        host.querySelector(".divNoviOglasKilometraza"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.kilometrazaAutomobila+" km";
        host.querySelector(".divNoviOglasKilometraza"+index).appendChild(l);




        d = document.createElement("div");
        d.className="divNoviOglasKaroserija"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Karoserija";
        host.querySelector(".divNoviOglasKaroserija"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.karoserijaAutomobila;
        host.querySelector(".divNoviOglasKaroserija"+index).appendChild(l);





        d = document.createElement("div");
        d.className="divNoviOglasGorivo"+index;
        host.querySelector(".divNoviOglas"+index).appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Gorivo";
        host.querySelector(".divNoviOglasGorivo"+index).appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.gorivoAutomobila;
        host.querySelector(".divNoviOglasGorivo"+index).appendChild(l);


        host.querySelector(".divNoviOglas"+index).onclick=()=>{
            host.innerHTML="";
            // var divs = host.querySelectorAll("host > div:not(.divNoviOglas"+index+")");
            // console.log(divs);

            d = document.createElement("div");
            d.className="divNoviOglas"+index;
            host.appendChild(d);

            let novaPijaca = new Pijaca(this.nazivPijace, this.lokacijaPijace, this.adresaPijace, this.telefonPijace);
            novaPijaca.crtajPijacu(host);



            let noviAutomobil= new Automobil(this.brojSasijeAutomobila, this.markaAutomobila, this.modelAutomobila, this.godisteAutomobila, this.kilometrazaAutomobila, this.karoserijaAutomobila, this.gorivoAutomobila, this.kubikazaAutomobila, this.snagaMotoraAutomobila, this.usernameKorisnika, this.nazivPijace);
            noviAutomobil.crtajAutomobil(host);

            let noviKorisnik = new Korisnik(this.jmbgKorisnika, this.usernameKorisnika, this.imeKorisnika, this.prezimeKorisnika, this.gradKorisnika, this.adresaKorisnika, this.telefonKorisnika, this.emailKorisnika, this.slikaKorisnika);
            noviKorisnik.crtajKorisnika(host);



            this.crtajMiniOglas(d, index);


        }


    }

    crtajMiniOglas(host, index){

        host.innerHTML="";

        let d;
        let l;


        // d=document.createElement("div");
        // d.className="divNoviMiniOglas";
        // host.appendChild(d);




        d = document.createElement("div");
        d.className="AdivNoviOglasCena";
        host.appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Cena";
        host.querySelector(".AdivNoviOglasCena").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.cenaOglasa+" €";
        host.querySelector(".AdivNoviOglasCena").appendChild(l);


        d = document.createElement("div");
        d.className="AdivNoviOglasDatum";
        host.appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Datum postavljanja";
        host.querySelector(".AdivNoviOglasDatum").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.datumOglasa;
        host.querySelector(".AdivNoviOglasDatum").appendChild(l);


        d = document.createElement("div");
        d.className="AdivNoviOglasSifraOglasa";
        host.appendChild(d);


        l = document.createElement("label");
        l.innerHTML="Sifra oglasa";
        host.querySelector(".AdivNoviOglasSifraOglasa").appendChild(l);

        l=document.createElement("label");
        l.innerHTML=this.sifraOglasa;
        host.querySelector(".AdivNoviOglasSifraOglasa").appendChild(l);
            
    }
}