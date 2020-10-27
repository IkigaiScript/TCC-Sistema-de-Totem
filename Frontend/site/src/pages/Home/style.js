import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100%;
    width:100vw;

    box-sizing:border-box;
    padding-left:15px;
    padding-right:15px;

    background:linear-gradient(#773510,#F3D69D);
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:90%;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    @media(max-width:800px){
        width:70%;
        justify-content:none;

        margin-left:auto;
        margin-right:auto;
    }
`;

export const Menu = styled.div`
    display:flex;
    height:10vh;
    width:95vw;

    justify-content:space-between;    
    align-items:center;
    
    margin-bottom:10px;
    margin-left:auto;
    margin-right:auto;
    border-bottom:1px solid black;
    
`;

export const Span = styled.span`
    font-size:18px;
    font-weight:400;

    margin-right:20px;
`;