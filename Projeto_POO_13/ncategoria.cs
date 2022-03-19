using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Ncategoria {
    private Ncategoria(){}
    static Ncategoria ncateg_obj = new Ncategoria();
    public static Ncategoria Singleton{ get => ncateg_obj; }

    private List<Categoria> categorias = new List<Categoria>();

    //Abrindo um arquivo de dados com as categorias
    public void Abrir(){
        Arquivo <List<Categoria>> arquivo_categ = new Arquivo <List<Categoria>>();
        categorias = arquivo_categ.Abrir("Projeto_POO_13/categorias.xml");
    }

    //Salvando as categorias cadastradas em um arquivo xml
    public void Salvar(){
        Arquivo <List<Categoria>> arquivo_categ = new Arquivo <List<Categoria>>();
        arquivo_categ.Salvar("Projeto_POO_13/categorias.xml", categorias);
    }

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
        atualCateg.SetDescricao(categoria.GetDescricao()); //Altera a descrição antiga pela nova
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