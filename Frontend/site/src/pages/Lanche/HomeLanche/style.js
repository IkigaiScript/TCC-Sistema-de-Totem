import styled from 'styled-components';
import HomeLancheFundo from '../../../assets/Img/HomeLancheFundo.jpg';

export const PagesDefault = styled.div`
   display:flex;
   flex-direction:column;
   min-height:100vh;
   width:100vw;
   background-image:url(${HomeLancheFundo});
   background-size:cover;

   padding: 0px;
   margin: 0px;

`;

//Titulo

export const Titulo = styled.h1`
   text-align: center;

   font-size: 50px;
`;

// Todos os hr (linhas)

export const Hr = styled.hr`
  width: 90%;

  margin-left:auto;
  margin-right:auto;
`;

//Titulo das opções

export const Opcao =  styled.p`
text-decoration:underline;
   font-size: 30pt;
   color:white;

   margin-left: 4%;
   cursor:pointer;
`;

//Imagem das opções
 
export const Img = styled.img`
   height:115px;
   width:155px;
   background:white;

   border:1px solid black;
   border-radius:100%;
`;

//Container das opções

export const LancheWrapper = styled.div`
   display:flex;
   height:fit-content();
   width:100vw;

   align-items:center;

   box-sizing:border-box;
   padding-left:10vw;
   margin-top:5px;
   margin-bottom:5px;

   @media(max-width: 800px){
      flex-direction:column;
   }
   
   :hover{
      width:90vw;
      background:rgba(25%, 35%, 40%, 0.8);

      border-radius:8px;

      padding-left:5vw;
      margin-left:auto;
      margin-right:auto;
      >p {color:white;};
   }

   
`;