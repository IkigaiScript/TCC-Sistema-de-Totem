import styled from 'styled-components';

export const PageDefault = styled.div`
  display: flex;
  flex-direction: column;
  min-height:100vh;

  align-items: center;
  justify-content: center;
`;

export const SearchWrapper = styled.div`
  display: inline-flexbox;
  width:80vw;
  height: 50px;

  align-items: center;
  justify-content: center;

  margin-top: 20px;
  margin-left:auto;
  margin-right:auto;
`;

export const SelectionWrapper = styled.div`
  display:flex;
  width: 90vw;
  height: 50px;

  align-items: center;
  justify-content: space-between;

  box-sizing:border-box;
  padding-left: 60px;
  padding-right: 60px;
  padding-top: 20px;
  margin-bottom: 20px;

`;


export const Input = styled.input`
  height:4vh;
  width:30vw;

  border: 2px solid black;
  border-radius: 4px;

  box-sizing: border-box;
  padding-left:10px;

  font-size: 16px;
  background-color: white;
`;

export const Select = styled.select`
  height:4vh;
  width:20vw;

  font-size:15px;
  font-weight:300;

  box-sizing:border-box;
  padding-left:10px;
`;