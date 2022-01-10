using System;

class Categoria {
    //Atributos
    private int id;
    private string descricao;
    private Produto[] produtos = new Produto[10];
    private int qtd_prod;

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

    //Métodos
    public Produto[] ProdutoListar(){
        Produto[] clprodutos = new Produto[qtd_prod];
        Array.Copy(produtos, clprodutos, qtd_prod); 
        return clprodutos;
    }
    
    public void ProdutoInserir(Produto produto){
        if (qtd_prod == produtos.Length){
            Array.Resize(ref produtos, 2 * produtos.Length);
        }
        produtos[qtd_prod] = produto; 
        qtd_prod++;
    }
    
    

    //Formatação
    public override string ToString(){
        return id + " - " + descricao + "\n" + "Contém: " + qtd_prod + " produto(s)";
    }
}