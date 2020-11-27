import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
});

export class Trailer {
    
    consultTrailer(id){
        const url = `${api.defaults.baseURL}Trailers/Videos/${id}`;
        return url;
    }
}