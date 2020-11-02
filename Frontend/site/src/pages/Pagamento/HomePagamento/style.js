import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;
    background:linear-gradient(#773500,#F3D69D);
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

    @media(max-width:800px){
        flex-direction:column;
        height:150vh;
    }
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
        background:blue;
    }

    @media(max-width:800px){
        height:65vh;
    }
`;

export const Img = styled.img`
    border:1px solid black;
    border-radius:100%;

    background:white;

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

export const ValorWrapper = styled.div`
    display:flex;
    height:20vh;
    width:70vw;

    align-items:center;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;
    margin-top:10px;

    >span{
        font-size:20pt;
        color:white;
    }

`;