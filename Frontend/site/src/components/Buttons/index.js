import React from 'react';
import {Link} from 'react-router-dom';
import { ButtonStyled } from './style';

export default function Button (props) {
    return(
        <ButtonStyled  as = {props.as} to = {props.to}  onClick = {props.onClick}>
            <span>{props.children} </span> {props.icon} 
        </ButtonStyled>
    );
}

