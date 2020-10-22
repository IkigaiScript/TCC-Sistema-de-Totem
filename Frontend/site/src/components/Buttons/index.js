import React from 'react';
import { ButtonStyled } from '../Buttons/style';

export default function Button(props) {
    return(
        <ButtonStyled to = {props.to}  onCLick = {props.Onclick}>
            {props.children} 
        </ButtonStyled>
    );
}

