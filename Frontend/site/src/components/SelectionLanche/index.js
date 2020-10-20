import React from 'react';
import { AiOutlineMinusCircle, AiOutlinePlusCircle } from 'react-icons/ai';
import { Container, ContainerImage, ContainerTitleLanche, ContainerDescLanche, SubContainer, ContainerBottom, Button, Input } from './style';


export default function SelectLanche(props) {
    return(
        <Container>

            <ContainerImage>

                <img src={props.name} alt="" width="75px" height="150px"/>

            </ContainerImage>

            <SubContainer>

                <ContainerTitleLanche>

                    <h1>{props.title}</h1>

                </ContainerTitleLanche>
            
                <ContainerDescLanche>

                    <p>{props.desc}</p>

                </ContainerDescLanche>

                <ContainerBottom>
                    
                    <Button>
                        <AiOutlineMinusCircle size="5vh" cursor="pointer" />
                    </Button>

                    <Input className='comida' type = 'text'  />

                    <Button>
                        <AiOutlinePlusCircle size= '5vh' cursor="pointer"/>
                    </Button>

                    <span>Preço:{props.preco} </span>                    

                </ContainerBottom>

            </SubContainer>

        </Container>
    )
}