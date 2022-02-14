using System;

class Feedback : IComparable<Feedback>{
    public int id { get ; set; }
    public string mensagem { get; set; }
    public DateTime data { get; set; }
    private Cliente cliente;

    public Feedback(Cliente cliente, string mensagem, DateTime data){
        this.cliente = cliente;
        this.mensagem = mensagem;
        this.data = data;
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