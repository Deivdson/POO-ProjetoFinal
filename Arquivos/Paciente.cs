using System;

class Program {
  public static void Main(string[] args){
    Paciente x = new Paciente("Dofi", "xxxxxxxxx-xx", "999999999", DateTime.Parse("02/12/2000"));
    Console.WriteLine(x.Idade());
  }
}

class Paciente{
  private string nome;
  private string cpf;
  private string telefone;
  private DateTime nascimento;
  
  public Paciente(string n, string c, string t, DateTime nasc){
    nome = n;
    cpf = c;
    telefone = t;
    nascimento = nasc;
  }
  public string Idade(){
    DateTime y = DateTime.Today;
    return $"{(y.Year-nascimento.Year)}ano(s) e {y.Month-nascimento.Month}mês(es) ";
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nTelefone: {telefone}\nData de Nascimento: {nascimento}";
  }
}

