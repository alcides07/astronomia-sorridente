using System;

class Categoria {
    //Atributos
    private int id;
    private string descricao;
    
    //Construtor
    public Categoria(int id, string descricao){
       this.id = id;
       this.descricao = descricao; 
    }
    
    //Sets
    public void SetId(int id){
        this.id = id;
    }
    public void SetDescricao(string descricao){
        this.descricao = descricao;
    }

    //Gets
    public int GetId(){
        return id;
    }

    public string GetDescricao(){
        return descricao;
    }

    //Formatação
    public override string ToString(){
        return id + " - " + descricao;
    }
}