import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    //baseURL:'http://localhost:5000/'
});


export class Combo {

    async ConsultCombo(){
        const response = await api.get(`Combos`);
        return response.data;

    }

    getPhoto(nome){
        const response = api.get(`Combos/Fotos/${nome}`)
        return response.data;
    }    

}