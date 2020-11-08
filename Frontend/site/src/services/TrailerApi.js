import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class Trailer {
    
    async ConsultTrailer(nome){
        const response = await api.get(`Trailers/Videos/${nome}`)
        return response.data;
    }

}