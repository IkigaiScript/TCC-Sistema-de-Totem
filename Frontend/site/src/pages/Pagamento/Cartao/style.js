import styled from 'styled-components'

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    width:100vw;

    align-items:center;
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
`;

export const Custom = styled.div`
    display:flex;
    height:fit-content;
    width:fit-content;

    align-items:center;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;
`;

export const Input = styled.input`
    height:5vh;
    width: ${props =>  props.width ? props.width : '800px'};

    border:1px solid black;
    border-radius:8px;

    box-sizing:border-box;
    padding-left:10px;
    margin:10px;
`;

