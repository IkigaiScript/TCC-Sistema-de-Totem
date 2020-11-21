import styled from 'styled-components';
import CineTotem from '../../../assets/Img/CineTotem.jpg'

export const PageDefault = styled.div`
    display: flex;
    flex-direction: column;
    min-height: 100vh;
    min-width:100vw;
    background-image:url(${CineTotem});
    background-size:cover;

    justify-content: center;
    align-items: center;
`;

export const TextLogin = styled.div`
    display:flex;
    height:35vh;
    width:50vw;

    align-items:center;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;  

    @media(max-width: 800px){
        flex-direction:column;
    }
`;

export const Custom = styled.div`
    display: flex;
    flex-direction: column;
    height:15vh;
    width:70vw;

    margin-left: auto;
    margin-right: auto;
    margin-top:15px;

    align-items:center;

    @media(max-width: 800px){
        >input{
            width:80vw;
        }
    }
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:70vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    box-sizing:border-box;
    padding:15px;

    @media(max-width:800px){
        height:40vh;
        flex-direction:column;
    }
`;
