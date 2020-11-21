import React,{ useState } from 'react';
import Login from './Login'
import Home from './Home'

export default function Init(){
    
    const [ped] = useState(window.localStorage.getItem('pedido'));
    
    if(ped === null || ped === undefined){
        return Login();
    }

    else {
        return Home();
    }
}