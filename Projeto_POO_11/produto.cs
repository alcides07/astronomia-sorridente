using System;

class Produto{
    //Atributos
    private int id;
    private int qtd;
    private string descricao;
    private double valor;
    private string fabricante;
    private Categoria categoria;
    
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
            return id + " - " + descricao + " " + fabricante + "\n" + "Estoque: " + qtd + "\n" + "Valor: " + valor.ToString("R$ 0.00");
        }

        else{
            return "Categoria " + categoria.GetId() + ": " + categoria.GetDescricao() + "\n" + id + " - " + descricao + " " + fabricante + "\n" + "Estoque: " + qtd + "\n" + "Valor: " + valor.ToString("R$ 0.00");
        }
    }
}