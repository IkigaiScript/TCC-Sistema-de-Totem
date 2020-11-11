import React from 'react';
import {Link} from 'react-router-dom';
import { ButtonStyled } from './style';

export default function Button (props) {
    return(
        <ButtonStyled  as = {Link} to = {props.to}  onCLick = {props.Onclick}>
            <span>{props.children} </span> {props.icon} 
        </ButtonStyled>
    );
}

