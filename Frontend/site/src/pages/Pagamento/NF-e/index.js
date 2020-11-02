import React from 'react'
import Relogio from '../../../components/Relogio'
import Button from '../../../components/Buttons'
import Input from '../../../components/Input'
import {PageDefault, Custom, ButtonWrapper} from './style'

export default function NFe (){
    return (
        <PageDefault>

            <Custom>

                <p>
                    Estamos quase finalizando o seu pedido, por favor digite seu e-mail para que possamos enviar sua 
                    nota fiscal, caso deseje CPF na nota basta adicionar, lembramos que essa opção não e obrigatoria.
                </p>

            </Custom>

            <Custom ClassName= 'inputone'>

                <Input type = 'text'  placeholder = 'Digite seu e-mail para receber a nota fiscal' width = '1000' />

                <Input type = 'text'  placeholder = 'Digite seu CPF' width = '1000' />

            </Custom>

            <Custom>

                <p>
                    Caso você tenha alguns de nossos cupom de desconto, basta digitar o seu código, caso não tenha 
                    abaixe agora nosso App CineTotem ou entre em nosso site para  poder  ficar por dentro do que rola
                    em nossos sistemas e ter descontos imperdiveis
                </p>

            </Custom>           

            <Custom className= 'inputwo'>

                <Input type = 'text' maxLength ='4' placeholder = 'Digite o codigo do seu cupom de desconto' width = '1000'/>

            </Custom> 

            <ButtonWrapper> 
                
                <Button 
                    to = '/'
                    children = 'Cancelar Pedido' 
                />

                <Relogio />

                <Button 
                    to = '/pagamento/cartao'
                    children = 'Confirmar' 
                />
            </ButtonWrapper>

        </PageDefault>
    );
}