import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    flex-direction: row;
    width: 90vw;
    height: 17vh;

    justify-content: left;
    align-items: center;

    border: 2px solid black;
    margin-bottom: 10px;
    margin-left:auto;
    margin-right:auto;
   
    background-color: white;
    color: black;
`;

export const ContainerImage = styled.div`
    display: flex;
    flex-direction: row;
    height:100%;
    width: 10%;

    float: left;
    justify-content: left; 
    margin-left: 20px;
`;

export const ContainerTitle = styled.div`
    display: flex;
    flex-direction: column;
    width: 80%;
    height: 80px;

    justify-content: center;
    align-items: center;
`;

export const Title = styled.span`
    text-align:center;
    text-decoration:underline;
    
    font-size:50px;
    font-style:oblique;
    font-weight:400;

    letter-spacing:2px;
`;