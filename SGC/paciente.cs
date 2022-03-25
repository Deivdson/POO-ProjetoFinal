using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class Paciente : IComparable<Paciente>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private List<int> valores = new List<int>();
  

  public string Nome{get=>nome;set=>nome=value;}
  public string Cpf{get=>cpf;set=>cpf=value;}
  public DateTime Nascimento{get=>nascimento;set=>nascimento=value;}
  public int Id{get=>id;set=>id=value;}
  public List<int> Valores{get=>valores;set=>valores=value;}

  private Paciente(){}
  /*
  static Paciente obj = new Paciente();
  public static Paciente Singleton {get=>obj;} */
  
  public Paciente(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }

  
  public int CompareTo(Paciente obj){
    return this.nome.CompareTo(obj.Nome);
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
