import React from 'react';
import { AiOutlineMinusCircle, AiOutlinePlusCircle } from 'react-icons/ai';
import { Container, ContainerImage, ContainerTitleLanche, ContainerDescLanche, SubContainer, ContainerBottom, Button, P } from './style';

let a = 0;

function Adicionar() {
    a++;
    document.getElementById("demo").innerText = a;
}

function Remover() {

  if(a > 0){
        a--;
        document.getElementById("demo").innerHTML = a;
   }else{
        let b = 'Sua quantia deve ser maior que 0 para remover'
   	    document.getElementById("demo").innerHTML = b;
   }

}
	  

export default function SelectLanche(props) {
    return(
        <Container>

            <ContainerImage>

                <img src={props.imagem} alt="" width='270px' height='160px'/>

            </ContainerImage>

            <SubContainer>

                <ContainerTitleLanche>

                    <span>{props.title}</span>

                </ContainerTitleLanche>
            
                <ContainerDescLanche>

                    <span>peso:{props.peso}</span>
                    <span>sabor:{props.sabor}</span>
                    <span>preco:{props.preco}</span>

                </ContainerDescLanche>

                <ContainerBottom>
                    
                    <Button onClick = {Remover}>
                        <AiOutlineMinusCircle size='5vh' cursor='pointer' />
                    </Button>

                    <P id="demo"></P>

                    <Button onClick = {Adicionar}>
                        <AiOutlinePlusCircle size= '5vh' cursor='pointer'/>
                    </Button>

                    <span>Preço:{props.preco} </span>                    

                </ContainerBottom>

            </SubContainer>

        </Container>
    )
}