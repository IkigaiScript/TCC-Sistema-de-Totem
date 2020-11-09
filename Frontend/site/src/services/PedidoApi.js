import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    // baseURL:'http://localhost:5000/'
});

export default class Pedido {
    async ConsultOrder(id){
        const response = await api.get(`Pedidos/${id}`);
        return response.data;
    }

    async DeleteOrder(id){
        const response = await api.delete(`Pedidos/${id}`);
        return response.data;
    }

    async ChangeOrderAmount(id){
        const response = await api.post(`Pedidos/Totals/${id}`)
        return response;
    }

    async ChangeOrder(id,req){        
        const response = await api.put(`Pedidos/${id}`,req)
        return response;
    }
}