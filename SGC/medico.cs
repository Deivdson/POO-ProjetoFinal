using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class Medico : IComparable<Medico>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;

  public string Nome{get => nome;set=>nome=value;}
  public string Cpf{get => cpf;set=>cpf=value;}
  public DateTime Nascimento{get => nascimento;set=>nascimento=value;}
  public int Id{get => id;set=>id=value;}

  public Medico(){}
  
  public Medico(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }

  public int CompareTo(Medico obj){
    return this.nome.CompareTo(obj.Nome);
  }

  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de nascimento: {nascimento}\nID: {id}";
  }
}