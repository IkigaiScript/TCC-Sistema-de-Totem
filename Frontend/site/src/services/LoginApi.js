import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
});

export default class Login { 

    async iniciarPedido(req){
        const response = await api.post(`Logins/`,req); 
        return response.data;
    }
}