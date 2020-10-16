import React from 'react';
import { AiOutlineMinusCircle, AiOutlinePlusCircle } from 'react-icons/ai';

import { Container, ContainerImage, ContainerTitleLanche, ContainerDescLanche, SubContainer, ContainerBottom } from '../SelectionLanche/style';

export default function SelectLanche(props) {
    return(
        <Container>
            <ContainerImage>
                <img src={props.name} alt="" width="70px" height="100px"/>
            </ContainerImage>

            <SubContainer>
                <ContainerTitleLanche>
                    <h1>{props.title}</h1>
                </ContainerTitleLanche>
            
                <ContainerDescLanche>
                    <p>{props.desc}</p>
                </ContainerDescLanche>

                <ContainerBottom>
                    <AiOutlineMinusCircle size="2em" cursor="pointer" />
                        <input size="1" maxLength="1" />
                    <AiOutlinePlusCircle size="2em" cursor="pointer"/>
                        <h4>Preço: </h4>                    
                </ContainerBottom>
            </SubContainer>
        </Container>
    )
}