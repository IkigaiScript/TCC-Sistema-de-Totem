import styled from 'styled-components';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    height:85vh;
    width:30vw;
    background:whitesmoke;

    margin-left:50px;
    border-radius:8px;
    border:1px solid black;

    @media(max-width:800px){
        width:80vw;
        margin-left:20px;
    }
`;

export const Header = styled.div`
    display:flex;
    flex-direction:column;
    height:35vh;
`;

export const InfoWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:40vh;

    margin-left:10px;
    margin-right:10px;
    margin-bottom:10px;

    overflow-y:auto;
    ::-webkit-scrollbar{opacity:0};
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

    
    padding:0;
    margin-left:auto;
    margin-right:auto;
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
