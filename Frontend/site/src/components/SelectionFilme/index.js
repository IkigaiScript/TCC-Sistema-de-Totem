import React from 'react';
import { Container, ContainerImage, ContainerTitle, Title } from './style';

export default function SelectFilme(props) {
    return(
        <Container>
            <ContainerImage>
                <img src={props.imagem}  alt={props.desc} height = '95px' width = '120px' /> 
            </ContainerImage>

            <ContainerTitle>
                <Title>
                    {props.name}
                </Title>
            </ContainerTitle>
        </Container>
    );
}