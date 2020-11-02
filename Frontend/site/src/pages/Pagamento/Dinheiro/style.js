import styled from 'styled-components';

export const PageDefault = styled.div`
    display: flex;
    flex-direction: column;
    height:100vh;
    max-width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    align-items: center;

    align-items:center;
    justify-content:center;
`;

export const TextWrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 60vw;
    height:35vh;

    margin-left:auto;
    margin-right:auto;

    margin-top: 30px;

    @media(max-width: 800px){
        height:40vh;
        width:90vw;

        overflow-y:auto;
    }
`;

export const ButtonWrapper =styled.div`
    display:flex;
    height:20vh;
    width:70vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    margin-top:20px;
`;