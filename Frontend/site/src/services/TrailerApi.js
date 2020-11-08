import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class Trailer {
    
    async ConsultTrailer(nome){
        
        const response = await api.get('/Trailers/Videos/${nome}')
        return response;

    }

}