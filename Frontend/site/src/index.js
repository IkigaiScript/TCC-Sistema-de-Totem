import React from 'react';
import ReactDOM from 'react-dom';
import Routes from './Routes';
import Global from './style/global'

ReactDOM.render(
  <React.StrictMode> 
    <Routes/>
    <Global/>
  </React.StrictMode>,
  document.getElementById('root')

);
