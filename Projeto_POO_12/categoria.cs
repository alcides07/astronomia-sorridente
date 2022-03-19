using System;
//Testando

class Categoria : IComparable<Categoria> {
    //Atributos
    private int id;
    public string descricao { get; set; }
    private Produto[] produtos = new Produto[10];
    private int qtd_prod;

    //Construtor
    public Categoria(string descricao){
       this.descricao = descricao; 
    }

    public int CompareTo(Categoria categoria) {
        return this.descricao.CompareTo(categoria.descricao);
    }
    
    public Categoria(int id, string descricao){
       this.id = id;
       this.descricao = descricao; 
    }

    //Sets
    public void SetId(int id){
        this.id = id;
    }

    //Gets
    public int GetId(){
        return id;
    }
    
    //Métodos

    //Listar Produto
    public Produto[] ProdutoListar(){
        Produto[] clprodutos = new Produto[qtd_prod];
        Array.Copy(produtos, clprodutos, qtd_prod); 
        return clprodutos;
    }

    //Inserir Produto
    public void ProdutoInserir(Produto produto){
        if (qtd_prod == produtos.Length){
            Array.Resize(ref produtos, 2 * produtos.Length);
        }
        produtos[qtd_prod] = produto; 
        qtd_prod++;
    }

    //Coletar índice do produto
    private int ProdutoIndice(Produto produto){ 
        for (int i = 0; i < qtd_prod; i++){
            if (produtos[i] == produto){
                return i;
            }
        }
        return -1;
    }
    
    //Excluir Produto pelo seu Indice
    public void ProdutoExcluir(Produto produto){ 
        int indice = ProdutoIndice(produto);
        if (indice == -1){
            return;
        }
        //Deslocando o vetor de produtos
        for(int i = indice; i < qtd_prod - 1; i++){
            produtos[i] = produtos[i + 1];
        }
        qtd_prod--;
    }
    
    //Formatação
    public override string ToString(){
        return descricao + ($"(Id: {id})") + "\n" + "Contém: " + qtd_prod + " produto(s)";
    }
}
