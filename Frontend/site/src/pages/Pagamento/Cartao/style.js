import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    align-items:center;

    >#cartao{
        flex-direction:row;
        width:70vw;

        padding-left:5px;
        padding-right:5px;

        >div{
            padding-left:5px;
            padding-right:5px;
        }

        >div input{
            width:10vw;
        }
    }
`;

export const CartaoWrapper = styled.div`
    display:flex;
    height:20vh;
    width:90vw;

    align-items:center;
    justify-content:center;
    justify-content:space-between;

    box-sizing:border-box;
    padding-left:16px;
    padding-right:16px;
    margin-left:auto;
    margin-right:auto;

    @media(max-width:800px){
        flex-direction:column;

        padding-left:5px;
        padding-right:5px;
    }

`;

export const Custom = styled.div`
    display:flex;
    height:fit-content;
    width:fit-content;

    align-items:center;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;

    @media(max-width:800px){
       >input{
           width:50vw;
       }
    }
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:10vh;
    width:80vw;

    margin-left:auto;
    margin-right:auto;

    align-items:center;
    justify-content:center;
    justify-content:space-between;
`;