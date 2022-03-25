using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class NConsulta{
  private List<Consulta> consultas = new List<Consulta>();
  
  public void AgendarCnslt(Consulta c){
    int max=0;
    foreach(Consulta obj in consultas)
      if(obj.Id>max)max=obj.Id;
    c.Id=max+1;
    /* valores.Add(c.Custo);
    max = consultas.Max(obj=>obj.Id);
    c.Id = max+1; */
    consultas.Add(c); 
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }
  
  public List<Consulta> ListarConsultasID(int id){
    List<Consulta> lc = new List<Consulta>();
    foreach(Consulta c in consultas){
      if(c.Paciente.Id == id) lc.Add(c);
    }
    return lc;
  }
  
  public void AtualizarConsulta(int id, Medico m,Paciente p, DateTime data, string status){
    Consulta consulta = ProcurarConsulta(id);
    consulta.Medico = m;
    consulta.Paciente = p;
    consulta.Data = data;
    consulta.Status = status;
    m.AgendarCnslt(consulta);
  }
  public Consulta ProcurarConsulta(int id){
    for (int i=0; i<consultas.Count ;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }

  public void AbrirConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    consultas = arquivo.Abrir($"./Arquivos_Consulta/ConsultasPac{id}.xml");

  }
  
  public void SalvarConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    arquivo.Salvar($"./Arquivos_Consulta/ConsultasPac{id}.xml",ListarConsultas());

  }
}