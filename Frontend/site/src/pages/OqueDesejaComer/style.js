import styled from 'styled-components'
import Button from '../../components/Buttons';


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

//Parte do Combo

export const ParteCombo = styled.div`
 flex-direction: row;
 display: flex;
`;

export const ImgCombo = styled.img`
 margin-left: 8%;
`;


export const TituloCombo = styled.p`
  font-size: 25pt;
  font-family: Arial;
  margin-left: 2.5%;
  margin-top: 4%;
  cursor:pointer;
`;


//Parte da Pipoca

export const PartePipoca = styled.div`
   flex-direction: row;
   display:flex;
`;

export const ImgPipoca = styled.img`
   margin-left: 8%;
`;

export const TituloPipoca = styled.p`
  font-size: 25pt;
  font-family: Arial;
  margin-left: 4%;
  margin-top: 3%;
  cursor:pointer;
`;

// Parte de Bebida

export const ParteBebida = styled.div`
   flex-direction: row;
   display:flex;

`;

export const ImgBebida = styled.img`
   margin-left: 5.5%;
`;

export const TituloBebida = styled.p`
    font-size: 25pt;
    font-family: Arial;
    margin-left: 3%;
    margin-top: 3%;
    cursor:pointer;
`;


//Parte de Doce

export const ParteDoce = styled.div`
    flex-direction: row;
    display:flex;
`;

export const ImgDoce = styled.img` 
    margin-left: 6%;
`;

export const TituloDoce = styled.p`
    font-size: 25pt;
    font-family: Arial;
    margin-left: 4%;
    margin-top: 3%;
    cursor:pointer;
`;

// Todos os hr (linhas)

export const Hr = styled.hr`
  width: 95%;
`;

