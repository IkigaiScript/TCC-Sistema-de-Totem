import styled from 'styled-components';
import InfoFilme from '../../../assets/Img/InfoFilme.jpg'

export const PageDefault = styled.div` 
    display: flex;
    flex-direction: column;
    min-height:100vh;
    max-width:100vw;
    background-image:url(${InfoFilme});
    background-size:cover;

    align-items:center;
    justify-content:center;

    box-sizing:border-box;
    padding:15px;

    font-size:15pt;
`;

export const FilmeWrapper =  styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:80vw;
    background:whitesmoke;

    margin-left:auto;
    margin-right:auto;

    border:1px solid black;
    border-radius:16px;

`;

export const Video = styled.video`
    height:40vh;
    width:100%;

    border:2px solid black;

    border-top-right-radius:16px;
    border-top-left-radius:16px;

`;

export const InfoWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:30vh;
    width:75vw;

    box-sizing:border-box;
    padding:16px;
    margin-left:auto;
    margin-right:auto;
    margin-top:15px;

    border:1px solid black;

    overflow-y:auto;
`;

export const Custom = styled.div`
    display:flex;
    height:15vh;
    width:75vw;

    box-sizing:border-box;
    padding:10px;
    margin-left:auto;
    margin-right:auto;
    margin-top:10px;
    margin-bottom:5px;

    border:1px solid black;

    overflow-y:auto;
`;

export const Img = styled.img`
    height:200px;
    width:200px;

    border-radius:10px;
    margin-left:20px;
`;

export const ImgCont = styled.div`
    display:flex;
    height:30vh;
    width:75vw;

    margin-left:auto;
    margin-right:auto;
    margin-top:10px;
    
    align-items:center;
    
    text-align:center;
    font-size:20px;
    color:black;
    
`;

export const Span = styled.span`
    text-align:center;

    font-size:20pt;
    margin-left:auto;
    margin-right:auto;

`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:70vw;
    background:whitesmoke;

    margin-left:auto;
    margin-right:auto;

    align-items:center;
    justify-content:center;
    justify-content:space-around;
`;

export const InfoSessao = styled.div`
    display:flex;
    height:5vh;
    width:70vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    box-sizing:border-box;
    padding-left:10px;
    padding-right:10px;
    margin-right:auto;
`;

