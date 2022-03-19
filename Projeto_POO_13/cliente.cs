using System;

public class Cliente : IComparable<Cliente> {
    //Propriedades do Cliente
    public int id { get ; set; }
    public string nome { get; set; }
    public DateTime nascimento { get; set; }
    public string contato { get; set; }
    public string endereco { get; set; }
    public string estado { get; set; }
    
    public int CompareTo(Cliente cliente) {
        return this.nome.CompareTo(cliente.nome);
    }

    public override string ToString(){ 
        return nome + $" (Id: {id})" + "\n" + "Data de nascimento: " + nascimento.ToString("(dd/MM/yyyy)") + "\n" + "Contato: " + contato + "\n" + "Endereço: " + endereco + ", " + estado;
    }
    
    // Contato: PODE SER QUALQUER TIPO DE CONTATO (caso o e-mail)
    // Endereço: 
    // Estado: 
}