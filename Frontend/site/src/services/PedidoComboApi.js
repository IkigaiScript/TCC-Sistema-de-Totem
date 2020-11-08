import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class PedidoCombo {
    
    async RegisterComboOrden(req){
        
        const response = await api.post('/Pedidos/Combos/${req}')
        return response;

    }

}