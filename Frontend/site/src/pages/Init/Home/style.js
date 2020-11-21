import styled from 'styled-components';
import HomeFundo from '../../../assets/Img/HomeFundo.jpg';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100%;
    width:100vw;
    background-image:url(${HomeFundo});
    background-size:cover;

    box-sizing:border-box;
    padding-left:15px;
    padding-right:15px;


`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:90%;

    align-items:center;
    justify-content:center;
    justify-content:space-between;

    margin-left:auto;
    margin-right:auto;

    @media(max-width: 800px){
        justify-content:space-evenly;
    }
`;

export const Menu = styled.div`
    display:flex;
    height:15vh;
    width:95vw;

    justify-content:space-between;    
    align-items:center;

    box-sizing:border-box;
    padding-left:10px;
    padding-right:10px;
    margin-bottom:10px;
    margin-left:auto;
    margin-right:auto;
    border-bottom:1px solid whitesmoke;
    
`;

export const Span = styled.span`
    text-decoration:none;
    font-size:25px;
    font-weight:400;

    color:white;

    margin-right:20px;

    &:hover{    
        text-decoration:none;
    }
`;