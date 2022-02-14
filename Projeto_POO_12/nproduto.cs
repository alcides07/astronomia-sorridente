using System;
using System.Collections.Generic;

class Nproduto {
    private List<Produto> produtos = new List<Produto>();

    //Método de inserir um produto no vetor de produtos
    public void Inserir(Produto produto){
        int maiorId = 0;
        foreach(Produto p in produtos){
            if(p.GetId() > maiorId){
                maiorId = p.GetId();
            }
        }
        produto.SetId(maiorId + 1);        
        produtos.Add(produto); 
        
        //Recuperando categoria do produto
        Categoria categoria = produto.GetCategoria();
        if (categoria != null){
            categoria.ProdutoInserir(produto);
        }
    }

    //Listando todos produtos
    public List<Produto> Listar(){
        produtos.Sort();
        return produtos;
    }

    //Listando um produto baseado em seu ID
    public Produto Listar(int id){
        for (int i = 0; i < produtos.Count; i++){
            if (produtos[i].GetId() == id){
                return produtos[i];
            }
        }
        return null;
    }

    //Atualizar Produto
    public void Atualizar(Produto produto){
        Produto atualProd = Listar(produto.GetId());
        if (atualProd == null){ //Não encontrou o ID na lista de categorias 
            return;
        }

        atualProd.SetDescricao(produto.GetDescricao());
        atualProd.SetFabricante(produto.GetFabricante());
        atualProd.SetQtd(produto.GetQtd());
        atualProd.SetValor(produto.GetValor());

        //Excluir o produto da antiga categ
        if(atualProd.GetCategoria() != null){
            atualProd.GetCategoria().ProdutoExcluir(atualProd);
        }

        //Atualiza a categoria do produto
        atualProd.SetCategoria(produto.GetCategoria());

        //Inserir o produto na nova categoria
        if (atualProd.GetCategoria() != null){
            atualProd.GetCategoria().ProdutoInserir(atualProd);  
        }
    }

    //Excluir Produto
    public void Excluir(Produto produto){
        //Remove a categoria da lista
        if (produto != null){
            produtos.Remove(produto);
        }
        
        //Remover produto da categoria
        Categoria categoria = produto.GetCategoria();
        if (categoria != null){
            categoria.ProdutoExcluir(produto);
        }
    }
}