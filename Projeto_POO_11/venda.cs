using System;
using System.Collections.Generic;

class Venda{
    private int id;
    private DateTime data;
    private bool carrinho;
    private Cliente cliente;
    private List<VendaItem> itens = new List<VendaItem>();

    //Construtor
    public Venda(DateTime data, Cliente cliente){
        this.data = data;
        this.carrinho = true;
        this.cliente = cliente;
    }

    public void SetId(int id){
        this.id = id;
    }

    public void SetData(DateTime data){
        this.data = data;
    }
    
    public void SetCarrinho(bool carrinho){
        this.carrinho = carrinho;
    }

    public void SetCliente(Cliente cliente){
        this.cliente = cliente;
    }

    public int GetId(){
        return id;
    }

    public DateTime GetData(){
        return data;
    }
    
    public bool GetCarrinho(){
        return carrinho;
    }

    public Cliente GetCliente(){
        return cliente;
    }

    public override string ToString(){
        //Ainda está comprando
        if(carrinho){ 
            return data.ToString("dd/MM/yyyy") + "\n" + "Carrinho " + id + " de " + cliente.nome + ":";
            // 10/02/2022
            // Carrinho 1 de Fulanin
        }
    
        //Já finalizou a compra
        else{ 
            return data.ToString("dd/MM/yyyy") + "\n" + "Compra " + id + " de " + cliente.nome + ":";
            // 10/02/2022
            // Compra 1 de Fulanin
        }
    }

    public List<VendaItem> ItemListar() {
        //Retorna Lista
        return itens;
    }
        
    //Verifica se um produto já existe no carrinho
    private VendaItem ItemContar(Produto produto){
        foreach(VendaItem item in itens){
            if(item.GetProduto() == produto){
                return item;
            }
        } 
        return null;
    }
    
    //Inserção de item no carrinho
    public void ItemInserir(int qtd, Produto produto){
        VendaItem item = ItemContar(produto);
        if(item == null){
            //Se o item a ser adicionado ainda não está no carrinho
            item = new VendaItem(qtd, produto);
                itens.Add(item);
        }
        else{
            //Se o item a ser adicionado já existe no carrinho
            item.SetQtd(item.GetQtd() + qtd);
        }
    }

    public void ItensExcluir(){
        //Remove todos os itens do carrinho
        itens.Clear();
    }
    
    /*
    public void ItemExcluir(){
        foreach(Produto produto in itens){  
    }
    */
}