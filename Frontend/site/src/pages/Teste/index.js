import React, { useState } from 'react';
import Button from '../../components/Buttons';
import SelectFilme from '../../components/SelectionFilme';
import SelectLanche from '../../components/SelectionLanche';
import Doce from '../../assets/Img/Doce.png';
import Card from '../../components/Card';
import Relogio from '../../components/Relogio';
import Login from '../../services/LoginApi'
const api = new Login()

export default function Teste (){
    
    const [email,setEmail] = useState('')
    const [senha,setSenha] = useState('')

    async function Iniciar(){
        const resquest = {
            "Email":email,
            "Senha":senha
        }

        /*const response = await api.Iniciar(request);
        return response*/
    }

    return(
        <div>
            <Button children = 'Voltar' />

            <SelectFilme 
                imagem = {Doce}
                desc = 'Doce sdsddsfdfsdfsdfsdfsdfsdfsdfdsfsdfsdf'
                name = 'Feiticieira do doce'
            />

            <SelectLanche 
                name = {Doce}
                title = 'Especial de Filme'
                desc = 'pipoca Grande,Refrigerante Medio,Nachos e M&M'
                preco = 'R$ 100,00'
            />

            <input  type="text"
                    placeholder="Digite seu email"
                    value={email}
                    onChange={e => setEmail(e.target.value)}/>

            <input  type="text"
                    placeholder="Digite sua senha"
                    value={senha}
                    onChange={e => setSenha(e.target.value)}/>

            <input  type="submit"
                    onClick={Iniciar}/>

            <Card />

            <Relogio />

            
        </div>
    );
}