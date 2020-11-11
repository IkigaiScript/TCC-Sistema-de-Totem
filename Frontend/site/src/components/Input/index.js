import React from 'react';
import {Inputs} from './style';

export default function Input(props){
    return(
        <Inputs 
            type = {props.type}
            placeholder = {props.placeholder}
            value = {props.value}
            onChange = {props.onChange}
            min = {props.min}
            max = {props.max}
            
            width = {props.width}
            border = {props.border}
        />
    );
}