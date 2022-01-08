using System;

class MainClass{
    public static void Main(){
        
    //Categorias
    Console.WriteLine("");
    Console.WriteLine("----------- Categorias -----------");
    Categoria c1 = new Categoria(1, "Telescópios");
    Categoria c2 = new Categoria(2, "Binóculos");
    Categoria c3 = new Categoria(3, "Souvenirs");
    
    //Prints - Categorias
    Console.WriteLine(c1);
    Console.WriteLine(c2);
    Console.WriteLine(c3);
    
    //Produtos
    Console.WriteLine("");
    Console.WriteLine("----------- Produtos -----------");
    Produto p1 = new Produto(1, "Telescópio Newtoniano - 150mm", "Blueditec", 15, 1500.00);
    Produto p2 = new Produto(2, "Binóculo", "Blueditec", 18, 500.00);
    Produto p3 = new Produto(3, "Chaveiro", "Apollo 11", 25, 10.00);

    //Prints - Produtos
    Console.WriteLine(p1);
    Console.WriteLine("");
    Console.WriteLine(p2);
    Console.WriteLine("");
    Console.WriteLine(p3);
  }
}

class Categoria {
    //Atributos
    private int id;
    private string descricao;
    
    //Construtor
    public Categoria(int id, string descricao){
       this.id = id;
       this.descricao = descricao; 
    }
    
    //Sets
    public void SetId(int id){
        this.id = id;
    }
    public void SetDescricao(string descricao){
        this.descricao = descricao;
    }

    //Gets
    public int GetId(){
        return id;
    }

    public string GetDescricao(){
        return descricao;
    }

    //Formatação
    public override string ToString(){
        return id + " - " + descricao;
    }
}

class Produto {
    //Atributos
    private int id;
    private int qtd;
    private string descricao;
    private double valor;
    private string fabricante;
    
    //Construtor
    public Produto(int id, string descricao, string fabricante, int qtd, double valor){
        this.id = id;
        this.descricao = descricao;
        this.fabricante = fabricante;
        this.qtd = qtd > 0 ? qtd : 0;
        this.valor = valor > 0 ? valor : 0;
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

    public void SetValor(int valor){
        this.valor = valor > 0 ? valor : 0;
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
    
    //Formatação 
    public override string ToString() {
        return id + " - " + descricao + ", " + fabricante + "\n" + "Estoque: " + qtd + "\n" + "Valor: " + valor.ToString("R$ 0.00");
    }
}