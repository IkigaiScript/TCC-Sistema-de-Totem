import styled from 'styled-components';

export const PageDefault = styled.div`
    display: flex;
    flex-direction: row;
    height: 40vh;
    width: 55vw;

    /* margin-left:10px;
    margin-right:10px;
    margin-top:25px;
    margin-bottom:30px; */

    background-color: white;
    border:1px solid darkblue;

    @media(max-width: 800px){
        margin-left:0;
    }
`;

export const Img = styled.img`
    height: 40vh;
    width: 20vw;

    border:1px solid purple;
`;

export const InfoWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width:35vw;
    height:40vh;

    border:1px solid black;
    align-items:center;
    justify-content:center;
`;

export const TitleWrapper = styled.div`
    width:28vw;
    height:35px;

    overflow: hidden;
    border:1px solid dodgerblue;
`;

export const DescWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 55vw;
    height: 20vh;

    padding-right:10px;
    padding-left:10px;
    margin-right:5px;

    overflow-y:auto;

    @media(max-width:800px){
        width:50vw;
        height:25vh;
    }
`;

export const ButtonWrapper = styled.div`
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

export const Text = styled.span`
    margin: 0 auto;
    color: black;
    font-size:13pt;
    font-family:'Arial';
    text-transform:lowercase;
    border:1px solid black;

    @media(max-width: 800px){
        font-size:10pt;
    }
`;

export const P = styled.p`
    font-size:16px;
    font-weight:200;
`;