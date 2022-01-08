using System;

class Medico{
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

  public Medico(string nome, string cpf, DateTime nascimento, int id){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
    this.id = id;
  }
  public void AgendarCnslt(Consulta c){
    //p.AgendarCnslt();
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

  public Consulta ListarCId(int id){
    for(int i=0; i<nc;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }

  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de nascimento: {nascimento}\nID: {id}";
  }
}