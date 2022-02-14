using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass{
    public static bool primeiro_acesso = true;
    private static Ncategoria ncategoria = new Ncategoria();
    private static Nproduto nproduto = new Nproduto();
    private static Ncliente ncliente = new Ncliente();
    private static Nvenda nvenda = new Nvenda();
    private static Nfeedback nfeedback = new Nfeedback();

    private static Cliente clienteLogin = null;
    private static Venda clienteVenda = null;
    
    public static void Main(){     
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

        Console.WriteLine("");
        Console.WriteLine("Loja Astronomia Sorridente: Encurtando distâncias astronômicas até você!");
        Console.WriteLine("");
        int operacao = -1;
        int perfil = 0;
        while (operacao != 0){
            try{
                if (perfil == 0){
                    operacao = -1;
                    perfil = MenUsuario();
                    if (perfil == 0){
                        Console.WriteLine("Ao infinito e além!");
                        break;
                    }
                }

                //Perfil do vendedor
                if (perfil == 1){
                    operacao = MenuVendedor();
                    switch(operacao){
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
                        case 13: VendaListar(); break;
                        case 14: FeedbackListar(); break;
                        case 99: perfil = 0; break;
                        default:
                            Console.WriteLine("A opção informada não é válida!");
                            break;
                    }
                }
            
                //Perfil do cliente sem login feito
                if (perfil == 2 && clienteLogin == null){
                    operacao = MenuClienteLogin();
                    switch(operacao){
                        case  1:  ClienteLogin(); primeiro_acesso = true; break;
                        case  99: perfil = 0; break;
                    }
                }

                //Perfil do cliente com login feito
                if (perfil == 2 && clienteLogin != null){
                    if (primeiro_acesso){ 
                        Console.WriteLine("");
                        Console.WriteLine("Bem vindo(a), astrônomo(a) " + clienteLogin.nome + "!");
                        primeiro_acesso = false;
                    }
                    //Bem vindo(a), pequeno(a) astrônomo(a) fulaninho!
                    //Bem vindo(a), fulaninho e astrônomo(a) curioso(a)!
                    //Bem vindo(a), fulaninho encantado(a) por Astronomia!
                    //Bem vindo(a), fulaninho astronômo(a) encantador(a)!
                    //Bem vindo(a), explorador(a) da Astronomia fulaninho!
                    //Bem vindo(a), 
                    operacao = MenuClienteLogout();
                    switch(operacao){
                        case  1: ClienteProdutoListar(); break;
                        case  2: ClienteProdutoInserir(); break;
                        case  3: ClienteCarrinhoVisualizar(); break;
                        case  4: ClienteCarrinhoComprar(); break;
                        case  5: ClienteCarrinhoEsvaziar(); break;
                        case  6: ClienteVendaListar(); break;
                        case  7: ClienteFeedbackEnviar(); break; 
                        case 99: ClienteLogout(); break;
                    }
                }
            }
            catch (Exception){
                Console.WriteLine("A opção informada não é válida!");
                Console.WriteLine("");
            }
        }
    }

    ////////////////////////////// USUÁRIO /////////////////////////////
    
    public static int MenUsuario(){
        Console.WriteLine("----------- Opções Disponíveis -----------");
        Console.WriteLine("01 - Entrar como Vendedor");
        Console.WriteLine("02 - Entrar como Cliente");
        Console.WriteLine("00 - Encerrar operações");
        Console.WriteLine("");
        Console.Write("Informe a operação: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return operacao;
    }

    ////////////////////////////// VENDEDOR /////////////////////////////

    public static int MenuVendedor(){
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
        Console.WriteLine("13 - Listar Vendas");
        Console.WriteLine("14 - Listar Feedbacks");
        Console.WriteLine("99 - Voltar");
        //Console.WriteLine("00 - Encerrar operações");
        Console.WriteLine("");
        Console.Write("Informe a operação: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return operacao;
    }

    ////////////////////////////// CLIENTE /////////////////////////////

    //Login
    public static int MenuClienteLogin(){
        Console.WriteLine("----------- Opções Disponíveis -----------");
        Console.WriteLine("01 - Realizar Login");
        Console.WriteLine("99 - Voltar");
        //Console.WriteLine("00 - Encerrar operações");
        Console.WriteLine("");
        Console.Write("Informe a operação: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return operacao;
    }

    //Logout
    public static int MenuClienteLogout(){
        Console.WriteLine("");
        Console.WriteLine("----------- Escolha uma opção -----------");
        Console.WriteLine("01 - Visualizar produtos disponíveis");
        Console.WriteLine("02 - Inserir produto no carrinho");
        Console.WriteLine("03 - Visualizar carrinho de compras");
        Console.WriteLine("04 - Confirmar compra");
        Console.WriteLine("05 - Esvaziar carrinho");
        Console.WriteLine("06 - Visualizar minhas compras");
        Console.WriteLine("07 - Enviar feedback");
        Console.WriteLine("99 - Realizar logout");
        //Console.WriteLine("00 - Encerrar operações");
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
        List<Categoria> l_categorias = ncategoria.Listar();
        if (l_categorias.Count == 0){
            Console.WriteLine("Nenhuma categoria cadastrada.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < l_categorias.Count; i++){
            Console.WriteLine(l_categorias[i]);
            Console.WriteLine("");
        }
    }

    //Método Inserir Categoria
    public static void CategoriaInserir(){
        Console.WriteLine("----------- Inserindo Categorias -----------");
        //Id como contador a fim de deixar em ordem ou ordenar apenas na hora de printar a lista de categorias.
                
        ////Descrição da categoria
        Console.Write("Informe uma descrição para a categoria: ");
        string descricao = Console.ReadLine();
        Console.WriteLine("");

        //Instanciar classe de Categoria (criando uma nova categoria)
        Categoria categoria = new Categoria(descricao);

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
        Console.WriteLine("");
        Console.WriteLine($"Categoria {categoria.descricao} excluída com sucesso!");
        Console.WriteLine("");

        //Exclui a categoria
        ncategoria.Excluir(categoria);
    }

    ////////////////////////////// PRODUTO /////////////////////////////

    //Método Listar Produto
    public static void ProdutoListar(){
        Console.WriteLine("----------- Listando Produtos -----------");
         List<Produto> l_produtos = nproduto.Listar();
        if (l_produtos.Count == 0){
            Console.WriteLine("Nenhum produto cadastrado.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < l_produtos.Count; i++){
            Console.WriteLine(l_produtos[i]);
            Console.WriteLine("");
        }
    }

    //Método Inserir Produto
    public static void ProdutoInserir(){
        Console.WriteLine("----------- Inserindo Produtos -----------");

        //Id do produto
        //Console.Write("Informe um Id para o produto: "); 
        //int id = int.Parse(Console.ReadLine());

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
        Produto produto = new Produto(descricao, fabricante, qtd, valor, categoria);

        //Inserção do produto na lista de produtos 
        nproduto.Inserir(produto);  

        //Mensagem de confirmação
        Console.WriteLine($"Produto {descricao} adicionado com sucesso na categoria {categoria.descricao}.");
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
        Console.WriteLine($"Produto {descricao} da categoria {categoria.descricao} atualizado com sucesso!");
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
        Console.WriteLine("");
        Console.WriteLine($"Produto {produto.GetDescricao()} excluído com sucesso!");
        Console.WriteLine("");

        //Exclui o produto
        nproduto.Excluir(produto);
    }

    /////////////////////////////// CLIENTE ///////////////////////////////

//---------------------------- AÇÃO DO VENDEDOR ----------------------------

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
        Console.Write("Informe a rua do cliente: ");
        string Endereco = Console.ReadLine();

        //Estado do cliente
        Console.Write("Informe o estado do cliente (XX): ");
        string Estado = Console.ReadLine();
        Console.WriteLine("");
            
        //Instanciar classe de Cliente (criando um novo cliente)
        Cliente cliente = new Cliente{nome = Nome, nascimento = Nascimento, contato = Contato, endereco = Endereco, estado = Estado};

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
        Console.Write("Informe novamente a rua do cliente: ");
        string Endereco = Console.ReadLine();

        //Estado do cliente
        Console.Write("Informe novamente o estado do cliente (XX): ");
        string Estado = Console.ReadLine();
        Console.WriteLine("");

        //Instanciar classe de Cliente (criando um novo cliente)
        Cliente cliente = new Cliente{id = Id, nome = Nome, nascimento = Nascimento, contato = Contato, endereco = Endereco, estado = Estado};

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

    //Listando vendas
    public static void VendaListar(){
        Console.WriteLine("----------- Visualizando Vendas -----------");
        //Lista todas as vendas de um cliente
        List<Venda> vendas = nvenda.Listar();
        if(vendas.Count == 0){ //Se o cliente nunca realizou uma venda
            Console.WriteLine("Nenhuma venda cadastrada.");
            Console.WriteLine("");
            return;
        }
        
        foreach(Venda v in vendas){ //Mostra todas as vendas realizadas
            Console.Write(v);
            foreach (VendaItem item in nvenda.ItemListar(v)){ //Mostra todos os itens de cada venda
                Console.WriteLine("\n" + item);
            }
            Console.WriteLine("");
        }
    }    

    public static void FeedbackListar(){
    Console.WriteLine("----------- Visualizando Feedbacks -----------");
    List<Feedback> l_feedbacks = nfeedback.Listar();
    if (l_feedbacks.Count == 0){
        Console.WriteLine("Nenhum feedback disponível.");
        Console.WriteLine("");
        return;
    }

    for (int i = 0; i < l_feedbacks.Count; i++){
        Console.WriteLine(l_feedbacks[i]);
        Console.WriteLine("");
    }
}

//---------------------------- AÇÃO DO CLIENTE ------------------------------

    //Login do Cliente
    public static void ClienteLogin(){
        Console.WriteLine("----------- Realizando Login -----------");
        ClienteListar();
        Console.Write("Informe o Id do cliente para logar: ");
        int Id = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        clienteLogin = ncliente.Listar(Id);
        clienteVenda = nvenda.ListarCarrinho(clienteLogin); //Abre o carrinho ao fazer login
    }

    //Logout do Cliente
    public static void ClienteLogout(){
        Console.WriteLine("----------- Realizando Logout -----------");
        if(clienteVenda != null){
            nvenda.Inserir(clienteVenda, true); //Guarda a compra ainda em andamento.
        }
        clienteLogin = null;
        clienteVenda = null;
    }

    //Listando Produtos
    public static void ClienteProdutoListar(){
        Console.WriteLine("----------- Visualizando Produtos -----------");
        //Lista os produtos cadastrados no siste
        ProdutoListar();
    }

    //Inserir Produto
    public static void ClienteProdutoInserir(){
        Console.WriteLine("----------- Inserindo Produto -----------");
        //Lista os produtos já cadastrados
        ProdutoListar();
        
        //Id do Produto
        Console.Write("Informe o Id do produto que deseja comprar: ");
        int Id = int.Parse(Console.ReadLine());
        
        //Quantidade do produto específico
        Console.Write("Informe quantas unidades do produto: ");
        int Qtd = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        
        //Procurando o produto pelo id
        Produto produto = nproduto.Listar(Id);

        //Verificação se o produto informado realmente existe
        if (produto != null){ 
            if(clienteVenda == null) { //Se o carrinho ainda não existe
                clienteVenda = new Venda(DateTime.Now, clienteLogin);
            }
            //Insere o produto no carrinho
            nvenda.ItemInserir(clienteVenda, Qtd, produto);
        }
        Console.WriteLine($"Produto {produto.GetDescricao()} inserido no carrinho com sucesso!");
        Console.WriteLine("");
    }

    //Visualizando Carrinho
    public static void ClienteCarrinhoVisualizar(){
        Console.WriteLine("----------- Visualizando Carrinho -----------");
        //Verifica se existe um carrinho de compra
        if(clienteVenda == null){
            Console.WriteLine("O carrinho está vazio!");
            return;
        }

        //Lista os produtos inseridos do carrinho
        List<VendaItem> itens = nvenda.ItemListar(clienteVenda);
        foreach(VendaItem item in itens){
            Console.WriteLine(item);
            Console.WriteLine("");
        }
    }
    
    //Finalizando uma compra
    public static void ClienteCarrinhoComprar(){
        Console.WriteLine("----------- Finalizando Compra -----------");
        if(clienteVenda == null){ //
            Console.WriteLine("O carrinho está vazio!"); //Não posso finalizar a compra com o carrinho vazio.
            return;
        }
        //Armazena a compra do cliente
        nvenda.Inserir(clienteVenda, false);
        
        //Disponibiliza um novo carrinho para o cliente
        clienteVenda = null;

        Console.WriteLine("Compra finalizada com sucesso! =)");
    }

    //Esvaziando um carrinho
    public static void ClienteCarrinhoEsvaziar(){
        Console.WriteLine("----------- Esvaziando Carrinho -----------");
        //Verificando se existe um carrinho para esvaziar
        if(clienteVenda != null){
            nvenda.ItensExcluir(clienteVenda);
            clienteVenda = null;
            Console.WriteLine("Carrinho esvaziado com sucesso!");
        }
        else{
            Console.WriteLine("O carrinho está vazio!");
        }
    }

    public static void ClienteVendaListar(){
        Console.WriteLine("----------- Visualizando Compras -----------");
        //Armazena todas as compras de um cliente
        List<Venda> vendas = nvenda.Listar(clienteLogin);
        
        if(vendas.Count == 0){ //Se o cliente nunca realizou uma compra
            Console.WriteLine("Nenhuma compra cadastrada.");
            return;
        }
        
        foreach(Venda v in vendas){ //Mostra todas as vendas de um cliente
            Console.Write(v);
            
            foreach (VendaItem item in nvenda.ItemListar(v)){ //Mostra todos os itens de cada venda
                Console.WriteLine("\n" + item);
            }
            Console.WriteLine("");
        }
    } 
    
    public static void ClienteFeedbackEnviar(){
        Console.WriteLine("----------- Enviando Feedback -----------");

        Console.Write("Digite o feedback desejado: ");
        string Mensagem = Console.ReadLine();

        if (Mensagem == null){
            return;
        }
        //Cliente cliente = ncliente.Listar(Id);
        Feedback feedback = new Feedback(clienteLogin, Mensagem, DateTime.Now);
        nfeedback.FeedbackInserir(feedback);
        Console.WriteLine("");
        Console.WriteLine("Feedback enviado com sucesso!");

    }
}