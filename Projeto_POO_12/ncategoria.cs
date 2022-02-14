using System;
using System.Collections.Generic;

class Ncategoria {
    private List<Categoria> categorias = new List<Categoria>();

    public void Inserir(Categoria categoria){
        int maiorId = 0;
        foreach(Categoria c in categorias){
            if(c.GetId() > maiorId){
                maiorId = c.GetId();
            }
        }
        categoria.SetId(maiorId + 1);        
        categorias.Add(categoria); 
    }

    public List<Categoria> Listar(){
        categorias.Sort();
        return categorias;
    }

    public Categoria Listar(int id){
        for (int i = 0; i < categorias.Count; i++){
            if (categorias[i].GetId() == id){
                return categorias[i];
            }
        }
        return null;
    }

    //Atualizando as categorias
    public void Atualizar(Categoria categoria){ //Informando uma nova categoria
        
        //Localizar no vetor a categoria pelo id
        Categoria atualCateg = Listar(categoria.GetId()); //Procurando o atual ID na listagem atual
        if (atualCateg == null){ //Não encontrou o ID na lista de categorias 
            return;
        }

        //Alterar dados da categoria
        atualCateg.descricao = categoria.descricao; //Altera a descrição antiga pela nova
    }

    public void Excluir(Categoria categoria){   
        //Remove a categoria da lista
        if (categoria != null){
            categorias.Remove(categoria);
            //Recuperar prods da categ excluída para deixá-los sem categ
            Produto[] produtos = categoria.ProdutoListar();
            foreach(Produto p in produtos){
                p.SetCategoria(null);
            }
        }
    }
}