import React, { useState, useEffect } from 'react'
import {PageDefault, FilmeWrapper, Video, InfoWrapper, Img, Custom, ImgCont, Span, ButtonWrapper} from './style';
import Relogio from '../../../components/Relogio/';
import Button from '../../../components/Buttons';

import Sessao from  '../../../services/SessaoApi';
import Filme from '../../../services/FilmeApi';

const filme = new Filme();
const api = new Sessao();

export default function InfoFilme (props){

    const [nome] = useState(props.location.state.nome);
    const [sinopse] = useState(props.location.state.sinopse);
    const [imagem] = useState(props.location.state.imagem)

    const [diretor] = useState();
    const [ator] =  useState();
    const [sessao] = useState();

    const getSessao =  async () => {
        try{
            const resp = await api.get(props.location.state.id);
            return resp;
        }catch(e){
            console.error('deu ruim')
        }
    }

    useEffect(() => {
        console.log("Hello world");
        getSessao();    
    })

    return (
        <PageDefault> 

            <FilmeWrapper>

                
                <Video controls>
                    <source src = '' type = 'vide/mp4' />
                </Video>

                <ImgCont>

                    <Img src = {filme.getPhoto(imagem)} alt = ''  height = '200' width = '200'/>
                    <Span>{nome}</Span>


                </ImgCont>

                <InfoWrapper>
                    <span>Sninopse</span>
                    <span>{sinopse}</span> 
                </InfoWrapper>
                {sessao.map(x => 
                        <>    
                            <InfoWrapper>
                                <span>Sobre o Filme </span>
                                <span>{x.ator}</span>          
                                <span>{x.diretor}</span>
                            </InfoWrapper>

                            <Custom>

                                <span>Sessão</span>
                                <span>{x.sessoes}</span>

                            </Custom>

                            <Custom>
                                <span>Sala</span>
                            </Custom>
                            
                        </>
                    )} 
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