using System;

class Paciente{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private nc consultas;
  
  
  
  public Paciente(string n, string c, DateTime nasc){
    nome = n;
    cpf = c;
    nascimento = nasc;
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
