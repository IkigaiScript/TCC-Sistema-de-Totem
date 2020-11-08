import React, {useState, useEffect} from 'react';
import {PageDefault, ButtonWrapper, Menu, Span} from './style';
import {Link} from 'react-router-dom';
import Logo from '../../assets/Img/Logo.png';
import Card from '../../components/Card';
import Button from '../../components/Buttons';
import Relogio from '../../components/Relogio';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
import Filme from '../../services/FilmeApi'

const api = new Filme();

export default function  Home(){

  const [req,setReq] = useState([]);

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

  const ConsultClick = async () => {

    try{

      const con = await api.consult();
      setReq([...con]);

    }
    catch(e){
      console.error("Deu Ruim Man");
    }
  }

  useEffect(() => {
    ConsultClick()
  },[])


  return (
    <PageDefault>

      <Menu>

        <img src = {Logo} alt = '' width = '150' />

        <Relogio/>
        
        <Link to = '/login'><Span>Logar</Span></Link>
        
      </Menu>

      <Carousel responsive={responsive} >

        {req.map(x =>  
          
          <Card  key = {x.id}
            trailer = {x.trailer}
            image = {x.image}
            nome = {x.nome}
            sinopse = {x.sinopse}
          />
  
        )}  
          
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