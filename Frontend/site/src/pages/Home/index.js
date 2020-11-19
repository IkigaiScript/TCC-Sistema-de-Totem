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
import { Filme } from '../../services/FilmeApi';
import { Cliente } from '../../services/ClienteApi';
import { GetPhoto } from '../../services/GetPhotoApi';

const filme = new Filme();
const cliente = new Cliente();
const getPhoto = new GetPhoto();

export default function  Home(){

  const [pedido,setPedido] = useState(localStorage.getItem('pedido'));
  const [req,setReq] = useState([]);
  const [img,setImg] = useState('');
  const [nome,setNome] = useState('');

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

  async function consultFilmes() {
    try{
      const response = await filme.consultFilmes();
      setReq([...response]);
      console.log('ok Filme');
    }
    catch(e){
      if(e.response.data.error){
        console.log(e.response.data);
        toast.error(e.response.data.error);
      }
      else {
        console.log(e.response.data);
        toast.error('Algo deu errado!', {
            autoClose: 2000,
            hideProgressBar: false,
            closeOnClick: false,
            pauseOnHover: false,
            draggable: true,
            progress: undefined,
          });
      }
    }
  }

  async function consultCliente() {
    try{
      const response = await cliente.consultCliente(pedido);
      console.log(response);
      setNome(response.nome);
      return response;
    }
    catch(e){
      if(e.response.data.error){
        console.log(e.response.data);
        toast.error(e.response.data.error);
      }
      else {
        console.log(e.response.data);
        toast.error("Algo deu errado!");
      }
    }
  }

  useEffect(() => {
    consultFilmes();
    consultCliente();
  },[])


  return (
    <PageDefault>

      <ToastContainer />
      <Menu>

        <img src = {Logo} alt = '' width = '150' />

        <Relogio/>
   
        <Span>{nome}<FaRegUserCircle /></Span>

      </Menu>

      <Carousel responsive={responsive} >

        {req.map(x =>            
          <Card  key = {x.id}
            nome = {x.nome}
            image = {getPhoto.getPhoto('paisagem.jpg')}
            sinopse = {x.sinopse}
          />
        )}  
          
      </Carousel>

      <ButtonWrapper>

        <IconContext.Provider value={{ size: '20px', color : 'white'}}>

          <Button
            as = {Link}
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