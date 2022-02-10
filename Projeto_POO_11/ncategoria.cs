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

    //Atuaizando as categorias
    public void Atualizar(Categoria categoria){ //Informando uma nova categoria
        
        //Localizar no vetor a categoria pelo id
        Categoria antigaCateg = Listar(categoria.GetId()); //Procurando o novo ID na listagem atual
        if (antigaCateg == null){ //Não encontrou o ID novo na categoria antiga
            return;
        }

        //Alterar dados da Categoria
        antigaCateg.SetDescricao(categoria.GetDescricao()); //Altera a descrição antiga pela nova
    }

    //Procurando índice da Categoria informada
    private int Indice(Categoria categoria){
        for (int i = 0; i < qtd_categ; i++){
            if (categorias[i] == categoria){ //Encontrei a categoria que informei.
                return i; //Retorno do índice
            }
        }
        return -1;
    }

    //Excluindo categorias
    public void Excluir(Categoria categoria){
        //Verificando se a categoria está cadastrada
        int indice = Indice(categoria);
        if (indice == -1){
            return;
        }
        
        //Deslocando o vetor para a esquerda
        for (int i = indice; i < qtd_categ - 1; i++){ 
            categorias[i] = categorias[i + 1]; 
        }
        qtd_categ --;
        
        //Recuperar prods da categ excluída para deixá-los sem categ
        Produto[] produtos = categoria.ProdutoListar();
        
        foreach(Produto p in produtos){
            p.SetCategoria(null);
        }
    }
}