import axios from 'axios'

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
})

export class Gerente {

    async topFilmes(){
        const response = await api.get(`Gerente/Top/Filmes`);
        return response.data;
    }

    async vendasDoDia(dia){
        const response = await api.get(`Gerente/Vendas/Dia/${dia}`,);
        return response.data;
    }

    async vendasdoMes(req){
        console.log(req);
        const response = await api.get(`Gerente/Vendas`,req);
        return response.data;
    }

    async topProdutos(){
        const response = await api.get(`Gerente/Top/Produtos`);
        return response.data;
    }

    async totemLogins(){
        const response = await api.get(`Gerente/Logins`);
        return response.data;
    }
}