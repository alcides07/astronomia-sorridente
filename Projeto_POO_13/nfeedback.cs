using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Nfeedback{
    private Nfeedback(){}
    static Nfeedback nfeed_obj = new Nfeedback();
    public static Nfeedback Singleton{ get => nfeed_obj; }

    private List<Feedback> feedbacks = new List<Feedback>();

    //Abrindo um arquivo de dados com os feedbacks
    public void Abrir(){
        Arquivo <List<Feedback>> arquivo_feed = new Arquivo <List<Feedback>>();
        feedbacks = arquivo_feed.Abrir("Projeto_POO_13/feedbacks.xml");
        AtualizarFeedback();
    }

    //Salvando os feedbacks cadastrados em um arquivo xml
    public void Salvar(){   
        Arquivo <List<Feedback>> arquivo_feed = new Arquivo <List<Feedback>>();
        arquivo_feed.Salvar("Projeto_POO_13/feedbacks.xml", feedbacks);
    }

    private void AtualizarFeedback(){
    //Percorrer a lista de feedbacks para atualizar o feedback de cada cliente
        for(int i = 0; i < feedbacks.Count; i++){
            Feedback feedback = feedbacks[i];
            
            //Recuperando o cliente do feedback percorrido
            Cliente c = Ncliente.Singleton.Listar(feedback.id);
        
            //Inserindo o cliente de volta em seu feedback (refazendo associação)
            if (c != null){
                feedback.cliente = c; // Dizendo a qual categoria aquele produto pertence
            }
        }
    }

    //Método de inserir um feedback no vetor de feedbacks
    public void FeedbackInserir(Feedback feedback){
        int maiorId = 0;
        foreach(Feedback f in feedbacks){
            if(f.id > maiorId){
                maiorId = f.id;
            }
        }
        feedback.id = maiorId + 1;
        feedbacks.Add(feedback); 
    }
    //Listando todos os feedbacks
    public List<Feedback> Listar(){
        feedbacks.Sort();
        return feedbacks;
    }
}