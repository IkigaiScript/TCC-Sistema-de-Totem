import styled from 'styled-components';

export const ButtonStyled = styled.button`
  min-width: 150px;
  height: 50px;
  background-color: gray;
  
  margin: 1em;
  padding: 0.25em 1em;
  border: 2px solid darkgray;
  border-radius: 12px;
  box-shadow:3px -5px darkgray;

  font-size: 16px;
  color: white;

  :hover{
    cursor: pointer;
    opacity: 0.7;
    transition: 0.3s;
    color: white;
  }
`; 