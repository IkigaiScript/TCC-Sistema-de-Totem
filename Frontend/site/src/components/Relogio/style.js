import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    height:5vh;
    width:8vw;
    background:radial-gradient(darkblue,blue,#1E90FF);

    border:1px solid black;
    border-radius:8px;
    margin-top:auto;
    margin-bottom:auto;
    margin-left:10px;

    align-items:center;

    @media(max-width:800px){
        width:15vw;
    }
`;

export const Span = styled.span`
    margin-left:auto;
    margin-right:auto;

    font-size:18px;
    font-weight:600;

    color:white;
`;