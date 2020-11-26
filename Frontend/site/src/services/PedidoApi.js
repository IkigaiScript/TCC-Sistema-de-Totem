import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class Pedido {
 
    async consultOrder(id){
        const response = await api.get(`Pedidos/${id}`);
        return response.data;
    }

    async deleteOrder(id){
        const response = await api.delete(`Pedidos/${id}`);
        return response.data;
    }

    async changeOrderAmount(id){
        const response = await api.post(`Pedidos/Totals/${id}`)
        return response.data;
    }

    async changeOrder(id,req){        
        const response = await api.put(`Pedidos/${id}`,req)
        return response.data;
    }
}