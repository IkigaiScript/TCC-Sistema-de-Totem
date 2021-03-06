import React, { useState } from 'react';
import { AiOutlineMinusCircle, AiOutlinePlusCircle } from 'react-icons/ai';
import { PageDefault, Img, DescWrapper, InfoWrapper, ButtonWrapper, Button, P, Text } from './style';
import bebida from '../../assets/Img/Pipoca.png'


export default function SelectSnack(props) {
    
    const [ped] = useState(window.localStorage.getItem('pedido'));
    const [cont,setCont] = useState(0);
    const [qtd,setQtd] = useState(props.qtd);
    window.localStorage.setItem(`id ${props.id}`,cont);

    function Add(){
        setQtd(qtd + 1);
        setCont(cont + 1);
    }
    
    function Remove(){
      if(cont <= 0){
        setCont(0);
      }
      else{
        setQtd(qtd - 1);
        setCont(cont - 1);
      }
    }	  

    return(
        <PageDefault>

            <div>
                <Img src={bebida} alt="" />
            </div>

            <InfoWrapper>
                
                <h3>{props.title}</h3>
                
            
                <DescWrapper>

                    <span>peso:{props.peso}</span>
                    <span>sabor:{props.sabor}</span>
            
                </DescWrapper>

                <ButtonWrapper>
                    
                    <Button onClick = {Remove}>
                        <AiOutlineMinusCircle size='5vh' cursor='pointer' />
                    </Button>

                    <P>{qtd}</P>

                    <Button onClick = {Add}>
                        <AiOutlinePlusCircle size= '5vh' cursor='pointer'/>
                    </Button>

                    <Text>Preço:{props.preco} </Text>                    

                </ButtonWrapper>

            </InfoWrapper>

        </PageDefault>
    );
}