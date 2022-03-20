using System;
using System.Collections.Generic;
using System.Linq;

class Nvenda {
    private Nvenda(){}
    static Nvenda nvenda_obj = new Nvenda();
    public static Nvenda Singleton { get => nvenda_obj; }

    //Lista com todas as vendas cadastradas;
    private List<Venda> vendas = new List<Venda>();    

    //Abrindo um arquivo de dados com as vendas
    public void Abrir(){
        Arquivo <List<Venda>> arquivo_venda = new Arquivo <List<Venda>>();
        vendas = arquivo_venda.Abrir("Projeto_POO_14/vendas.xml");
        //Atualizando dados
        AtualizarCliente();
        AtualizarProduto();
    }

    private void AtualizarCliente(){
        //Percorre a lista de vendas para procurar quem comprou
        foreach(Venda venda in vendas){
            Cliente cliente = Ncliente.Singleton.Listar(venda.ClienteId);
            if (cliente != null){
                venda.SetCliente(cliente);
            }
        }
    }

    private void AtualizarProduto(){
        foreach(Venda venda in vendas){ //Percorrendo toda a venda
            foreach(VendaItem vendaI in venda.ItemListar()){ //Percorrendo cada item da venda
                Produto produto = Nproduto.Singleton.Listar(vendaI.ProdutoId);
                if (produto != null){
                    vendaI.SetProduto(produto);
                }
            }
        }
    }
    
    //Salvando as vendas cadastradas em um arquivo xml
    public void Salvar(){
        Arquivo <List<Venda>> arquivo_venda = new Arquivo <List<Venda>>();
        arquivo_venda.Salvar("Projeto_POO_14/vendas.xml", vendas);
    }
    
    //Retorna uma lista com todas as vendas cadastradas.
    public List<Venda> Listar(){
        return vendas;
    }

    public List<Venda> Listar(Cliente cliente){
        //Retorna uma lista contendo as compras já feitas pelo cliente. 
        return vendas.Where(v => v.GetCliente() == cliente).ToList();
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
        int maiorId = 0;
        maiorId = vendas.Max(maiorI => maiorI.GetId());
        venda.SetId(maiorId + 1);
        
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