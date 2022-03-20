using System;

public class Produto : IComparable<Produto> {
    //Atributos
    private int id;
    private int qtd;
    private string descricao;
    private double valor;
    private string fabricante;
    private int categoriaId;
    private Categoria categoria;

    //Propriedades e construtor sem parâmetros públicos necessários para a serialização
    public int Id {get => id; set => id = value;}
    public int Qtd {get => qtd; set => qtd = value;}
    public string Descricao {get => descricao; set => descricao = value;}
    public double Valor {get => valor; set => valor = value;}
    public string Fabricante {get => fabricante; set => fabricante = value;}
    public int CategoriaId {get => categoriaId; set => categoriaId = value;}
    public Produto(){ }
    
    //Construtor 1
    public Produto(int id, string descricao, string fabricante, int qtd, double valor){
        this.id = id;
        this.descricao = descricao;
        this.fabricante = fabricante;
        this.qtd = qtd > 0 ? qtd : 0;
        this.valor = valor > 0 ? valor : 0;
    }

    //Construtor 2
    public Produto(int id, string descricao, string fabricante, int qtd, double valor, Categoria categoria) : this(id, descricao, fabricante, qtd, valor){
        this.categoria = categoria;
        this.categoriaId = categoria.GetId();
    }

    //Construtor 3
    public Produto(string descricao, string fabricante, int qtd, double valor, Categoria categoria){
        this.descricao = descricao;
        this.fabricante = fabricante;
        this.qtd = qtd > 0 ? qtd : 0;
        this.valor = valor > 0 ? valor : 0;
        this.categoria = categoria;
        this.categoriaId = categoria.GetId();
    }

    public int CompareTo(Produto produto) {
        return this.GetCategoria().GetId().CompareTo(produto.GetCategoria().GetId());
    }
    
    //Sets
    public void SetId(int id){
        this.id = id;
    }

    public void SetDescricao(string descricao){
        this.descricao = descricao;
    }

    public void SetFabricante(string fabricante){
        this.fabricante = fabricante;
    }
    
    public void SetQtd(int qtd){
        this.qtd = qtd > 0 ? qtd : 0;
    }

    public void SetValor(double valor){
        this.valor = valor > 0 ? valor : 0;
    }

    public void SetCategoria(Categoria categoria){
        this.categoria = categoria;
        categoriaId = categoria.GetId();
    }

    //Gets
    public int GetId(){
        return id;
    }

    public string GetDescricao(){
        return descricao;
    }
    
    public string GetFabricante(){
        return fabricante;
    }
    
    public int GetQtd(){
        return qtd;
    }

    public double GetValor(){
        return valor;
    }

    public Categoria GetCategoria(){
        return categoria;
    }
    
    //Formatação 
    public override string ToString(){
        if (categoria == null){
            return "- " + descricao + ", " + fabricante + $"(Id: {id})" + "\n" + "  " + "Estoque: " + qtd + "\n" + "  " + "Valor: " + valor.ToString("R$ 0.00");
        }

        else{
            return "Categoria " + categoria.GetId() + ": " + categoria.GetDescricao() + "\n" + "- " + descricao + ", " + fabricante + $"(Id: {id})" + "\n" + "  " + "Estoque: " + qtd + "\n" + "  " + "Valor: " + valor.ToString("R$ 0.00");
        }       
            //Categoria 1: Telescópio
            //Telescópio 20mm Celestron (Id: 5)
            //Estoque: 5
            //Valor: R$ 250.00
    }
}