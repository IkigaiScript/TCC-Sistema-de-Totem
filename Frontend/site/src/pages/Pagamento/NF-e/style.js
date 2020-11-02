import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    box-sizing:border-box;
    padding-top:20px;
    padding-bottom:20px;
    
    justify-content:center;
    align-items:center;
`;

export const Custom = styled.div`
    display:flex;
    flex-direction:column;
    height: 15vh;
    width:80vw;

    box-sizing:border-box;
    padding-left:15px;
    padding-right:15px;
    margin-left:auto;
    margin-right:auto;
    margin-bottom:20px;

    @media(max-width:800px){
        height:20vh;
        width:90vw;

        >input{
            align-items:center;
            justify-content:center;
        }
        

        overflow-y:auto;    
    }
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:10vh;
    width:60vw;

    margin-left:auto;
    margin-right:auto;  

    justify-content:space-between;
    align-items:center;

    @media(max-width:800px){
        flex-direction:column;
        height:30vh;
        width:80vw;

        justify-content:space-evenly;
    }
`;