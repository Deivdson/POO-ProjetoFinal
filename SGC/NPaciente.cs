using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


class NPaciente{
  private NPaciente(){}
  static NPaciente obj = new NPaciente();
  public static NPaciente Singleton {get=> obj;}
  
  private List<Paciente> pacs = new List<Paciente>();

  public void InserirPac(Paciente p){
    int max=0;
    foreach(Paciente obj in pacs)
      if(obj.Id>max)max=obj.Id;
    p.Id=max+1;
    /* max = pacs.Max(obj=>obj.Id);
    p.Id = max+1; */
    pacs.Add(p);
  }

  public List<Paciente> ListarPac(){
    return pacs.OrderBy(obj=>obj.Nome).ToList();
  }

  public List<Paciente> ListarPacNome(string n){
    return pacs.Where(p=>p.Nome==n).ToList();
  }

  //Procurar
  public Paciente ProcurarPac(string nome){
    for (int i=0; i<pacs.Count ;i++){
      if(pacs[i].Nome==nome)return pacs[i];
    }
    return null;
  }

  //Procurar id
  public Paciente ProcurarPacID(int id){
    /* for (int i=0; i<pacs.Count ;i++){
      if(pacs[i].Id==id)return pacs[i];
    }
    return null; */
    var r = pacs.Where(obj => obj.Id==id);
    if(r.Count()==0) return null;
    return r.First();
  }

  public void RemoverPac(Paciente p){
    pacs.RemoveAt(pacs.IndexOf(p));
    List<Consulta> consultas = p.ListarCnslt();
    foreach(Consulta c in consultas){
      c.Descricao = null;
      c.Diagnostico = null;
      c.Status = null;
    }
  }

  public void AtualizarPac(int id,Paciente p){
    Paciente paciente = ProcurarPacID(id);
    paciente.Nome = p.Nome;
    paciente.Cpf = p.Cpf;
    paciente.Nascimento = p.Nascimento;
  }

  public void Abrir(){
    Arquivo<List<Paciente>> arquivo = new Arquivo<List<Paciente>>();
    pacs = arquivo.Abrir("./Pacientes.xml");
  }

  public void Salvar(){
    Arquivo<List<Paciente>> arquivo = new Arquivo<List<Paciente>>();
    arquivo.Salvar("./Pacientes.xml",ListarPac());
  }

}