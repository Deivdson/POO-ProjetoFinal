using System;

class Paciente{
  private string nome{get};
  private string cpf{get};
  private DateTime nascimento{get};
  private int id{get};
  private Consulta[] consultas = new Consulta[10];
  private nc consultas;
  
  public Paciente(string n, string c, DateTime nasc){
    nome = n;
    cpf = c;
    nascimento = nasc;
  }
  public AgendarCnslt(Consulta c){
    if(nc == consultas.Lenght){
      Array.Resize(ref consultas, 2*consultas.Lenght);
    }
    categorias[nc] = c;
    nc++;
  }
  public Consulta[] Lista(){
    Consulta[] c = new Consulta[nc];
    Array.Copy(consutlas, c, nc);
    return c;
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }
}
