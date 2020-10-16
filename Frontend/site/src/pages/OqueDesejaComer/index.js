import React from 'react';
import {PagesDefault, Titulo, ImgCombo, ParteCombo, TituloCombo, PartePipoca, 
ImgPipoca, TituloPipoca, ParteBebida, ImgBebida, TituloBebida, ParteDoce, ImgDoce, TituloDoce, Hr, BtnVoltar} from './style'
import Combo from '../../assets/Img/Combo.jpg'
import Pipoca from '../../assets/Img/Pipoca.png'
import Bebida from '../../assets/Img/Bebida.png'
import Doce from '../../assets/Img/Doce.png'
import Button from '../../components/Buttons';


export default function OqueDesejaComer() {
    return (
         <PagesDefault>
            <Titulo><u>O que deseja comer?</u></Titulo>
            <ParteCombo>
                <ImgCombo src= {Combo} alt="Combo" width="170px"/>
                <TituloCombo>Combo</TituloCombo>
            </ParteCombo>
                <Hr></Hr>
            <PartePipoca>
                <ImgPipoca src= {Pipoca} alt="Pipoca" width="150px" height="120px"/>
                <TituloPipoca>Pipoca</TituloPipoca>
            </PartePipoca>
                <Hr></Hr> 
            <ParteBebida>
                 <ImgBebida src= {Bebida} alt="Bebida" width="200px" height="130px"/>
                 <TituloBebida>Bebida</TituloBebida>
            </ParteBebida>
                <Hr></Hr> 
            <ParteDoce>
                <ImgDoce src= {Doce} alt="Doce" width="170px" height="130px"/>
                <TituloDoce>Doce</TituloDoce>
            </ParteDoce>      
               <Hr></Hr>
               <Button>Voltar</Button>
         </PagesDefault>
    );
}