import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom';
import { PageDefault, FilmeWrapper, Video, InfoWrapper, Img, Custom, ImgCont, Span, ButtonWrapper } from './style';
import Relogio from '../../../components/Relogio/';
import Button from '../../../components/Buttons';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Filme } from '../../../services/FilmeApi';
import { GetPhoto } from '../../../services/GetPhotoApi'

const getPhoto = new GetPhoto();
const filme = new Filme();

export default function InfoFilme (props){

    const [id] = useState(props.location.state);
    const [nome,setNome] = useState('');
    const [sinopse,setSinopse] = useState('');
    const [imagem,setImagem] = useState('');
    const [breve,setBreve] = useState(false);
    const [classificacao,setClassificacao] = useState(0);
    const [duracao,setDuracao] = useState(0);
    const [diretores,setDiretores] = useState([]);
    const [atores,setAtores] =  useState([]);
    const [sessoes,setSessoes] = useState([]);
    const [estreia,setEstreia] = useState(false);

    async function consultFilme(){
        try{
            const response = await filme.consultUni(id);
            console.log(response.sessoes);
            setEstreia(response.estreia);
            setDuracao(response.duracao);
            setClassificacao(response.classificacao);
            setBreve(response.breve);
            setAtores(response.atores);
            setDiretores(response.diretores);
            setNome(response.nome);
            setSinopse(response.sinopse);
            setImagem(response.imagem);
            setSessoes(response.sessoes);
        }
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    useEffect(() => {
        consultFilme();
    })

    return (
        <PageDefault> 

            <FilmeWrapper>

                
                <Video controls>
                    <source src = '' type = 'vide/mp4' />
                </Video>

                <ImgCont>

                    {/* <Img src = {getPhoto.getPhoto(imagem)} alt = ''  height = '200' width = '200'/> */}
                    <Span>{nome}</Span>

                </ImgCont>

                <InfoWrapper>
                    <span>Sinopse</span>
                    <span>{sinopse}</span> 
                </InfoWrapper>
                
                {atores.map(x => 
                        <>
                            <span>{x.nome}</span>
                        </>)}

                {diretores.map(x => 
                        <>
                            <span>{x.nome}</span>
                        </>)}

                {sessoes.map(x => 
                        <>
                            <span>{x.valor}</span>
                            <span>{x.tipoSala}</span>
                            <span>{x.horario}</span>
                            <span>{x.sala}</span>                            
                        </>)}
                        
                <ButtonWrapper>

                    <Button 
                        as = { Link }
                        to = '/compra/assento'
                        children = 'Comprar ingressos'
                    />

                    <Relogio />

                    <Button 
                        to = '/'
                        children = 'voltar'
                    />

                </ButtonWrapper>

            </FilmeWrapper>
            <ToastContainer/>
        </PageDefault>
    );
}