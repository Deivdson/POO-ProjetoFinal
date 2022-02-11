using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Paciente : IComparable<Paciente>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private List<Consulta> consultas = new List<Consulta>();

  public string Nome{get=>nome;set=>nome=value;}
  public string Cpf{get=>cpf;set=>cpf=value;}
  public DateTime Nascimento{get=>nascimento;set=>nascimento=value;}
  public int Id{get=>id;}
  
  public Paciente(string nome, string cpf, DateTime nascimento, int id){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }

  public void AgendarCnslt(Consulta c){
    consultas.Add(c); 
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }
  public int CompareTo(Paciente obj){
    return this.nome.CompareTo(obj.Nome);
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
