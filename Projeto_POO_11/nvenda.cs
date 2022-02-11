using System;
using System.Collections.Generic;

class Nvenda {
    //Lista com todas as vendas cadastradas;
    private List<Venda> vendas = new List<Venda>();
    
    //Retorna uma lista com todas as vendas cadastradas.
    public List<Venda> Listar(){
        return vendas;
    }

    public List<Venda> Listar(Cliente cliente){
        //Retorna uma lista contendo as vendas já feitas pelo cliente. 
        List<Venda> venda = new List<Venda>();
        foreach(Venda v in vendas){
            if(v.GetCliente() == cliente) venda.Add(v); 
        }
        return venda;
    }

    public Venda ListarCarrinho(Cliente cliente) {
        foreach(Venda v in vendas){
            //Se achei o cliente procurado e ele já finalizou a compra do carrinho.
            if(v.GetCliente() == cliente && v.GetCarrinho()) {
                return v; //Retorno a venda.
            }
        }
        return null;
    }

    public void Inserir(Venda venda, bool carrinho){
        int max = 0;
        foreach(Venda v in vendas){
            if(v.GetId() > max){
                max = v.GetId();
            }
        }
        venda.SetId(max + 1);
        
        //Insere a nova venda em vendas
        vendas.Add(venda);
        
        //Define o atributo carrinho
        venda.SetCarrinho(carrinho); 
        //Vai ser verdadeiro se ainda for um carrinho;
        //Vai ser falso se o carrinho se tornou uma venda.
    }

    public List<VendaItem> ItemListar(Venda venda){
        //Retorna os itens da venda
        return venda.ItemListar();
    }

    public void ItemInserir(Venda venda, int qtd, Produto produto){
        //Inserir um item em uma venda
        venda.ItemInserir(qtd, produto);
    }

    public void ItensExcluir(Venda venda){
        //Remover todos os itens da venda
        venda.ItensExcluir();   
    }
}