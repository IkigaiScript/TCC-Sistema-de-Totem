import React from 'react';
import Relogio from '../../components/Relogio';
import Button from '../../components/Buttons';
import Input from '../../components/Input';
import { PageDefault, Custom, ButtonWrapper, TextLogin} from './style';

export default function Login(){
    return(
        <PageDefault>
            
            <h1>Login</h1>
               
            <TextLogin>   

                <p>
                    Faça agora seu login caso não tenha seu cadastro faça atraves de nossos app 
                    CineTotem  ou entre em nosso site <br></br>
                    www.CineTotem.com.br/CadastroMembroCineTotem

                </p>
                
            </TextLogin>

            <Custom>

                <Input 
                    type = 'text' 
                    width = '60vw'
                    placeholder = 'Digite seu e-mail CineTotem'
                    border = '0'
                />

            </Custom>
            
            <Custom>
                
                <Input 
                    type = 'password' 
                    width = '60vw'  
                    placeholder = 'Digite sua senha'
                    border = '0'
                />

            </Custom>

            <ButtonWrapper>

                <Button
                    to = '/'
                    children = 'Voltar'
                />

                <Relogio />

                <Button 
                    to = '/'
                    children = 'Logar'
                />

            </ButtonWrapper>

        </PageDefault>
    );
}