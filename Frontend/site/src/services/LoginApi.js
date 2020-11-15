import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export default class Login {    
    async Iniciar(req){
        const response = await api.post(`Logins/`,req); 
        // retorna um tuple de int(Pedido) e int(Nivel) 
        return response.data;
    }
}