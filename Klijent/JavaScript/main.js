import { Pijaca } from "./Pijaca.js";
import { Sajt } from "./Sajt.js";

var listaPijaca = [];

// fetch("https://localhost:5001/Pijaca/PreuzmiPijace")
// .then(p=>{
//     p.json().then(pijace=>{
//         pijace.forEach(pijaca=>{

//             var p = new Pijaca(pijaca.naziv, pijaca.lokacija, pijaca.telefon);
//             listaPijaca.push(p);
//         });
//     })
    var s = new Sajt(listaPijaca);
    s.crtaj(document.body);

    // var ss = new Sajt(listaPijaca);
    // ss.crtaj(document.body);
// })

// console.log(listaPijaca);


// var s = new Sajt(listaPijaca);
// s.crtaj(document.body);

// var ss = new Sajt(listaPijaca);
// ss.crtaj(document.body);