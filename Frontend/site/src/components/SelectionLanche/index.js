import React from 'react';
import { AiOutlineMinusCircle, AiOutlinePlusCircle } from 'react-icons/ai';
import { PageDefault, ImageWrapper, TitleWrapper, DescWrapper, InfoWrapper, ButtonWrapper, Button, P } from './style';

let a = 0;

function Add() {
    a++;
    document.getElementById("demo").innerText = a;
}

function Remove() {

  if(a > 0){
        a--;
        document.getElementById("demo").innerHTML = a;
   }else{
        let b = 'Sua quantia deve ser maior que 0 para remover'
   	    document.getElementById("demo").innerHTML = b;
   }

}	  

export default function SelectSnack(props) {
    return(

        <PageDefault>

            <ImageWrapper>

                <img src={props.imagem} alt="" width='270px' height='160px'/>

            </ImageWrapper>

            <InfoWrapper>

                <TitleWrapper>

                    <span>{props.title}</span>

                </TitleWrapper>
            
                <DescWrapper>

                    <span>peso:{props.peso}</span>
                    <span>sabor:{props.sabor}</span>
                    <span>preco:{props.preco}</span>

                </DescWrapper>

                <ButtonWrapper>
                    
                    <Button onClick = {Remove}>
                        <AiOutlineMinusCircle size='5vh' cursor='pointer' />
                    </Button>

                    <P id="demo"></P>

                    <Button onClick = {Add}>
                        <AiOutlinePlusCircle size= '5vh' cursor='pointer'/>
                    </Button>

                    <span>Preço:{props.preco} </span>                    

                </ButtonWrapper>

            </InfoWrapper>

        </PageDefault>
    );
}