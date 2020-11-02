import React, {useState, useEffect} from 'react';
import {PageDefault, ButtonWrapper, Menu, Span} from './style';
import {Link} from 'react-router-dom';
import Logo from '../../assets/Img/Logo.png';
import Card from '../../components/Card';
import Button from '../../components/Buttons';
import Relogio from '../../components/Relogio';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';

export default function  Home(){

    const responsive = {
        superLargeDesktop: {
          // the naming can be any, depends on you.
          breakpoint: { max: 4000, min: 3000 },
          items: 5,
        },
        desktop: {
          breakpoint: { max: 3000, min: 1024 },
          items: 3,
        },
        tablet: {
          breakpoint: { max: 1024, min: 464 },
          items: 2,
        },
        mobile: {
          breakpoint: { max: 464, min: 0 },
          items: 1,
        },
    };


    return (
        <PageDefault>

            <Menu>

                <img src = {Logo} alt = '' width = '150' />

                <Relogio/>

                <Link to = '/login'><Span>Logar</Span></Link>
                
            </Menu>

            <Carousel responsive={responsive} >

             
                
                    <Card 
                    />
                
                
                
            </Carousel>

            <ButtonWrapper>

                <Button 
                    to = '/compra/lanche'
                    children = 'Comprar Lanche'
                />

                <Button 
                    to = '/sessaofilme'
                    children = 'Comprar Ingresso'
                />
                
            </ButtonWrapper>

        </PageDefault>
    );
}