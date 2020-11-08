import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class Pedido {
    async ConsultOrder(id){

        const response = await api.get('/Pedidos/${id}')
        return response;

    }

    async DeleteOrder(id){

        const response = await api.delete('/Pedidos/${id}')
        return response;

    }

    async ChangeOrderAmount(id){
        
        const response = await api.put('/Pedidos/Totals/${id}')
        return response;

    }

    async ChangeOrder(id){
        
        const response = await api.put('/Pedidos/${id}')
        return response;

    }
}