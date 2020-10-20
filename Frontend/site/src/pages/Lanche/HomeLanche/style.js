import styled from 'styled-components'

export const PagesDefault = styled.div`
   padding: 0px;
   margin: 0px;


   >Button{
   margin-left: 80px;
   }
`;

//Titulo

export const Titulo = styled.h1`
   text-align: center;
   font-size: 50px;
   font-family: Arial;
   

`;

// Todos os hr (linhas)

export const Hr = styled.hr`
  width: 90%;
  margin-left:auto;
  margin-right:auto;
`;

//Titulo das opções

export const Opcao =  styled.p`
   font-size: 30pt;
   font-family: Arial;
   margin-left: 4%;
   margin-top: 3%;
   cursor:pointer;

`;

//Imagem das opções
 
export const Img = styled.img`
   height:115px;
   width:155px;
   border:1px solid black;
   border-radius:100%;
   margin-left:20vh;
`;

//Container das opções

export const LancheWrapper = styled.div`
   display:flex;
   margin-top:5px;
   margin-bottom:5px;

   :hover{
      background:green;
      color:white;
   }
`;