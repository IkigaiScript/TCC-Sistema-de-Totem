import styled from 'styled-components';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    height:85vh;
    width:30vw;

    margin-left:50px;
    border-radius:8px;
    border:1px solid black;

`;

export const Header = styled.div`
    display:flex;
    flex-direction:column;
    height:30vh;
`;

export const InfoWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:30vh;

    margin-left:10px;
    margin-right:10px;

    overflow-y: auto;
    ::-webkit-scrollbar{opacity:0};

`;

export const FilmeWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:20vh;
    width:100%;

    margin-left:10px;
    margin-right:10px;
`;

export const Custom = styled.div`
    display:flex;
    height:10vh;
    width:90%;

    margin-bottom:5px;

    overflow-x:auto;
    ::-webkit-scrollbar{opacity:0};

    >li{
        margin-left:5px;
    }
`;



export const Video = styled.video`
    height:100%;
    width:100%;

    border-top-left-radius:8px;
    border-top-right-radius:8px;
`;

export const Span = styled.span`
    text-align:flex-end;
    font-size:19px;
    font-weight:400;
    font-style:oblique;

    position:relative;
    z-index:1;
    top:4em;
    left:4em;
    
    padding:0;
`;


export const ImgFilme = styled.div`
    display:flex;
    flex-direction:row;
    height:fit-content;
    width:100%;
    
    position: relative;
    z-index:1;
    top:-4em;
`;