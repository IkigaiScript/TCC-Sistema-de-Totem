import { createGlobalStyle } from 'styled-components';

export const GlobalStyled = createGlobalStyle`

    *{
        padding: 0;
        margin: 0;
        box-sizing: border-box;
    }
   
    body,
    html, 
    #root{
        height:100vh;
        width:100vw;
    }

`;