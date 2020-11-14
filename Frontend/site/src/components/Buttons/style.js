import styled from 'styled-components';

export const ButtonStyled = styled.button`
  display:flex;
  min-width: 150px;
  height: 50px;
  background-color: gray;

  box-shadow:3px -5px darkgray;
  box-sizing:border-box;
  padding-left:10px;
  padding-right:10px;
  padding-right:auto;
  margin: 1em;
  
  border: 2px solid darkgray;
  border-radius: 12px;

  align-items:center;
  justify-content:center;
  
  >span{
    font-size: 16px;
    text-align:center;
    text-decoration:none;
    color: white;
  }

  :hover{
    cursor: pointer;
    opacity: 0.7;
    transition: 0.3s;
    color: white;
  }
`; 