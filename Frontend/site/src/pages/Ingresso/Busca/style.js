import styled from 'styled-components';

export const PageDefault = styled.div`
  display: flex;
  flex-direction: column;
  min-height:100vh;
  max-width:100vw;
  background:linear-gradient(#773500,#F3D69D);

  align-items: center;
  justify-content: center;
`;

export const SearchWrapper = styled.div`
  display:flex;
  width:50vw;
  height: 60px;

  align-items: center;
  justify-content: center;
  justify-content:space-around;

  margin-top: 20px;
  margin-left:auto;
  margin-right:auto;
`;

export const SelectionWrapper = styled.div`
  display:flex;
  width: 90vw;
  height: 10vh;

  align-content: center;
  justify-content: space-between;

  box-sizing:border-box;
  padding-left: 60px;
  padding-right: 60px;
  padding-top: 20px;
  margin-bottom: 20px;

  @media(max-width: 800px) {
    width:100vw;
    padding-left:5px;
    padding-right:5px;
  }  

`;

export const Select = styled.select`
  height:5vh;
  width:20vw;

  font-size:15px;
  font-weight:300;

  box-sizing:border-box;
  padding-left:20px;

  border-radius:8px;

  @media(max-width: 800px) {
    min-width:30vw;
    padding-left:10px;
  }
`;


export const FilmesWrapper = styled.div`
  display:flex;
  flex-direction:column;
  height:80vh;
  width:90vw;
  
  box-sizing:border-box;
  padding-left:16px;
  padding-right:16px;

  align-items:center;
  justify-content:center;
  justify-content:space-around;

  overflow-y:auto;
`;