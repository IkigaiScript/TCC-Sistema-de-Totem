import styled from 'styled-components';
import DinheiroFundo from '../../../assets/Img/DinheiroFundo.jpg';

export const PageDefault = styled.div`
    display: flex;
    flex-direction: column; 
    min-height:100vh;
    width:100vw;
    background-image:url(${DinheiroFundo});
    background-size:cover;

    align-items: center;

    align-items:center;
    justify-content:center;
`;

export const TextWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 60vw;
    height:35vh;

    margin-left:auto;
    margin-right:auto;
    margin-top: 30px;

    color:white;

    @media(max-width: 800px){
        height:40vh;
        width:90vw;

        overflow-y:auto;
    }
`;

export const ButtonWrapper =styled.div`
    display:flex;
    height:20vh;
    width:70vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    margin-top:20px;
`;