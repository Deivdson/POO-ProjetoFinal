using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


class NFuncionario{
  
  private NFuncionario() { }
  static NFuncionario obj = new NFuncionario();
  public static NFuncionario Singleton {get=> obj;}
  
  List<Funcionario> funcs =  new List<Funcionario>();

  public void InserirFunc(Funcionario f){
    int max=0;
    foreach(Funcionario obj in funcs)
      if(obj.Id>max)max=obj.Id;
    f.Id=max+1;
    funcs.Add(f);
  }
  public List<Funcionario> ListarFunc(){
    funcs.Sort();
    return funcs;
  }
  //Procurar
  public Funcionario ProcurarFunc(string nome){
    for(int i=0; i<funcs.Count ;i++){
      if(funcs[i].Nome==nome)return funcs[i];
    }
    return null;
  }
  
  public void RemoverFunc(Funcionario f){
    funcs.RemoveAt(funcs.IndexOf(f));
  }

  public void AtualizarFunc(string nome, Funcionario f){
    Funcionario funcionario = ProcurarFunc(nome);
    funcionario.Nome = f.Nome;
    funcionario.Senha = f.Senha;
  }
  
  public void Abrir(){
    Arquivo<List<Funcionario>> arquivo = new Arquivo<List<Funcionario>>();
    funcs = arquivo.Abrir("./Funcionarios.xml");
  }
  
  public void Salvar(){
    Arquivo<List<Funcionario>> arquivo = new Arquivo<List<Funcionario>>();
    arquivo.Salvar("./Funcionarios.xml",ListarFunc());
  }
  
}