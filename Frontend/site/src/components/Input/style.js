import styled from 'styled-components'

export const Inputs = styled.input`
    height:5vh;
    width: ${props =>  props.width ? props.width : '600px'};

    box-sizing:border-box;
    padding-left:16px;
    padding-right:16px;
    margin:10px;


    border: ${props =>  props.border ? props.border : '1px solid black'};
    border-bottom: 1px solid black;
    border-radius:10px;
    
`;