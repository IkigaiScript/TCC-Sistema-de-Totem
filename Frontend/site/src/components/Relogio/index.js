import React from 'react'
import {PageDefault, Span} from './style'

setInterval(function(){
    
    let novaHora = new Date();
    
    // getHours trará a hora

    // geMinutes trará os minutos

    
    let hora = novaHora.getHours();
    let minuto = novaHora.getMinutes();
    
    // Chamamos a função zero para que ela retorne a concatenação

    // com os minutos 

    minuto = zero(minuto);

    // Com o textContent, iremos inserir as horas, minutos 
    // no nosso elemento HTML
    console.log(minuto)

    document.getElementsByClassName('hora')[0].textContent = hora+':'+minuto;
},1000)


// A function zero concatena a string (número) 0 em frente aos números

// mantendo o zero na frente dos números menores que 10. Exemplo:

// 21:05

// 21:05

// e assim, sucessivamente

function zero(x) {
    if (x < 10) {
        x = '0' + x;
    } return x;
}

export default function Relogio() {
    return(
        <PageDefault>
            <Span className = 'hora'></Span>
        </PageDefault>
    )
}