import styled from 'styled-components';

export const Container = styled.div`

display: flex;
flex-direction: row;
justify-content: left;
align-items: center;
margin-bottom: 10px;
width: 400px;
border: 2px solid black;
height: 80px;
background-color: white;
color: black;
`;

export const ContainerImage = styled.div`

display: flex;
float: left;
justify-content: left; 
margin-right: 20px;
width: 70px;
height: 80px;
flex-direction: row;
border: 0.5px solid black;
`;

export const ContainerTitle = styled.div`

display: flex;
flex-direction: row;
width: 250;
height: 80px;
justify-content: center;
align-items: center;
`;

export const TitleFilme = styled.h1`

color: black;
`;