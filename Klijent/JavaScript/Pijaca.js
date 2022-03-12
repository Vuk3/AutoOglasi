export class Pijaca{

    constructor(naziv, lokacija, telefon){
        // this.id=id;
        this.naziv=naziv;
        this.lokacija=lokacija;
        this.telefon=telefon;
    }

    crtajPijacu(host){

        let divProvera = document.createElement("divZaProveruPijace");
        divProvera=host.querySelector(".divNovaPijaca");

        if(divProvera==null){

            let d = document.createElement("div");
            d.className="divNovaPijaca";
            host.appendChild(d);


            d.innerHTML="";


            d=document.createElement("div");
            d.className="divNovaPijacaNaziv";
            host.querySelector(".divNovaPijaca").appendChild(d);

            let l = document.createElement("label");
            l.innerHTML="Naziv pijace";
            host.querySelector(".divNovaPijacaNaziv").appendChild(l);

            l=document.createElement("label");
            l.innerHTML=this.naziv;
            host.querySelector(".divNovaPijacaNaziv").appendChild(l);







            d=document.createElement("div");
            d.className="divNovaPijacaLokacija";
            host.querySelector(".divNovaPijaca").appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Lokacija";
            host.querySelector(".divNovaPijacaLokacija").appendChild(l);

            l=document.createElement("label");
            l.innerHTML=this.lokacija;
            host.querySelector(".divNovaPijacaLokacija").appendChild(l);







            d=document.createElement("div");
            d.className="divNovaPijacaTelefon";
            host.querySelector(".divNovaPijaca").appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Telefon";
            host.querySelector(".divNovaPijacaTelefon").appendChild(l);

            l=document.createElement("label");
            l.innerHTML=this.telefon;
            host.querySelector(".divNovaPijacaTelefon").appendChild(l);


        }
    }
}