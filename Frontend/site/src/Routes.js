import React from 'react';
import {BrowserRouter, Switch, Route} from 'react-router-dom';

/* Global */
import Home from './pages/Home';
import Login from './pages/Login';

/* Tela de Ingresso */
import Lugar from './pages/Ingresso/Assento';
import InfoFilme from './pages/Ingresso/Filme';
import ComprarIngresso from './pages/Ingresso/CompraIngresso';
import Busca from './pages/Ingresso/Busca';

/* Telas de Lanche */
import OqueDesejaComer from './pages/Lanche/HomeLanche';
import Pipoca from './pages/Lanche/Pipoca';
import Doces from './pages/Lanche/Doces';
import Combo from './pages/Lanche/Combo';
import Bebida from  './pages/Lanche/Bebida';

/* Telas de Pagamento */
import HomePagamento from './pages/Pagamento/HomePagamento';
import Dinheiro from './pages/Pagamento/Dinheiro';
import QRCode from './pages/Pagamento/QRCode';
import ValidarCartao from './pages/Pagamento/Cartao';
import NFe from './pages/Pagamento/NF-e';
import PagamentoRealizado from './pages/Pagamento/PagamentoRealizado';
import ErroNoPagamento from './pages/Pagamento/PagamentoError';

/* Telas fora do sistema */
import Teste from './pages/Teste';
import HomeGerente from './pages/Gerente/Home';
import ConsultGerente from './pages/Gerente/ConsultMesDia';
import ConsulTop from './pages/Gerente/ConsulTop';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                
                <Route path = '/' component = {Home} exact/>
                <Route path = '/Login' component = {Login} exact />
                <Route path = '/Teste' component = {Teste} exact />
                
                                    {/* Ingresso */}
                                    
                <Route path = '/compra/assento' component = {Lugar} exact/>
                <Route path = '/compra/ingresso' component = {ComprarIngresso} exact/>
                <Route path = '/sessaofilme' component = {Busca} exact/>
                <Route path = '/Filme' component = {InfoFilme} exact/>

                                    {/* Lanche */}

                <Route path = '/compra/lanche' component = {OqueDesejaComer} exact/>  
                <Route path = '/compra/lanche/bebida' component = {Bebida} exact/>  
                <Route path = '/compra/lanche/combo' component = {Combo} exact/>  
                <Route path = '/compra/lanche/pipoca' component = {Pipoca} exact/>  
                <Route path = '/compra/lanche/doces' component = {Doces} exact/>  

                                    {/* Pagamento */}

                <Route path = '/escolha-pagamento' component = {HomePagamento} exact/>
                <Route path = '/pagamento/dinheiro' component = {Dinheiro} exact />
                <Route path = '/NF-e' component = {NFe} exact/>
                <Route path = '/pagamento/cartao' component = {ValidarCartao} exact />
                <Route path = '/pagamento/QRCode' component = {QRCode} exact/>
                <Route path = '/ErroNoPagamento' component = {ErroNoPagamento} exact/>
                <Route path = '/PagamentoRealizado' component = {PagamentoRealizado} exact/>   

                                    {/* Gerente */}
                
                <Route path = '/Gerenciar' component = {HomeGerente} exact />
                <Route path = '/Gerenciar/consult' component = {ConsultGerente} exact />
                <Route path = '/Gerenciar/top' component = {ConsulTop} exact />
            </Switch>
        </BrowserRouter>
    )
}

export default Routes;
