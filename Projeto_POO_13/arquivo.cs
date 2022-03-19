using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Arquivo<T> {

    public T Abrir(string arquivo){
        XmlSerializer xml = new XmlSerializer(typeof(T)); 
        StreamReader arquivo_arq = new StreamReader(arquivo, Encoding.Default);
        T objeto = (T)xml.Deserialize(arquivo_arq); 
        arquivo_arq.Close(); //Fechando a leitura do arquivo.
        return objeto;
    }

    public void Salvar(string arquivo, T objeto){
        XmlSerializer xml = new XmlSerializer(typeof(T)); 
        StreamWriter arquivo_arq = new StreamWriter(arquivo, false, Encoding.Default); 
        xml.Serialize(arquivo_arq, objeto); 
        arquivo_arq.Close(); //Fechando a escrita do arquivo.
    }
}