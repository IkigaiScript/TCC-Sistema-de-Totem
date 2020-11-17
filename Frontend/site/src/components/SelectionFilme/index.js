import React from 'react';
import { PageDefault, ImageWrapper, TitleWrapper, Title } from './style';

export default function SelectFilme(props) {
    return(
        <PageDefault>

            <ImageWrapper>

                <img src = {props.image} alt = {props.desc} height = '95px' width = '120px' />
            
            </ImageWrapper>

            <TitleWrapper>

                <Title>
                    {props.name}
                </Title>

            </TitleWrapper>

    </PageDefault>
);
}
