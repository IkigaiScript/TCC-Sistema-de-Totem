import React from 'react';
import {PagesDefault, Titulo, Hr, Opcao, Img, LancheWrapper} from './style';
import {Link} from 'react-router-dom';
import Combo from '../../../assets/Img/Combo.jpg';
import Pipoca from '../../../assets/Img/Pipoca.png';
import Bebida from '../../../assets/Img/Bebida.png';
import Doce from '../../../assets/Img/Doce.png';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio';

export default function OqueDesejaComer() {
    return (
         <PagesDefault>

            <Titulo><u>O que deseja comer?</u></Titulo>

            <Link to = '/compra/lanche/combo'>
                <LancheWrapper>
                    <Img src= {Combo} alt="Combo"  width="150px"  height= '110px'/>

                    <Opcao>Combo</Opcao>
                </LancheWrapper>
            </Link>

            <Hr></Hr>

            <Link to = '/compra/lanche/pipoca'>

                <LancheWrapper>

                    <Img src= {Pipoca} alt="Pipoca" width="150px" height="110px"/>
                    <Opcao>Pipoca</Opcao>
                    
                </LancheWrapper>

            </Link>

            <Hr></Hr> 

            <Link to = '/compra/lanche/bebida'>
                <LancheWrapper>
                    <Img src= {Bebida} alt="Bebida" width="150px" height="110px"/>
                   
                    <Opcao>Bebida</Opcao>
                </LancheWrapper>
            </Link>

            <Hr></Hr> 

            <Link to = '/compra/lanche/doces'>
                <LancheWrapper>
                    <Img src= {Doce} alt="Doce" width="150px" height="110px"/>
                  
                    <Opcao>Doce</Opcao>
                </LancheWrapper>  
            </Link>  

            <Hr></Hr>
            
            <Button children = 'Voltar' />
        
            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>
         </PagesDefault>
    );
}