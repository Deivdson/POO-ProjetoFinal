using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Medico : IComparable<Medico>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private List<Consulta> consultas = new List<Consulta>();

  public string Nome{get => nome;set=>nome=value;}
  public string Cpf{get => cpf;set=>cpf=value;}
  public DateTime Nascimento{get => nascimento;set=>nascimento=value;}
  public int Id{get => id;set=>id=value;}

  public Medico(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }
  public void AgendarCnslt(Consulta c){
    //p.AgendarCnslt();
    int max=0;
    foreach(Consulta obj in consultas)
      if(obj.Id>max)max=obj.Id;
    c.Id=max+1;
    consultas.Add(c);
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }

  public Consulta ListarCId(int id){
    for(int i=0; i<consultas.Count;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }
  
  public void AtualizarConsulta(int id, string status, string diag){
    Consulta consulta = ListarCId(id);
    consulta.Status = status;
    consulta.Diagnostico = diag;
  }

  public int CompareTo(Medico obj){
    return this.nome.CompareTo(obj.Nome);
  }

  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de nascimento: {nascimento}\nID: {id}";
  }
}