using System;

class Nproduto {
    private Produto[] produtos = new Produto[10];
    private int qtd_prod;

    //Método de inserir um produto no vetor de produtos
    public void Inserir(Produto produto){
        if (qtd_prod == produtos.Length){
            Array.Resize(ref produtos, 2 * produtos.Length);
        }
        produtos[qtd_prod] = produto; 
        qtd_prod++;

        //Recuperando categoria do produto
        Categoria categoria = produto.GetCategoria();
        if (categoria != null){
            categoria.ProdutoInserir(produto);
        }
    }

    //Listando todos produtos
    public Produto[] Listar(){
        Produto[] clprodutos = new Produto[qtd_prod]; 
        Array.Copy(produtos, clprodutos, qtd_prod);
        return clprodutos;
    }

    //Listando um produto baseado em seu ID
    public Produto Listar(int id){
        for (int i = 0; i < qtd_prod; i++){
            if (produtos[i].GetId() == id){
                return produtos[i];
            }
        }
        return null;
    }
}