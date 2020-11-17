import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    flex-direction: row;
    height: 30vh;
    width: 85vw;

    justify-content: left;
   
    padding-top: 10px;
    padding-left: 10px;
    margin-bottom: 10px;
    margin-left:40px;
    border: 2px solid  black;
   
    background-color: white;
    color: black;

    @media(max-width: 800px){
        width:80vw;
        margin-left:0;
    }
`;

export const ContainerImage = styled.div`
    display: flex;
    flex-direction: column;
    height: 160px;
    width: 20vw;
    
    align-items: center;
    justify-content: center; 

    margin-top:auto;
    margin-bottom:auto;
    margin-right: 15px;

    border:1px solid purple;

`;

export const SubContainer = styled.div`
    display: flex;
    flex-direction: column;
    width: 60vw;
    height: 170px;

    align-items:center;
    justify-content:center;

`;


export const ContainerTitleLanche = styled.div`
    display: flex;
    flex-direction: column;
    width: 20vw;
    height: 70px;

    align-items: center;
    justify-content: center;
    
    margin-bottom: 5px;
    margin-left:auto;
    margin-right:auto;
`;

export const ContainerDescLanche = styled.div`
    display: flex;
    flex-direction: column;
    width: 55vw;
    height: 20vh;

    padding-right:10px;
    padding-left:10px;
    margin-right:5px;
    border: 1px solid black;

    overflow-y:auto;

    @media(max-width:800px){
        width:50vw;
        height:25vh;
    }
`;

export const ContainerBottom = styled.div`
    display: flex;
    flex-direction: row;
    height: 15vh;
    width: 50vw;

    align-items: center;
    justify-content:space-evenly;

    margin-top: 10px;

    @media(max-width:800px){
        width:30vw;
        margin-left:10px;
    }
`;

export const Button = styled.button`
    border:0;
    background:white;

    :hover{
        border:0;
        background:white;
    }
`;

export const P = styled.p`
    font-size:16px;
    font-weight:200;
`;