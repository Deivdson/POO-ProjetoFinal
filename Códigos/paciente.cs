using System;

class Paciente{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private Consulta[] consultas = new Consulta[10];
  private int nc;

  public string Nome{get;}
  public string Cpf{get;}
  public DateTime Nascimento{get;}
  public int Id{get;}
  
  public Paciente(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }
  public void AgendarCnslt(Consulta c){
    if(nc == consultas.Length){
      Array.Resize(ref consultas, 2*consultas.Length);
    }
    consultas[nc] = c;
    nc++;
  }
  public Consulta[] ListarConsultas(){
    Consulta[] c = new Consulta[nc];
    Array.Copy(consultas, c, nc);
    return c;
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
