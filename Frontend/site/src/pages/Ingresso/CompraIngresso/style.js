import styled from 'styled-components';


export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    max-width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    align-items:center;
    justify-content:center;

    box-sizing:border-box;
    padding-left:16;
    padding-right:16px;

    @media(max-width: 800px){
      
        >div input{
            width:50vw;
        }
    }

`;

export const Custom = styled.div`
    display:flex;
    height:15vh;
    width:80vw;

    box-sizing:border-box;
    padding-left:16px;
    padding-right:16px;
    margin-left:auto;
    margin-right:auto;

    align-items:center;
    justify-content:center;
    justify-content:space-between;

    @media(max-width: 800px){
        padding-left:0;
        padding-right:0;

        >div input{
            width:40vw;
        }
    }

`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:80vw;

    margin-left:auto;
    margin-right:auto;
    margin-top:10px;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    @media(max-width:800px){
        justify-content:space-evenly;
    }
`;

export const AssentoInfo = styled.div`
    display:flex;
    flex-direction:column;
    height:20vh;
    width:80vw;
;
    box-sizing:border-box;
    padding-left:16px;
    padding-top:16px;
    margin-left:auto;
    margin-right:auto;

    border:1px solid;
    border-radius:10px;
 
   >span{
        text-align:center;
        font-size:18pt;
        color:white;

        margin-left:10px;
    }
`;