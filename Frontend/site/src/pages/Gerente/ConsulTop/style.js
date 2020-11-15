import styled from 'styled-components';

export const PageDefault = styled.div`
    display:flex;
    flex-direction:column;
    min-height:100vh;
    max-width:100vw;
    
    background:rgb(120,120,120,0.4);
    
    align-items:center;
`;

export const ClassificarWrapper = styled.div`
    display:flex;
    min-height:90vh;
    width:90vw;
    
    margin-left:auto;
    margin-right:auto;
    margin-top:15px;

    justify-content:space-between;
`;

export const TopWrapper = styled.div`
    display:flex;
    flex-direction:column;
    min-height:90vh;
    width:40vw;
    background:white;

    justify-content:center;

    padding-left:10px;
    padding-right:10px;

    border:1px solid black;
    border-radius:15px;
`;


export const RankingWrapper = styled.div`
    display:flex;
    min-height:60vh;
    width:35vw;

    align-items:flex-end;
    justify-content:center;

    margin-left:auto;
    margin-right:auto;
`;

export const Posicao = styled.div`
    display:flex;
    flex-direction:column;

    align-items:center;
`;

export const Primeiro = styled.div`
    display:flex;
    flex-direction:column;
    height:50vh;
    width:10vw;
    background:yellow;

    align-items:center;
    justify-content:center;

    border:1px solid black;
    border-bottom:2px solid black;
`;

export const Segundo = styled.div`
    display:flex;
    flex-direction:column;
    height:40vh;
    width:10vw;
    background:gray;

    align-items:center;
    justify-content:center;

    border:1px solid black;
    border-bottom:2px solid black;
`;

export const Terceiro = styled.div`
    display:flex;
    flex-direction:column;
    height:30vh;
    width:10vw;
    background:orange;

    align-items:center;
    justify-content:center;

    border:1px solid black;
    border-bottom:2px solid black;
`;