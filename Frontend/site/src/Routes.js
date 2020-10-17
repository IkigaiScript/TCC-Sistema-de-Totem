import {BrowserRouter, Switch, Route} from 'react-router-dom';
import OqueDesejaComer from './pages/OqueDesejaComer';
import PagamentoRealizado from './pages/PagamentoRealizado';
import ErroNoPagamento from './pages/ErroNoPagamento';
import React from 'react';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
              <Route path = '/' component = {OqueDesejaComer} exact/>       
              <Route path = '/PagamentoRealizado' component = {PagamentoRealizado}/>            
              <Route path = '/ErroNoPagamento' component = {ErroNoPagamento}/>
            </Switch>
        </BrowserRouter>
    )
}

export default Routes;
