using System;

class MainClass{
    private static Ncategoria ncategoria = new Ncategoria();
    private static Nproduto nproduto = new Nproduto();
    public static void Main(){     
        Console.WriteLine("");
        Console.WriteLine("Loja Astronomia Sorridente: Encurtando distâncias astronômicas até você");
        Console.WriteLine("");
        int operacao = -1;
        while (operacao != 0){
            try{
                operacao = Menu();
                switch(operacao){
                    case 0: Console.WriteLine("Ao infinito e além!"); break;
                    case 1: CategoriaListar(); break;
                    case 2: CategoriaInserir(); break;
                    case 3: CategoriaAtualizar(); break;
                    case 4: CategoriaExcluir(); break;
                    case 5: ProdutoListar(); break;
                    case 6: ProdutoInserir(); break;
                    case 7: ProdutoAtualizar(); break;
                    case 8: ProdutoExcluir(); break;
                    default:
                        Console.WriteLine("A opção informada não é válida!");
                        break;
                }
            }
            catch (Exception){
                Console.WriteLine("A opção informada não é válida!");
                Console.WriteLine("");
            }
        }
    }
    
    //Menu
    public static int Menu(){
        Console.WriteLine("----------- Opções Disponíveis -----------");
        Console.WriteLine("1 - Listar Categorias");
        Console.WriteLine("2 - Inserir Categoria");
        Console.WriteLine("3 - Atualizar Categoria");
        Console.WriteLine("4 - Excluir Categoria");
        Console.WriteLine("5 - Listar Produto");
        Console.WriteLine("6 - Inserir Produto");
        Console.WriteLine("7 - Atualizar Produto");
        Console.WriteLine("8 - Excluir Produto");
        Console.WriteLine("0 - Encerrar operações");
        Console.WriteLine("");
        Console.Write("Informe a operação: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return operacao;
    }
    
    ////////////////////////////// CATEGORIA /////////////////////////////

    //Método Listar Categorias
    public static void CategoriaListar(){
        Console.WriteLine("----------- Listando Categorias -----------");
        Categoria[] v_categorias = ncategoria.Listar();
        if (v_categorias.Length == 0){
            Console.WriteLine("Nenhuma categoria cadastrada.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < v_categorias.Length; i++){
            Console.WriteLine(v_categorias[i]);
            Console.WriteLine("");
        }
    }

    //Método Inserir Categoria
    public static void CategoriaInserir(){
        Console.WriteLine("----------- Inserindo Categorias -----------");
        //Id como contador a fim de deixar em ordem ou ordenar apenas na hora de printar a lista de categorias.
        
        //Id da categoria
        Console.Write("Informe um Id para a categoria: "); 
        int id = int.Parse(Console.ReadLine());
        
        ////Descrição da categoria
        Console.Write("Informe uma descrição para a categoria: ");
        string descricao = Console.ReadLine();
        Console.WriteLine("");

        //Instanciar classe de Categoria (criando uma nova categoria)
        Categoria categoria = new Categoria(id, descricao);

        //Inserção da categoria na lista de categorias 
        ncategoria.Inserir(categoria);

        //Mensagem de confirmação
        Console.WriteLine($"Categoria {descricao} cadastrada com sucesso!");
        Console.WriteLine("");
    }

    //Método Atualizar Categoria
    public static void CategoriaAtualizar(){
        Console.WriteLine("----------- Atualizando Categoria -----------");
        CategoriaListar();
        
        //Id
        Console.Write("Informe o Id da categoria que deseja atualizar: ");
        int id = int.Parse(Console.ReadLine());
        
        //Descrição da categoria
        Console.Write("Informe uma nova descrição para a categoria: ");
        string descricao = Console.ReadLine();
        Console.WriteLine("");

        //Instanciar classe de Categoria (criando uma nova categoria)
        Categoria categoria = new Categoria(id, descricao);

        //Inserção da categoria na lista de categorias 
        ncategoria.Atualizar(categoria);

        //Mensagem de confirmação
        Console.WriteLine($"Categoria atualizada para {descricao} com sucesso!");
        Console.WriteLine("");
    }

    //Método Excluir Categoria
    public static void CategoriaExcluir(){
        Console.WriteLine("----------- Excluindo Categoria -----------");
        CategoriaListar();
        
        //Id
        Console.Write("Informe o Id da categoria que deseja excluir: "); 
        int id = int.Parse(Console.ReadLine());

        //Procurando a categoria
        Categoria categoria = ncategoria.Listar(id);

        //Mensagem de confirmação
        Console.WriteLine($"Categoria {categoria.GetDescricao()} excluída com sucesso!");
        Console.WriteLine("");

        //Exclui a categoria
        ncategoria.Excluir(categoria);
    }

    ////////////////////////////// PRODUTO /////////////////////////////

    //Método Listar Produto
    public static void ProdutoListar(){
        Console.WriteLine("----------- Listando Produtos -----------");
        Produto[] v_produtos = nproduto.Listar();
        if (v_produtos.Length == 0){
            Console.WriteLine("Nenhum produto cadastrado.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < v_produtos.Length; i++){
            Console.WriteLine(v_produtos[i]);
            Console.WriteLine("");
        }
    }

    //Método Inserir Produto
    public static void ProdutoInserir(){
        Console.WriteLine("----------- Inserindo Produtos -----------");

        //Id como contador a fim de deixar em ordem ou ordenar apenas na hora de printar a lista de produtos.
        //Id do produto
        Console.Write("Informe um Id para o produto: "); 
        int id = int.Parse(Console.ReadLine());

        //Descrição do produto
        Console.Write("Informe uma descrição para o produto: ");
        string descricao = Console.ReadLine();

        //Fabricante
        Console.Write("Informe o fabricante do produto: ");
        string fabricante = Console.ReadLine();
        
        //Quantidade de produtos
        Console.Write("Informe o estoque do produto: ");
        int qtd = int.Parse(Console.ReadLine());

        //Valor do produto
        Console.Write("Informe um valor para o produto: ");
        double valor = double.Parse(Console.ReadLine());
        Console.WriteLine("");

        //Listar categorias para depois inserir produto
        CategoriaListar();

        //Número da categoria do produto
        Console.WriteLine("----------- Inserindo Produto em uma Categoria -----------");
        Console.Write("Informe o id da categoria do produto: ");
        int IdCategoria = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        
        //Selecionar categoria com Id
        Categoria categoria = ncategoria.Listar(IdCategoria);
        
        //Instanciar classe de Produto (criando um novo produto)
        Produto produto = new Produto(id, descricao, fabricante, qtd, valor, categoria);

        //Inserção do produto na lista de produtos 
        nproduto.Inserir(produto);  

        //Mensagem de confirmação
        Console.WriteLine($"Produto {descricao} adicionado com sucesso na categoria {categoria.GetDescricao()}.");
        Console.WriteLine("");
    }

    //Método Atualizar Produto
    public static void ProdutoAtualizar(){
        Console.WriteLine("----------- Atualizando Produto -----------");
        ProdutoListar();

        //Id
        Console.Write("Informe o Id do produto que deseja atualizar: "); 
        int id = int.Parse(Console.ReadLine());

        //Descrição do produto
        Console.Write("Informe uma descrição para o produto: ");
        string descricao = Console.ReadLine();

        //Fabricante
        Console.Write("Informe o fabricante do produto: ");
        string fabricante = Console.ReadLine();
        
        //Quantidade de produtos
        Console.Write("Informe o estoque do produto: ");
        int qtd = int.Parse(Console.ReadLine());

        //Valor do produto
        Console.Write("Informe um valor para o produto: ");
        double valor = double.Parse(Console.ReadLine());
        Console.WriteLine("");

        //Listar categorias para depois inserir produto
        CategoriaListar();

        //Número da categoria do produto
        Console.WriteLine("----------- Inserindo Produto em uma Categoria -----------");
        Console.Write("Informe o número da categoria do produto: ");
        int IdCategoria = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        
        //Selecionar categoria com Id
        Categoria categoria = ncategoria.Listar(IdCategoria);
        
        //Instanciar classe de Produto (criando um novo produto)
        Produto produto = new Produto(id, descricao, fabricante, qtd, valor, categoria);

        //Atualização do produto na lista de produtos 
        nproduto.Atualizar(produto);  

        //Mensagem de confirmação
        Console.WriteLine($"Produto {descricao} da categoria {categoria.GetDescricao()} atualizado com sucesso!");
        Console.WriteLine("");
    }

    //Método Excluir Produto
    public static void ProdutoExcluir(){
        Console.WriteLine("----------- Excluindo Produto -----------");
        ProdutoListar();
        
        //Id
        Console.Write("Informe o Id do produto que deseja excluir: "); 
        int id = int.Parse(Console.ReadLine());

        //Procurando o produto pelo id
        Produto produto = nproduto.Listar(id);

        //Mensagem de confirmação
        Console.WriteLine($"Produto {produto.GetDescricao()} excluído com sucesso!");
        Console.WriteLine("");

        //Exclui o produto
        nproduto.Excluir(produto);
        
    }
     
}