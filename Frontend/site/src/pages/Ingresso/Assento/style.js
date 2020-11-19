import styled from 'styled-components';
import AssentoFundo from '../../../assets/Img/AssentoFundo.jpg';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    max-width:100vw;    
    background-image:url(${AssentoFundo});
    background-size:cover;

    align-items:center;
    justify-content:center;
`;

export const SalaWrapper = styled.div`
    display:flex;
    height:15vh;
    width:90vw;

    margin-left:auto;
    margin-right:auto;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    @media(max-width: 800px){
        height:25vh;
        flex-direction:column;
    } 
`;

export const Assento = styled.div`
    display:flex;
    flex-direction:column;
    height:80vh;
    width:90vw;
    background:radial-gradient(white,black);

    margin-left:auto;
    margin-right:auto;
    margin-bottom:15px;

    align-items:center;
    justify-content:center;

    border:1px solid black;
    border-radius:5px;

    >span{
        font-size:15pt;
        margin-top:10px;
    }

    
`;

export const Select = styled.select`
    height:5vh;
    min-width:20vw;

    box-sizing:border-box;
    padding-left:10px;
    padding-right:15px;

    border-radius:15px;
`;