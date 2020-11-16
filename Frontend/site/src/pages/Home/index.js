import React, {useState, useEffect} from 'react';
import {PageDefault, ButtonWrapper, Menu, Span} from './style';
import {Link} from 'react-router-dom';
import Logo from '../../assets/Img/Logo.png';
import Card from '../../components/Card';
import Button from '../../components/Buttons';
import Relogio from '../../components/Relogio';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
import {FaRegUserCircle} from 'react-icons/fa';
import {GiMeal, GiTicket} from 'react-icons/gi';
import { IconContext } from "react-icons";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Filme from '../../services/FilmeApi';

const api = new Filme();

export default function  Home(){

  const [req,setReq] = useState([]);
  const [reqs,setReqs] = useState([]);

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
      console.log('ok Filme');

    }
    catch(e){
      toast.error('Erro ao consultar filme');
    }
  }



  useEffect(() => {
    ConsultClick();
  },[])


  return (
    <PageDefault>

      <ToastContainer />
      <Menu>

        <img src = {Logo} alt = '' width = '150' />

        <Relogio/>

        <Link style ={{'textDecoration': 'none'}} to = '/login'> 

          <Span>Usuario <FaRegUserCircle /></Span>

        </Link>

      </Menu>

      <Carousel responsive={responsive} >

        {req.map(x =>            
          <Card  key = {x.id}
            nome = {x.nome}
            image = {api.getPhoto(x.imagem)}
            sinopse = {x.sinopse}
          />
        )}  
          
      </Carousel>

      <ButtonWrapper>

        <IconContext.Provider value={{ size: '20px'}}>

          <Button
            to = '/compra/lanche'
            children = 'Comprar Lanche'
            icon = { <GiMeal /> } 
          />

          <Button 
            to = '/sessaofilme'
            children = 'Comprar Ingresso'
            icon = { <GiTicket /> }
          />
          
        </IconContext.Provider>
          
      </ButtonWrapper>

    </PageDefault>
  );
}