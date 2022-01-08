using System;

class MainClass{
    public static void Main(){    
        //Categorias
        Console.WriteLine("");
        Console.WriteLine("----------- Categorias -----------");
        Categoria c1 = new Categoria(1, "Telescópios");
        Categoria c2 = new Categoria(2, "Binóculos");
        Categoria c3 = new Categoria(3, "Souvenirs");
        
        //Prints - Categorias
        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine(c3);
        
        //Produtos
        Console.WriteLine("");
        Console.WriteLine("----------- Produtos -----------");
        Produto p1 = new Produto(1, "Telescópio Newtoniano - 150mm", "Blueditec", 15, 1500.00, c1);
        Produto p2 = new Produto(2, "Binóculo", "Blueditec", 18, 500.00, c2);
        Produto p3 = new Produto(3, "Chaveiro", "Apollo 11", 25, 10.00, c3);

        //Prints - Produtos
        Console.WriteLine(p1);
        Console.WriteLine("");
        Console.WriteLine(p2);
        Console.WriteLine("");
        Console.WriteLine(p3);
  }
}