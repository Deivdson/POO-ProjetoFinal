using System;

class Medico{
  private string nome{get;};
  private string cpf{get;};
  private DateTime nascimento{get;};
  private int id{get;};
  private Consulta[] consultas = new Consulta[10];
  private int nc;

  public Medico(string nome, string cpf, DateTime nascimento, int id){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
    this.id = id;
  }
  public AgendarCnslt(Consulta c){
    //p.AgendarCnslt();
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

  public Consulta ListarCId(int id){
    for(int i=0; i<nc;i++){
      if(consultas[i].Getid()==id)return consultas[i];
    }
    return null;
  }

  public override string ToString(){
    retrun $"Nome: {nome}\nCPF: {cpf}\nData de nascimento: {nascimento}\nID: {id}";
  }
}