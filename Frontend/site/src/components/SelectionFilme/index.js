import React from 'react';

import { Container, ContainerImage, ContainerTitle, TitleFilme } from '../SelectionFilme/style';

export default function SelectFilme(props) {
    return(
        <Container>
            <ContainerImage>
                <img src={props.image} 
                     alt={props.desc} /> 
            </ContainerImage>

            <ContainerTitle>
                <TitleFilme>
                    {props.name}
                </TitleFilme>
            </ContainerTitle>
        </Container>
    );
}