import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
});


export class Combo {

    async consultCombo(){
        const response = await api.get(`Combos`);
        return response.data;
    }
}