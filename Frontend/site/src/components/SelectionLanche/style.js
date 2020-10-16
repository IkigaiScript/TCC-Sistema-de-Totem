import styled from 'styled-components';

export const Container = styled.div`

display: flex;
flex-direction: row;
justify-content: left;
padding-top: 10px;
padding-left: 10px;
margin-bottom: 10px;
width: 450px;
border: 2px solid black;
height: 170px;
background-color: white;
color: black;
`;

export const ContainerImage = styled.div`

display: flex;
align-items: center;
flex-direction: column;
justify-content: center; 
margin-right: 15px;
width: 90px;
height: 150px;
flex-direction: row;
border: 1px solid black;
`;

export const SubContainer = styled.div`

display: flex;
flex-direction: column;
width: 335px;
height: 170px;
`;


export const ContainerTitleLanche = styled.div`

display: flex;
flex-direction: column;
width: 330px;
height: 30px;
margin-bottom: 10px;
justify-content: center;
align-items: center;
border: 1px solid black;
`;

export const ContainerDescLanche = styled.div`

display: flex;
flex-direction: column;
width: 330px;
height: 75px;
border: 1px solid black;
`;

export const ContainerBottom = styled.div`

display: flex;
flex-direction: row;
align-items: center;
width: 250px;
margin-top: 10px;
padding-left: 80px;
height: 38px;
border: 1px solid black;
`;