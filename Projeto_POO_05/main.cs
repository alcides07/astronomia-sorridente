using System;

class MainClass{
    private static Ncategoria ncategoria = new Ncategoria();
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
        Console.WriteLine("2 - Inserir Nova Categoria");
        Console.WriteLine("0 - Encerrar operações");
        Console.WriteLine("");
        Console.Write("Informe um número referente a uma das opções: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return operacao;
    }
    
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
        Console.Write("Informe um Id para a categoria: "); //Id como contador a fim de deixar em ordem ou ordenar apenas na hora de printar a lista de categorias.
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição para a categoria: ");
        string descricao = Console.ReadLine();
        Console.WriteLine($"Categoria {descricao} cadastrada com sucesso!");
        Console.WriteLine("");

        //Instanciar classe de Categoria (criando uma nova categoria)
        Categoria categoria = new Categoria(id, descricao);

        //Inserção da categoria na lista de categorias 
        ncategoria.Inserir(categoria);

    }
}