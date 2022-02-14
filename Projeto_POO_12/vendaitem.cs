using System;

//Itens a serem colocados em um carrinho
class VendaItem {
    //Atributos do item de VendaItem
    private int qtd;
    private double valor;
    private Produto produto;

    //Construtor
    public VendaItem(int qtd, Produto produto){
        this.qtd = qtd;
        this.valor = produto.GetValor();
        this.produto = produto;
    }

    public void SetQtd(int qtd){
        this.qtd = qtd;
    }

    public void SetValor(double valor){
        this.valor = valor;

    }
    
    public void SetProduto(Produto produto){
        this.produto = produto;
    }

    public int GetQtd(){
        return qtd;
    }

    public double GetValor(){
        return valor;
    }
    
    public Produto GetProduto(){
        return produto;
    }

    public override string ToString(){
        return "- " + produto.GetDescricao() + " - " + valor.ToString("R$ 0.00") + "\n" + "  " + "Quantidade: " + qtd;
    }
        //- Telescópio 50mm - R$ 20.00
        //  Quantidade: 50
    
        //Valor total: 50 * 20
}