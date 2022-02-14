using System;
using System.Collections.Generic;

class Nfeedback{
    private List<Feedback> feedbacks = new List<Feedback>();

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