import React from 'react';
import {PagesDefault, Titulo, Hr, Opcao, Img, LancheWrapper} from './style';
import Combo from '../../../assets/Img/Combo.jpg';
import Pipoca from '../../../assets/Img/Pipoca.png';
import Bebida from '../../../assets/Img/Bebida.png';
import Doce from '../../../assets/Img/Doce.png';
import Button from '../../../components/Buttons';

export default function OqueDesejaComer() {
    return (
         <PagesDefault>

            <Titulo><u>O que deseja comer?</u></Titulo>

            <LancheWrapper>

                <Img src= {Combo} alt="Combo"  width="150px"  height= '110px'/>
                <Opcao>Combo</Opcao>

            </LancheWrapper>

            <Hr></Hr>

            <LancheWrapper>

                <Img src= {Pipoca} alt="Pipoca" width="150px" height="110px"/>
                <Opcao>Pipoca</Opcao>

            </LancheWrapper>

            <Hr></Hr> 

            <LancheWrapper>

                <Img src= {Bebida} alt="Bebida" width="150px" height="110px"/>
                <Opcao>Bebida</Opcao>

            </LancheWrapper>

            <Hr></Hr> 

            <LancheWrapper>

                <Img src= {Doce} alt="Doce" width="150px" height="110px"/>
                <Opcao>Doce</Opcao>

            </LancheWrapper>      

            <Hr></Hr>

            <Button children = 'Voltar' />
         </PagesDefault>
    );
}