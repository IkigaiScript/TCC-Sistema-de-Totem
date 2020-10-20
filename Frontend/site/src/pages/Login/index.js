import React from 'react';
import Relogio from '../../components/Relogio/index';
import Button from '../../components/Buttons/index';
import { LoginWrapper, InputWrapper} from './style';

export default function Login(){
    return(
        <LoginWrapper>
            <div>
                <h1>Login</h1>
                <br />
                <p>Caso não tenha seu cadastro faça atraves de nosso app CineTotem
                ou em nosso site www.CineTotem.com.br/CadastroMembroCineTotem</p>
            </div>

            <InputWrapper>
                <input type="text" size="40" placeholder="Insira seu email" required />
                <br />
                <input type="password" size="40" height="3" placeholder="Insira sua senha" required />
            </InputWrapper>

            <div>
                <Button to="/" onClick="" children="Voltar"/>
                <Button to="/" onClick="" children="Logar"/>
            </div>

            <br />
            <Relogio />
        </LoginWrapper>
    );
}