import {BrowserRouter, Switch, Route} from 'react-router-dom'
import OqueDesejaComer from './pages/OqueDesejaComer'
import PagamentoRealizado from './pages/PagamentoRealizado'
import React from 'react';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
              <Route path = '/' component = {OqueDesejaComer} exact/>       
              <Route path = '/PagamentoRealizado' component = {PagamentoRealizado}/>            
            </Switch>
        </BrowserRouter>
    )
}

export default Routes;
