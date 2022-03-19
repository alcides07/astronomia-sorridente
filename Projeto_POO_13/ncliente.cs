using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Ncliente {
    private Ncliente(){}
    static Ncliente ncli_obj = new Ncliente();
    public static Ncliente Singleton{ get => ncli_obj; }

    private List<Cliente> clientes = new List<Cliente>();

    //Abrindo um arquivo de dados com as categorias
    public void Abrir(){
        Arquivo <List<Cliente>> arquivo_cli = new Arquivo <List<Cliente>>();
        clientes = arquivo_cli.Abrir("Projeto_POO_13/clientes.xml");
    }

    //Salvando as categorias cadastradas em um arquivo xml
    public void Salvar(){
        Arquivo <List<Cliente>> arquivo_cli = new Arquivo <List<Cliente>>();
        arquivo_cli.Salvar("Projeto_POO_13/clientes.xml", clientes);
    }

    //Método de inserir uma categoria no vetor de categorias
    public void Inserir(Cliente cliente){        
        int maior_id = 0; 
        foreach(Cliente c in clientes){
            if (c.id > maior_id){
                maior_id = c.id;
            }
        }

        cliente.id = maior_id + 1;
        clientes.Add(cliente); 
    }

    //Listando todos clientes
    public List<Cliente> Listar(){
        clientes.Sort();
        return clientes;
    }

    //Listando um cliente baseado em seu ID
    public Cliente Listar(int id){
        for (int i = 0; i < clientes.Count; i++){
            if (clientes[i].id == id){
                return clientes[i];
            }
        }
        return null;
    }

    //Atuaizando os clientes
    public void Atualizar(Cliente cliente){ //Informando um novo cliente
        
        //Localizar no vetor o cliente pelo id
        Cliente atualCli = Listar(cliente.id); //Procurando o atual ID na listagem atual
        if (atualCli == null){ //Não encontrou o ID na lista de cleintes 
            return;
        }

        //Alterar dados da Cliente
        atualCli.nome = cliente.nome; //Altera o nome antigo pelo novo
        atualCli.nascimento = cliente.nascimento; //Altera o nascimento antigo pelo novo
        atualCli.contato = cliente.contato; //Altera o contato antigo pelo novo
        atualCli.endereco = cliente.endereco; //Altera o endereco antigo pelo novo
    }

    //Excluindo clientes
    public void Excluir(Cliente cliente){    
        //Remove o cliente da lista
        if (cliente != null){
            clientes.Remove(cliente);
        }
    }
}