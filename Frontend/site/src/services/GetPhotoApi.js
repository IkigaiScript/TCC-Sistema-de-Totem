import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
})

export class GetPhoto {

    getPhoto(nome){
        const response = api.get(`GetPhoto/${nome}`);
        return response.data;
    }
}