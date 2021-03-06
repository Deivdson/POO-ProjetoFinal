using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class Funcionario : IComparable<Funcionario>{
  private string nome;
  private int senha;
  private int id;
  private List<Paciente> pacs = new List<Paciente>();
  private List<Medico> meds = new List<Medico>();

  public string Nome{get => nome; set => nome = value;}
  public int Senha{get => senha; set => senha = value;}
  public int Id{get=>id;set=>id=value;}

  /* static Funcionario obj = new Funcionario();
  public static Funcionario Singleton {get=>obj;} */

  public Funcionario(){}

  public Funcionario(string nome, int senha){
    this.nome = nome;
    this.senha = senha;
  }

  public void InserirMed(Medico m){
    int max=0;
    /* foreach(Medico obj in meds)
      if(obj.Id>max)max=obj.Id;
    m.Id=max+1; */

    max = meds.Max(obj=>obj.Id);
    m.Id = max+1;
    meds.Add(m);
  }
  public void InserirPac(Paciente p){
    int max=0;
    /* foreach(Paciente obj in pacs)
      if(obj.Id>max)max=obj.Id;
    p.Id=max+1; */
    max = pacs.Max(obj=>obj.Id);
    p.Id = max+1;
    pacs.Add(p);
  }
  public List<Medico> ListarMed(){
    return meds.OrderBy(obj=>obj.Nome).ToList();
  }
  public List<Paciente> ListarPac(){
    return pacs.OrderBy(obj=>obj.Nome).ToList();
  }

  public List<Medico> ListarMedNome(string n){
    return meds.Where(m=>m.Nome==n).ToList();
  }
  public List<Paciente> ListarPacNome(string n){
    return pacs.Where(p=>p.Nome==n).ToList();
  }
  //Procurar
  public Medico ProcurarMed(string nome){
    for(int i=0; i<meds.Count ;i++){
      if(meds[i].Nome==nome)return meds[i];
    }
    return null;
  }
  //Procurar id
  public Medico ProcurarMedID(int id){
    for(int i=0; i<meds.Count ;i++){
      if(meds[i].Id==id)return meds[i];
    }
    return null;
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
    for (int i=0; i<pacs.Count ;i++){
      if(pacs[i].Id==id)return pacs[i];
    }
    return null;
  }
  public void RemoverMed(Medico m){
    meds.RemoveAt(meds.IndexOf(m));
    List<Consulta> consultas = m.ListarConsultas();
    foreach(Consulta c in consultas){
      c.Descricao = null;
      c.Diagnostico = null;
      c.Status = null;
    }
  }
  public void RemoverPac(Paciente p){
    pacs.RemoveAt(pacs.IndexOf(p));
    List<Consulta> consultas = p.ListarConsultas();
    foreach(Consulta c in consultas){
      c.Descricao = null;
      c.Diagnostico = null;
      c.Status = null;
    }
  }

  public void AtualizarMed(Medico m){
    Medico medico = ProcurarMedID(m.Id);
    medico.Nome = m.Nome;
    medico.Cpf = m.Cpf;
    medico.Nascimento = m.Nascimento;
  }

  public void AtualizarPac(Paciente p){
    Paciente paciente = ProcurarPacID(p.Id);
    paciente.Nome = p.Nome;
    paciente.Cpf = p.Cpf;
    paciente.Nascimento = p.Nascimento;
  }
  public int CompareTo(Funcionario obj){
    return this.nome.CompareTo(obj.Nome);
  }
  public override string ToString(){
    return $"ID: {id} - Nome: {nome}";
  }

  public void AbrirPacs(){
    Arquivo<List<Paciente>> arquivo = new Arquivo<List<Paciente>>();
    pacs = arquivo.Abrir("./Pacientes.xml");
    /* foreach(Paciente p in pacs) p.AbrirConsultas(); */
    
  }
  public void SalvarPacs(){
    Arquivo<List<Paciente>> arquivo = new Arquivo<List<Paciente>>();
    arquivo.Salvar("./Pacientes.xml",ListarPac());
    /* foreach(Paciente p in pacs) p.SalvarConsultas(); */
    
  }

  public void AbrirMeds(){
    Arquivo<List<Medico>> arquivo = new Arquivo<List<Medico>>();
    meds = arquivo.Abrir("./Medicos.xml");
    /* foreach(Medico m in meds) m.AbrirConsultas(); */
    
  }
  public void SalvarMeds(){
    Arquivo<List<Medico>> arquivo = new Arquivo<List<Medico>>();
    arquivo.Salvar("./Medicos.xml",ListarMed());
    /* foreach(Medico m in meds) m.SalvarConsultas(); */
    
  }

  /* private void AtualizarConsultasP(){
    for(int i=0;i<pacs.Count;i++){
      Paciente p = pacs[i];
      for(int j=0;j<p.ListarConsultas().Count;j++){
        Consulta c = Paciente.Singleton.ProcurarConsultaId(p.ListarConsultasId()[j]);
        if(c!=null){
          p.AgendarCnslt(c);
        }
      }
      
    }
  } */
}