import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class Trailer {
    
    async consultTrailer(nome){
        const response = await api.get(`Trailers/Videos/${nome}`)
        return response.data;
    }
}