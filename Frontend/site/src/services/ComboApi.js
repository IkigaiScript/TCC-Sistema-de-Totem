import axios from 'axios';

const api = axios.create({
   //baseURL:'http://54.208.155.192:5000/'
   baseURL:'http://localhost:5000/'
});


export class Combo {

    async ConsultCombo(){

        const response = await api.get(`Combos`);
        return response.data;

    }

    ConsultFoto(nome){
        const response = api.get(`Combos/Fotos/${nome}`)
        return response.data;
    }    

}