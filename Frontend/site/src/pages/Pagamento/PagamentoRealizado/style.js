import styled from "styled-components";

//Container
export const PagesDefault = styled.div`
  display:flex;
  flex-direction:column;  
  min-height:100%;
  background-color: #00a000;
`;

//Imagem
export const Img = styled.img`
  margin-top:30px;
  margin-left:40%;
    
  @media(max-width:800px){
    margin-left:10%;
  }
`;

//Subtitulo
export const SubTitle = styled.p`
  text-align:center;
  
  font-family: Arial;
  font-size: 20pt;
  
  color: white;
`;  
