import axios from 'axios';

const api = axios.create({
   //baseURL:'http://54.208.155.192:5000/'
   baseURL:'http://localhost:5000/'
});

export default class Login {    
    async Iniciar(req){
        const response = await api.post(`Logins/`,req)
        return response.data
    }
}