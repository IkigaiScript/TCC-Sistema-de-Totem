import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    // baseURL:'http://localhost:5000/'
});

export default class Sessao {
 
    async consult(id) {
        const resp = await api.get(`Sessao?id=${id}`)
        return resp.data;
    } 

    
}