import styled from 'styled-components';
import DoceFundo from '../../../assets/Img/DoceFundo.jpg'

export const PagesDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;
    background-image:url(${DoceFundo});
    background-size:cover;

    align-items:center;
    justify-content:center;
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:10vh;
    width:70vw;
    box-sizing:border-box;
    margin-left:auto;
    margin-right:auto;
    margin:20px;

    align-items:center;
    justify-content:space-between;

    @media(max-width: 800px){
        margin:0;
        height:30vh;
        flex-wrap:wrap;
        width:100vw;

        justify-content:space-evenly;
    }
`;

export const Custom = styled.div`
    display:flex;
    height:fit-content;
    width: 80vw;

    box-sizing:border-box;
    padding:10px;
    margin-left:auto;
    margin-right:auto;

    @media(max-width: 800px){
        flex-direction:column;
        padding:0;
    }
`;

export const OptionWrapper = styled.div`
     display:flex;
    flex-direction:row;
    min-height:100vh;
    width:60vw;
    align-items:center;

    flex-wrap:wrap;
    box-sizing:border-box;
    margin-left:auto;
    margin-right:auto;


    @media(max-width: 800px)
    {
        padding-left:10px;
        width:91vw;
    }
`;

export const Select = styled.select`
    height:6vh;
    width:15vw;
    background:#1874CD;
    
    justify-items:center;
    align-items:center;

    box-sizing:border-box;
    padding:5px;
    
    border-radius:10px;
    border:0.1em solid black ;
    
    color:white;
    font-size:15pt;
    letter-spacing:3px;
`;

export const H1 = styled.h1`
    font-size:40pt;
    font-weight:bold;
    text-decoration:none;
    
    margin-top:20px;
    margin-bottom:55px;

    @media(max-width: 800px)
    {
        margin-bottom:10px;    
    }

    &:hover{
        text-decoration:underline;
        text-decoration-color:white;
    }
`;

export const Option = styled.option`
    padding:15px;
    background:white;

    color:black;
    font-size:18pt;
`;
