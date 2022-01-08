using System;

class Paciente{
  private string nome{get;};
  private string cpf{get;};
  private DateTime nascimento{get;};
  private int id{get;};
  private Consulta[] consultas = new Consulta[10];
  private int nc;
  
  public Paciente(string n, string c, DateTime nasc){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }
  public AgendarCnslt(Consulta c){
    if(nc == consultas.Lenght){
      Array.Resize(ref consultas, 2*consultas.Lenght);
    }
    consultas[nc] = c;
    nc++;
  }
  public Consulta[] ListarConsultas(){
    Consulta[] c = new Consulta[nc];
    Array.Copy(consutlas, c, nc);
    return c;
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
