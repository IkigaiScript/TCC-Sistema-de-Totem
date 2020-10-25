import styled from 'styled-components';

export const Wrapper = styled.div` 

    display: flex;
    flex-direction: column;

    align-items: center;
    justify-content: center;

    background-color: lightskyblue;
`;

export const FilmeWrapper = styled.div` 

    display: flex;
    flex-direction: row;
    justify-content: space-around;

    width: 400px;
    height: 120px;

    margin-top: 10px;
    padding: 3px;

    border: 2pt solid black;
    border-radius: 5px;

    background-color: white;

`;

export const TitleWrapper = styled.div`

display: flex;
flex-direction: column;

word-wrap: break-word;
align-items: center;

width: 260px;
height: 100px;

`;

export const ImgWrapper = styled.div`

display: flex;
flex-direction: column;

margin-right: 10px;
width: 120px;
height: 100px;

`;

export const SinopseWrapper = styled.div` 

    display: flex;
    flex-direction: column;
    word-wrap: break-word;

    h2 {
        text-align: center;
    }

    width: 450px;
    height: 180px;
    margin-top: 10px;

    border: 1pt solid black;
    border-radius: 5px;

    background-color: white;
`;

export const InfoWrapper = styled.div` 

    display: flex;
    flex-direction: column;
    word-wrap: break-word;

    h2 {
        text-align: center;
    }

    width: 450px;
    height: 150px;
    margin-top: 10px;

    border: 1pt solid black;
    border-radius: 5px;

    background-color: white;
`;

export const SessaoWrapper = styled.div` 

    display: flex;
    flex-direction: column;
    word-wrap: break-word;

    h4 {
        text-align: center;
    }

    width: 450px;
    height: 80px;
    margin-top: 10px;

    border: 1pt solid black;
    border-radius: 5px;

    background-color: white;
`;

export const SalaWrapper = styled.div` 

    display: flex;
    flex-direction: column;
    word-wrap: break-word;

    h4 {
        text-align: center;
    }

    width: 450px;
    height: 80px;
    margin-top: 10px;

    border: 1pt solid black;
    border-radius: 5px;

    background-color: white;
`;

export const Rodape = styled.div` 

    display: inline-flexbox;
    align-items: center;
    justify-content: space-between;
    
    width: 450px;
`;