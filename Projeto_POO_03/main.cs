using System;

class MainClass{
    public static void Main(){     
        //Categorias
        Categoria c1 = new Categoria(1, "Telescópios");
        Categoria c2 = new Categoria(2, "Binóculos");
        Categoria c3 = new Categoria(3, "Souvenirs");
        
        //Produtos
        Produto p1 = new Produto(1, "Telescópio Newtoniano - 150mm", "Blueditec", 15, 1500.00, c1);
        Produto p2 = new Produto(2, "Binóculo", "Blueditec", 18, 500.00, c2);
        Produto p3 = new Produto(3, "Chaveiro", "Apollo 11", 25, 10.00, c3);
        Produto p4 = new Produto(4, "Caneca", "James Webb", 15, 50.00, c3);

        //Inserção nas categorias
        c1.ProdutoInserir(p1);
        c2.ProdutoInserir(p2);
        c3.ProdutoInserir(p3);
        c3.ProdutoInserir(p4);

        //Prints - Categorias
        Console.WriteLine("");
        Console.WriteLine("----------- Categorias -----------");
        Console.WriteLine(c1);
        Console.WriteLine("");
        Console.WriteLine(c2);
        Console.WriteLine("");
        Console.WriteLine(c3);

        //Prints - Produtos
        Console.WriteLine("");
        Console.WriteLine("----------- Produtos -----------");
        Console.WriteLine(p1);
        Console.WriteLine("");
        Console.WriteLine(p2);
        Console.WriteLine("");
        Console.WriteLine(p3);
        Console.WriteLine("");
        Console.WriteLine(p4);

        //Listar Produtos das categorias
        Console.WriteLine("");
        Console.WriteLine("----------- Listando categorias -----------");
        Produto[] l1 = c1.ProdutoListar();
        Console.WriteLine($"Produtos na categoria: {c1.GetDescricao()}");
        foreach (Produto produto in l1){
            Console.WriteLine(produto);
        }
            
        Console.WriteLine("");
        Produto[] l2 = c2.ProdutoListar(); 
        Console.WriteLine($"Produtos na categoria: {c2.GetDescricao()}");
        foreach (Produto produto in l2){
            Console.WriteLine(produto);
        }
        
        Console.WriteLine("");
        Produto[] l3 = c3.ProdutoListar(); 
        Console.WriteLine($"Produtos na categoria: {c3.GetDescricao()}");
        foreach (Produto produto in l3){
            Console.WriteLine(produto);
            Console.WriteLine("");
        }
    }
}