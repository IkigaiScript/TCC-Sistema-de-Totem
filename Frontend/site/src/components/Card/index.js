import React from 'react'
import {PageDefault,Header,InfoWrapper,FilmeWrapper, Video, Span, ImgFilme, Custom} from './style'

export default function Card(props){
    return(
        <PageDefault>
            <Header>

                <Video controls>
                    <source src = {props.trailer} type = 'vide/mp4'  />
                </Video>
            
            </Header>

            <ImgFilme>

                <img src = {props.image} alt = '' height= '120px' width = '100px'/>
                <Span>{props.nome}</Span>

            </ImgFilme>

            <InfoWrapper>

                <span>Sinopse</span>
                <p>{props.sinopse}</p>

            </InfoWrapper>

            
            <FilmeWrapper>

                <Custom>
                    <span>Sessão</span>
                   

                </Custom>

                <Custom>

                    <span>Sala</span>

                </Custom>

            </FilmeWrapper>

        </PageDefault>
    );
}