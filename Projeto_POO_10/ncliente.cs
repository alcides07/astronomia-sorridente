using System;
using System.Collections.Generic;

class Ncliente {
    private List<Cliente> clientes = new List<Cliente>();

    //Método de inserir uma categoria no vetor de categorias
    public void Inserir(Cliente cliente){
        //INSERIR NOVA FORMA DPS 
        
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