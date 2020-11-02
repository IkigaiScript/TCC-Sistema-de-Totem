import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;
    background:linear-gradient(#773500,#F3D69D);

    box-sizing:border-box;
    padding:20px;

`;

export const ButtonWrappper = styled.div`
    display:flex;
    height:10vh;
    width:60vw;

    align-items:center;
    justify-content:center;
    justify-content:space-between;

    margin-left:auto;
    margin-right:auto;

    @media(max-width: 800px){
        height:20vh;
    }
`;

export const QRCodeWrapper = styled.div`
    display:flex;
    height:60vh;
    width:80vw;

    align-items:center;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;
`;

