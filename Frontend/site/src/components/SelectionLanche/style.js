import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    flex-direction: row;
    height: 30vh;
    width: 35vw;

    justify-content: left;
   
    padding-top: 10px;
    padding-left: 10px;
    margin-bottom: 10px;
    margin-left:40px;
    border: 2px solid  black;
   
    background-color: white;
    color: black;
`;

export const ContainerImage = styled.div`
    display: flex;
    flex-direction: column;
    height: 150px;
    width: 20vw;
    
    align-items: center;
    justify-content: center; 

    margin-top:auto;
    margin-bottom:auto;
    margin-right: 15px;

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
    width: 20vw;
    height: 30px;

    align-items: center;
    justify-content: center;
    
    margin-bottom: 10px;
    margin-left:auto;
    margin-right:auto;
`;

export const ContainerDescLanche = styled.div`
    display: flex;
    flex-direction: column;
    width: 20vw;
    height: 30vh;

    padding-right:10px;
    padding-left:10px;
    margin-right:5px;
    border: 1px solid black;
`;

export const ContainerBottom = styled.div`
    display: flex;
    flex-direction: row;
    height: 15vh;
    width: 20vw;

    align-items: center;
    justify-content:space-evenly;

    margin-top: 10px;
`;

export const Button = styled.button`
    border:0;
    background:white;

    :hover{
        border:0;
        background:white;
    }
`;

export const Input = styled.input`
    height:5vh;
    width:5vw;
`;