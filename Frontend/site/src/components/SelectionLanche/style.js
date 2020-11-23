import styled from 'styled-components';

export const PageDefault = styled.div`
    display: flex;
    flex-direction: row;
    height: 30;
    width: 50vw;

    align-items:center;
    justify-content:center;

    box-sizing:border-box;
    padding:15px;
    margin-left:auto;
    margin-right:auto;
    margin-top:15px;
    margin-bottom:20px;

    background-color: white;
    border:1px solid black;
    border-bottom-left-radius:6px;
    border-bottom-right-radius:6px;
    border-top-left-radius:6px;
    border-top-right-radius:6px;

    color:black;

    @media(max-width: 800px){
        margin-left:0;
    }
`;

export const Img = styled.img`
    height: 25vh;
    width: 15vw;
`;

export const InfoWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width:35vw;
    height:25vh;

    align-items:center;
    justify-content:center;
`;


export const DescWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 25vw;
    height: 20vh;

    padding-right:10px;
    padding-left:10px;
    margin-right:5px;
    margin-top:10px;

    overflow-y:auto;
    font-size:20px;

    @media(max-width:800px){
        width:50vw;
        height:25vh;
    }
`;

export const ButtonWrapper = styled.div`
    display: flex;
    flex-direction: row;
    height: 15vh;
    width: 30vw;

    align-items: center;
    justify-content:center;
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

export const Text = styled.span`
    margin: 0 auto;
    color: black;
    font-size:13pt;
    font-family:'Arial';
    text-transform:lowercase;

    @media(max-width: 800px){
        font-size:10pt;
    }
`;

export const P = styled.p`
    font-size:16px;
    font-weight:200;

    margin-left:10px;
    margin-right:10px;
`;