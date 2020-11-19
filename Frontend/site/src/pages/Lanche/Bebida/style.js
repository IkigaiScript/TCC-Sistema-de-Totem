import styled from 'styled-components';

export const PagesDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    max-width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    align-items:center;
    justify-content:center;
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:10vh;
    width:80vw;

    box-sizing:border-box;
    padding-left:16px;
    padding-right:16px;
    margin-left:auto;
    margin-right:auto;
    margin:20px;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    @media(max-width: 800px){
        flex-direction:column;
        height:30vh;
        width:100vw;

        justify-content:space-evenly;
    }
`;

export const Custom = styled.div`
    display:flex;
    height:fit-content;
    width: 80vw;

    box-sizing:border-box;
    padding:10px;
    margin-left:auto;
    margin-right:auto;

    @media(max-width: 800px){
        flex-direction:column;
        padding:0;
        
    }
`;

export const OptionWrapper = styled.div`
    display:flex;
    flex-direction:column;
    height:85vh;
    width:90vw;

    box-sizing:border-box;
    padding:10px 16px;
    margin-left:auto;
    margin-right:auto;

    border: 1px solid black;
    border-radius:20px;

    @media(max-width: 800px){
        flex-direction:column;
        height:65vh;

        padding:5px;
    }
`;

export const Select = styled.select`
    height:8vh;
    width:29vw;
    box-sizing:border-box;
    border-radius:10px;
    color:white;
    padding:5px;
    background-color:#222831;
    font-size:15pt;
    border:0.2em solid #393e46 ;
`;

export const H1 = styled.h1`
    font-size:40pt;
    margin-bottom:80px;
    margin-top:20px;
    font-weight:bold;
    text-decoration:none;

    @media(max-width: 800px)
    {
        margin-bottom:10px;    
    }

    &:hover{
        text-decoration:underline;
        text-decoration-color:white;
    }
    
`;

export const Option = styled.option`
    color:white;
    line-height:50px;
    font-size:12pt;
`;
