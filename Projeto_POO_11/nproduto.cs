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

    //Atualizar Produto
    public void Atualizar(Produto produto){
        //Alterar atributos
        Produto antigoProd = Listar(produto.GetId());
        antigoProd.SetDescricao(produto.GetDescricao());
        antigoProd.SetFabricante(produto.GetFabricante());
        antigoProd.SetQtd(produto.GetQtd());
        antigoProd.SetValor(produto.GetValor());

        //Excluir o produto da antiga categ
        if(antigoProd.GetCategoria() != null){
            antigoProd.GetCategoria().ProdutoExcluir(antigoProd);
        }

        //Atualiza a categoria do produto
        antigoProd.SetCategoria(produto.GetCategoria());

        //Inserir o produto na nova categoria
        if (antigoProd.GetCategoria() != null){
            antigoProd.GetCategoria().ProdutoInserir(antigoProd);  
        }
    }

    //Localizar Produto pelo seu índice
    private int Indice(Produto produto) {
        for (int i = 0; i < qtd_prod; i++){
            if (produtos[i] == produto){
                return i;
            }
        }
        return -1;
    }

    //Excluir Produto
    public void Excluir(Produto produto){
        //Verificar se o produto existe
        int indice = Indice(produto);
        if (indice == -1){
            return;
        }
        //Removendo produto da lista de produtos
        for (int i = indice; i < qtd_prod - 1; i++){
            produtos[i] = produtos[i + i];
        }
         qtd_prod--;
        
        //Remover produto da categoria
        Categoria categoria = produto.GetCategoria();
        if (categoria != null){
            categoria.ProdutoExcluir(produto);
        }
    }

}