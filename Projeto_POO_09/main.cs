using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass{
    private static Ncategoria ncategoria = new Ncategoria();
    private static Nproduto nproduto = new Nproduto();
    private static Ncliente ncliente = new Ncliente();
    public static void Main(){     
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

        Console.WriteLine("");
        Console.WriteLine("Loja Astronomia Sorridente: Encurtando distâncias astronômicas até você");
        Console.WriteLine("");
        int operacao = -1;
        while (operacao != 0){
            try{
                operacao = Menu();
                switch(operacao){
                    case  0: Console.WriteLine("Ao infinito e além!"); break;
                    case  1: CategoriaListar(); break;
                    case  2: CategoriaInserir(); break;
                    case  3: CategoriaAtualizar(); break;
                    case  4: CategoriaExcluir(); break;
                    case  5: ProdutoListar(); break;
                    case  6: ProdutoInserir(); break;
                    case  7: ProdutoAtualizar(); break;
                    case  8: ProdutoExcluir(); break;
                    case  9: ClienteListar(); break;
                    case 10: ClienteInserir(); break;
                    case 11: ClienteAtualizar(); break;
                    case 12: ClienteExcluir(); break;
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
        Console.WriteLine("01 - Listar Categorias");
        Console.WriteLine("02 - Inserir Categoria");
        Console.WriteLine("03 - Atualizar Categoria");
        Console.WriteLine("04 - Excluir Categoria");
        Console.WriteLine("05 - Listar Produto");
        Console.WriteLine("06 - Inserir Produto");
        Console.WriteLine("07 - Atualizar Produto");
        Console.WriteLine("08 - Excluir Produto");
        Console.WriteLine("09 - Listar Cliente");
        Console.WriteLine("10 - Inserir Cliente");
        Console.WriteLine("11 - Atualizar Cliente");
        Console.WriteLine("12 - Excluir Cliente");
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


    /////////////////////////////// CLIENTE //////////////////////////////////

    //Método Listar Clientes
    public static void ClienteListar(){
        Console.WriteLine("----------- Listando Clientes -----------");
        List<Cliente> l_clientes = ncliente.Listar();
        if (l_clientes.Count == 0){
            Console.WriteLine("Nenhum cliente cadastrado.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < l_clientes.Count; i++){
            Console.WriteLine(l_clientes[i]);
            Console.WriteLine("");
        }
    }

    //Método Inserir Cliente
    public static void ClienteInserir(){
        Console.WriteLine("----------- Inserindo Clientes -----------");
                
        //Nome do cliente
        Console.Write("Informe o nome do cliente: ");
        string Nome = Console.ReadLine();

        //Data de nascimento do cliente
        Console.Write("Informe a data de nascimento do cliente (dd/mm/aaaa): ");
        DateTime Nascimento = DateTime.Parse(Console.ReadLine());

        //Contato do cliente
        Console.Write("Informe o contato do cliente: ");
        string Contato = Console.ReadLine();

        //Endereço do cliente
        Console.Write("Informe o endereço do cliente: ");
        string Endereco = Console.ReadLine();
        Console.WriteLine("");
            
        //Instanciar classe de Cliente (criando um novo cliente)
        Cliente cliente = new Cliente{nome = Nome, nascimento = Nascimento, contato = Contato, endereco = Endereco};

        //Inserção de cliente na lista de clientes 
        ncliente.Inserir(cliente);

        //Mensagem de confirmação da operação
        Console.WriteLine($"Cliente {Nome} cadastrado com sucesso!");
        Console.WriteLine("");
    }

    //Método Atualizar Cliente
    public static void ClienteAtualizar(){
        Console.WriteLine("----------- Atualizando Cliente -----------");
        ClienteListar();
        
        //Id do Cliente
        Console.Write("Informe o Id do cliente que deseja atualizar: ");
        int Id = int.Parse(Console.ReadLine());
        
        //Nome do cliente
        Console.Write("Informe novamente o nome do cliente: ");
        string Nome = Console.ReadLine();

        //Data de nascimento do cliente
        Console.Write("Informe novamente a data de nascimento do cliente (dd/mm/aaaa): ");
        DateTime Nascimento = DateTime.Parse(Console.ReadLine());

        //Contato do cliente
        Console.Write("Informe novamente o contato do cliente: ");
        string Contato = Console.ReadLine();

        //Endereço do cliente
        Console.Write("Informe novamente o endereço do cliente: ");
        string Endereco = Console.ReadLine();
        Console.WriteLine("");

        //Instanciar classe de Cliente (criando um novo cliente)
        Cliente cliente = new Cliente{id = Id, nome = Nome, nascimento = Nascimento, contato = Contato, endereco = Endereco};

        //Atualização do cliente na lista de clientes 
        ncliente.Atualizar(cliente);

        //Mensagem de confirmação
        Console.WriteLine($"Cliente {Nome} atualizado com sucesso!");
        Console.WriteLine("");
    }

    //Método Excluir Cliente
    public static void ClienteExcluir(){
        Console.WriteLine("----------- Excluindo Cliente -----------");
        ClienteListar();
        
        //Id do Cliente
        Console.Write("Informe o Id do cliente que deseja excluir: "); 
        int Id = int.Parse(Console.ReadLine());

        //Procurando o cliente
        Cliente cliente = ncliente.Listar(Id);

        //Mensagem de confirmação
        Console.WriteLine($"Cliente {cliente.nome} excluído com sucesso!");
        Console.WriteLine("");

        //Exclui a categoria
        ncliente.Excluir(cliente);
    }     
}