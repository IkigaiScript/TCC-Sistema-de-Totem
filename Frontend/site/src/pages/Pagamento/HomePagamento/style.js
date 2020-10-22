import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    height:100vh;
    width:100vw;
`;

export const OpcaoWrapper = styled.div`
    display:flex;
    height:80vh;
    width:100vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    box-sizing:border-box;
    padding-left:20px;
    padding-right:20px;

`;

export const Opcao = styled.div`
    display:flex;
    flex-direction:column;
    height:45vh;
    width:20vw;

    align-items:center;
    justify-content:center;

    border-radius:80%;

    :hover{
        background:green;
    }
`;

export const Img = styled.img`
    border:1px solid black;
    border-radius:100%;

    margin-left:40px;
`;

export const Span = styled.span`
    font-size:35px;
    font-weight:600;
    font-display:none;

    text-decoration:normal;
    color:black;

    margin-left:80px;
    margin-top:15px;
`;