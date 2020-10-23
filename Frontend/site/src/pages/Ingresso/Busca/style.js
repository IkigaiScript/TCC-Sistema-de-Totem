import styled from 'styled-components';

export const Wrapper = styled.div`
display: flex;
flex-direction: column;
align-items: center;
justify-content: center;
height: 300px;
margin-top: 250px;
`;

export const SearchWrapper = styled.div`
display: inline-flexbox;
flex-direction: column;
align-items: center;
justify-content: center;
margin-top: 20px;
width: 500px;
height: 50px;
`;

export const SelectionWrapper = styled.div`
display: inline-flexbox;
flex-direction: column;
align-items: center;
justify-content: space-between;
padding-left: 60px;
padding-right: 60px;
padding-top: 20px;
margin-bottom: 20px;
width: 500px;
height: 50px;
`;


export const Input = styled.input`
  box-sizing: border-box;
  border: 2px solid black;
  border-radius: 4px;
  font-size: 16px;
  background-color: white;
`;
