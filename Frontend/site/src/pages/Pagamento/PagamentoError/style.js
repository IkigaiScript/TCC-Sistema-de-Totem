import styled from "styled-components";

//Container
export const PagesDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100%;
    max-width:100vw;
    background-color: #C00;
`;

//Imagem
export const Img = styled.img`
    margin-top:30px;
    margin-left:37%;

    @media(max-width: 800px){
        margin-left:10%;
    }
`;

//SubTitulo
export const SubTitle = styled.p`
    color: white;
    font-family: Arial;
    font-size: 20pt;
    text-align:center;
    margin-top: 80px;
`;