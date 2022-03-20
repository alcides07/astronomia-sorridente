using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;

class Nproduto {
    private Nproduto(){}
    static Nproduto nprod_obj = new Nproduto();
    public static Nproduto Singleton{ get => nprod_obj; }

    private List<Produto> produtos = new List<Produto>();

    //Abrindo um arquivo de dados com as categorias
    public void Abrir(){
        Arquivo <List<Produto>> arquivo_prod = new Arquivo <List<Produto>>();
        produtos = arquivo_prod.Abrir("Projeto_POO_14/produtos.xml");
        AtualizarCategoria();
    }

    //Salvando as categorias cadastradas em um arquivo xml
    public void Salvar(){
        Arquivo <List<Produto>> arquivo_prod = new Arquivo <List<Produto>>();
        arquivo_prod.Salvar("Projeto_POO_14/produtos.xml", produtos);
    }

    private void AtualizarCategoria(){
        //Percorrer a lista de produtos para atualizar a categoria de cada produto
        for(int i = 0; i < produtos.Count; i++){
            Produto produto = produtos[i];
            
            //Recuperando a categoria do produto percorrido
            Categoria categoria = Ncategoria.Singleton.Listar(produto.CategoriaId);
        
            //Inserindo o produto de volta em sua categoria (refazendo associação)
            if (categoria != null){
                produto.SetCategoria(categoria); // Dizendo a qual categoria aquele produto pertence
                categoria.ProdutoInserir(produto); // Inserindo o produto de volta em sua categoria
            }
        }
    }

    //Método de inserir um produto no vetor de produtos
    public void Inserir(Produto produto){
        int maiorId = 0;
        maiorId = produtos.Max(maiorI => maiorI.GetId());
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
        return produtos.FirstOrDefault(prod => prod.GetId() == id);
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