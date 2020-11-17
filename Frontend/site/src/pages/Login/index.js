import React, { useState } from 'react';
import {Link} from 'react-router-dom';
import Relogio from '../../components/Relogio';
import Button from '../../components/Buttons';
import Input from '../../components/Input';
import { PageDefault, Custom, ButtonWrapper, TextLogin} from './style';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import LoginApi from '../../services/LoginApi'
const api = new LoginApi();

export default function Login(){

    const [email,setEmail] = useState('');
    const [senha,setSenha] = useState('');

    async function Logar(){
        try{
            const req = {
                Email:email,
                Senha:senha
            };
            
            const response = await api.iniciarPedido(req);
            
            if(response){
                
                let t = String(response).substring(1,String(response).indexOf(','))
                localStorage.setItem("pedido",Number(t))

                let y = String(response).substring(String(response).indexOf(",") + 1,String(response).indexOf(")"));
                y = Number(y);
                
                if(y == 1 || y == 2 || y == 3){
                    let url = `${window.location.href}Gerenciar`;
                    window.location.replace(url);  
                }   
                else{
                    let url = `${window.location.href}home`;
                    window.location.replace(url);
                }
            }

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

    return(
        <PageDefault>            
            <h1>Login</h1>

            <TextLogin>   
                <p>
                    Faça agora seu login caso não tenha seu cadastro faça atraves de nossos app 
                    CineTotem  ou entre em nosso site <br/>
                    www.CineTotem.com.br/CadastroMembroCineTotem
                </p>
            </TextLogin>

            <Custom>
                <Input 
                    type = 'text' 
                    width = '60vw'
                    value = {email}
                    onChange = {e => setEmail(e.target.value)}
                    placeholder = 'Digite seu e-mail CineTotem'
                    border = '0'
                />

            </Custom>
            
            <Custom>
                
                <Input 
                    type = 'password' 
                    width = '60vw'
                    value = {senha}
                    onChange = {e => setSenha(e.target.value)}  
                    placeholder = 'Digite sua senha'
                    border = '0'
                />

            </Custom>

            <ButtonWrapper>

                <Button onClick = {Logar}>Entrar</Button>

                <Relogio />

                <Button 
                    onClick = {() => {
                        if(email !== '' && senha !== '') Logar();
                        else toast.info("Todos os campos não foram prenchidos");
                    }} 
                >Logar</Button>

            </ButtonWrapper>
            
            <ToastContainer/>
        </PageDefault>
    );
}