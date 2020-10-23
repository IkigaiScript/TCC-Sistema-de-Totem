import { createGlobalStyle } from 'styled-components';

const Global = createGlobalStyle`

    *{
        padding: 0;
        margin: 0;
        box-sizing: border-box;
        ::-webkit-scrollbar{opacity:0};
    }
   
    body,
    html, 
    #root{
        height:100%;
        width:100%;
    }

    h1{
        text-align:center;
        text-decoration:underline; 

        font-size:40pt;
        font-weight:400;
        font-display:oblique;
        
        letter-spacing:3px;

        margin-top:5px;
        margin-bottom:10px;
    }

    p{
        text-align:center;

        font-size:25px;
        font-weight:300;

        margin-top:5px;
        margin-bottom:10px;
    }
`;

export default Global;