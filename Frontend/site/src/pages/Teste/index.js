import React from 'react';
import Button from '../../components/Buttons';
import SelectFilme from '../../components/SelectionFilme';
import SelectLanche from '../../components/SelectionLanche';
import Doce from '../../assets/Img/Doce.png';
import Card from '../../components/Card';
import Relogio from '../../components/Relogio';


export default function Teste (){
    return(
        <div>
            <Button children = 'Voltar' />

            <SelectFilme 
                imagem = {Doce}
                desc = 'Doce sdsddsfdfsdfsdfsdfsdfsdfsdfdsfsdfsdf'
                name = 'Feiticieira do doce'
            />

            <SelectLanche 
                name = {Doce}
                title = 'Especial de Filme'
                desc = 'pipoca Grande,Refrigerante Medio,Nachos e M&M'
                preco = 'R$ 100,00'
            />
            <SelectLanche 
                name = {Doce}
                title = 'Especial de Filme'
                desc = 'pipoca Grande,Refrigerante Medio,Nachos e M&M'
                preco = 'R$ 100,00'
            />
            

            <Card />

            <Relogio />

            
        </div>
    );
}