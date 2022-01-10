using System;

class Ncategoria {
    private Categoria[] categorias = new Categoria[10];
    private int qtd_categ;

    //Método de inserir uma categoria no vetor de categorias
    public void Inserir(Categoria categoria){
        if (qtd_categ == categorias.Length){
            Array.Resize(ref categorias, 2 * categorias.Length);
        }
        categorias[qtd_categ] = categoria; 
        qtd_categ++;
    }

    //Listando todas as categorias
    public Categoria[] Listar(){
        Categoria[] clcategorias = new Categoria[qtd_categ]; 
        Array.Copy(categorias, clcategorias, qtd_categ);
        return clcategorias;
    }

    //Listando uma categoria baseado em seu ID
    public Categoria Listar(int id){
        for (int i = 0; i < qtd_categ; i++){
            if (categorias[i].GetId() == id){
                return categorias[i];
            }
        }
        return null;
    }
}