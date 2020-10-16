import {BrowserRouter, Switch, Route} from 'react-router-dom'
import OqueDesejaComer from './pages/OqueDesejaComer'
import React from 'react';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
              <Route path = '/' component = {OqueDesejaComer} exact/>        
                          
            </Switch>
        </BrowserRouter>
    )
}

export default Routes;
