using System;

public class Feedback : IComparable<Feedback>{
    //Propriedades do Feedback
    public int id { get; set; }
    public string mensagem { get; set; }
    public DateTime data { get; set; }
    public Cliente cliente { get; set; }
    public int clienteId { get; set; }

    //public void SetCliente(Cliente cliente){
      //  this.cliente = cliente;
    //}

    public Feedback(){}

    public Feedback(Cliente cliente, string mensagem, DateTime data){
        this.cliente = cliente;
        this.mensagem = mensagem;
        this.data = data;
        clienteId = cliente.id;
    }

    public int CompareTo(Feedback feedback) {
        return this.data.CompareTo(feedback.data);
    }

    public override string ToString(){ 
        return data.ToString("(dd/MM/yyyy)") + " - " + cliente.nome + ":" + "\n" + mensagem;
    }
    //(12/02/2022) - Fulanin:
    //Mensagem tal
}