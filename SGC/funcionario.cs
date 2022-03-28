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
  

  public string Nome{get => nome; set => nome = value;}
  public int Senha{get => senha; set => senha = value;}
  public int Id{get=>id;set=>id=value;}

  public Funcionario(){}

  public Funcionario(string nome, int senha){
    this.nome = nome;
    this.senha = senha;
  }

  
  public int CompareTo(Funcionario obj){
    return this.nome.CompareTo(obj.Nome);
  }
  public override string ToString(){
    return $"ID: {id} - Nome: {nome}";
  }
}