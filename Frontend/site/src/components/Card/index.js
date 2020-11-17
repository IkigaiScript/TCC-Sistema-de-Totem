import React from 'react'
import {PageDefault,Header,InfoWrapper, Video, Span, ImgFilme} from './style'

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
                <p style = {{'font-size': '18px'}}>{props.sinopse}</p>

            </InfoWrapper>

        </PageDefault>
    );
}