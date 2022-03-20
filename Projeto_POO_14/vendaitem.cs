using System;

//Itens a serem colocados em um carrinho
public class VendaItem {
    //Atributos do item de VendaItem
    private int qtd;
    private double valor;
    private Produto produto;
    private int produtoId;

    public int Qtd { get => qtd; set => qtd = value; }
    public double Valor { get => valor; set => valor = value; }
    public int ProdutoId { get => produtoId; set => produtoId = value; }
    public VendaItem(){ }
    
    //Construtor
    public VendaItem(int qtd, Produto produto){
        this.qtd = qtd;
        this.valor = produto.GetValor();
        this.produto = produto;
        this.produtoId = produto.GetId();
    }

    public void SetQtd(int qtd){
        this.qtd = qtd;
    }

    public void SetValor(double valor){
        this.valor = valor;

    }
    
    public void SetProduto(Produto produto){
        this.produto = produto;
        this.produtoId = produto.GetId();
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
        return "- " + produto.GetDescricao() + " - " + valor.ToString("R$ 0.00") + "\n" + "  " + "Quantidade: " + qtd
        + "\n  Valor Total: " + (qtd * valor).ToString("R$ 0.00");
    }
        //- Telescópio 50mm - R$ 20.00
        //  Quantidade: 50
        //  Total: R$ X.XX
}