import styled from 'styled-components';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    max-width:100vw;
    background:rgb(120,120,120,0.4);
    align-items:center;
`;

export const SearchWrappper = styled.div`
    display:flex;
    height: 10vh;
    width:90vw;
    background:rgb(140,140,140,0.2);
    box-sizing:border-box;
    padding-left:20px;
    padding-right:20px;
    margin-left:auto;
    margin-right:auto;
    margin-top:50px;
    align-items:center;
    justify-content:center;
    justify-content:space-around;
    border:1px solid black;
    border-radius:20px  10px;
`;

export const ButtonWrapper = styled.div`
    display:flex;
    height:15vh;
    width:70vw;

    align-items:center;
    justify-content:center;
    justify-content:space-around;

    margin-top:10px;
    margin-left:auto;
    margin-right:auto;
`;

export const Button = styled.button`
    display:flex;
    height:5vh;
    width:15vw;

    box-sizing:border-box;
    padding-left:50px;

    border-radius:8px;

    text-align:center;
    font-size:12pt;
`;

export const ReturnConsult = styled.div`
    display:flex;
    flex-direction:column;
    width:70vw;
`;

export const Table = styled.table`
    display:flex;
    flex-direction:column;
    min-height:60vh;
    width:60vw;

    margin-left:auto;
    margin-right:auto;

`;
