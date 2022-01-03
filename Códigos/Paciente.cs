using System;

class Paciente{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  
  public Paciente(string n, string c, string t, DateTime nasc){
    nome = n;
    cpf = c;
    telefone = t;
    nascimento = nasc;
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nTelefone: {telefone}\nData de Nascimento: {nascimento}";
  }
}
