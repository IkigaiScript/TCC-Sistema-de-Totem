import React from 'react'
import { Wrapper, FilmeWrapper, SinopseWrapper, InfoWrapper, ImgWrapper, SessaoWrapper, SalaWrapper, TitleWrapper, Rodape } from './style';
import Relogio from '../../../components/Relogio/';
import Button from '../../../components/Buttons/';

export default function Filme (){
    return (
        <Wrapper>
            <div>
                <video width="400" controls>
                    <source src="" type="video/mp4" />
                </video>
            </div>

            <FilmeWrapper>
                <ImgWrapper>
                    <img src="" alt="" height = '95px' width = '90px' />
                </ImgWrapper>

                <TitleWrapper>
                    <h2>Filme</h2>    
                </TitleWrapper>
            </FilmeWrapper>

            <SinopseWrapper>
                <h2>Sinopse</h2>
                    <br />
                <p>Sinopse do Filme</p>
            </SinopseWrapper>

            <InfoWrapper>
                <h2>Informações do Filme</h2>
                <p>Infos</p>
            </InfoWrapper>

            <SessaoWrapper>
                <h4>Sessão</h4>
            </SessaoWrapper>

            <SalaWrapper>
                <h4>Sala</h4>
            </SalaWrapper>

            <Rodape>
                <Button to="/" children="Comprar Ingresso" />
                <Relogio />
            </Rodape>
        </Wrapper>
    );
}