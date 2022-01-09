using System;

class MainClass{
    public static void Main(){     
        Console.WriteLine("");
        Console.WriteLine("Loja Astronomia Sorridente: Encurtando distâncias astronômicas até você");
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
                Console.WriteLine("");
                Console.WriteLine("A opção informada não é válida!");
            }
        }
    }

    //Menu
    public static int Menu(){
        Console.WriteLine("");
        Console.WriteLine("----------- Opções Disponíveis -----------");
        Console.WriteLine("1 - Listar Categorias");
        Console.WriteLine("2 - Inserir Nova Categoria");
        Console.WriteLine("0 - Encerrar operações");
        Console.Write("Informe um número referente a uma das opções: ");
        int operacao = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return operacao;
    }

    //Método Listar Categorias
    public static void CategoriaListar(){
        Console.WriteLine("----------- Listando Categorias -----------");
    }
    
    //Método Inserir Categoria
    public static void CategoriaInserir(){
        Console.WriteLine("----------- Inserindo Categorias -----------");
    }
}