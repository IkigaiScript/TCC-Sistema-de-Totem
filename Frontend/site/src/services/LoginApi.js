import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class Login {
    
    async Iniciar(req){
        const response = await api.post(`/Logins/`,req)
        console.log(response.data)
        return response
    }
}