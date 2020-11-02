import React from 'react'
import {PageDefault, FilmeWrapper, Video, InfoWrapper, Img, Custom, ImgCont, Span, ButtonWrapper} from './style';
import Relogio from '../../../components/Relogio/';
import Button from '../../../components/Buttons';

export default function Filme (){
    return (
        <PageDefault> 

            <FilmeWrapper>

                
                <Video controls>
                    <source src = '' type = 'vide/mp4' />
                </Video>

                <ImgCont>

                    <Img src = '' alt = ''  height = '200' width = '200'/>

                    
                    <Span>Investigação sobre um cidadao acima de qualquer suspeita</Span>

                </ImgCont>

                <InfoWrapper>
                    <span>Sninopse</span>
                </InfoWrapper>

                <InfoWrapper>
                    <span>Sobre o Filme </span>

                    
                </InfoWrapper>

                <Custom>
                    <span>Sessão</span>

                </Custom>

                <Custom>
                    <span>Sala</span>
                </Custom>

                <ButtonWrapper>

                    <Button 
                        to = '/compra/assento'
                        children = 'Comprar ingressos'
                    />

                    <Relogio />

                    <Button 
                        to = '/sessaofilme'
                        children = 'voltar'
                    />

                </ButtonWrapper>

            </FilmeWrapper>


        </PageDefault>
    );
}