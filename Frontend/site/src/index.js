import React from 'react';
import ReactDOM from 'react-dom';
import Routes from './Routes';
import {GlobalStyled} from './style/global'

ReactDOM.render(
  <React.StrictMode> 
    <Routes/>
    <GlobalStyled/>
  </React.StrictMode>,
  document.getElementById('root')

);
