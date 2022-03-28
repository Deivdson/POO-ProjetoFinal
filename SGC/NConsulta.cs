using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

class NConsulta{
  private NConsulta(){}
  static NConsulta obj = new NConsulta();
  public static NConsulta Singleton {get=> obj;}
  
  
  private List<Consulta> consultas = new List<Consulta>();
  
  public void AgendarCnslt(Consulta c){
    int max=0;
    /* foreach(Consulta obj in consultas)
      if(obj.Id>max)max=obj.Id;
    c.Id=max+1; */
    
    max = consultas.Max(obj=>obj.Id);
    c.Id = max+1;
    Paciente p = c.Paciente;
    Medico m = c.Medico;
    
    if(p != null) p.InserirCnslt(c);
    if(m != null) m.InserirCnslt(c);
    consultas.Add(c); 
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }
  
  public List<Consulta> ListarConsultasIDP(int id){
    List<Consulta> lc = new List<Consulta>();
    foreach(Consulta c in consultas){
      if(c.Paciente.Id == id) lc.Add(c);
    }
    return lc;
  }
  public List<Consulta> ListarConsultasIDM(int id){
    List<Consulta> lc = new List<Consulta>();
    foreach(Consulta c in consultas){
      if(c.Medico.Id == id) lc.Add(c);
    }
    return lc;
  }
  
  public void AtualizarConsulta(int id, Medico m,Paciente p, DateTime data, string status, int custo){
    Consulta consulta = ProcurarConsulta(id);
    consulta.Medico = m;
    consulta.Paciente = p;
    consulta.Data = data;
    consulta.Status = status;
    consulta.Custo = custo;
    m.InserirCnslt(consulta);
  }
  
  public void AtualizarConsultaMed(int id, string status, string diag, int custo){
    Consulta consulta = ProcurarConsulta(id);
    consulta.Status = status;
    consulta.Diagnostico = diag;
    consulta.Custo = custo;
  }
  
  public Consulta ProcurarConsulta(int id){
    for (int i=0; i<consultas.Count ;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }

  public void Abrir(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    consultas = arquivo.Abrir("./Consultas.xml");
    Atualizar();
  }
  
  public void Atualizar(){
    foreach(Consulta c in consultas){
      Paciente p = NPaciente.Singleton.ProcurarPacID(c.PacId);
      Medico m = NMedico.Singleton.ProcurarMedID(c.MedId);
      if(p!=null){
        c.Paciente = p;
        p.InserirCnslt(c);
      }
      if(m!=null){
        c.Medico = m;
        m.InserirCnslt(c);
      }
    }
  }
  
  public void Salvar(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    arquivo.Salvar("./Consultas.xml",ListarConsultas());

  }
}