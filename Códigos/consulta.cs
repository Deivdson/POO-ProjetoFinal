using System;

class Consulta{
  private string descricao;
  private string status;
  private DateTime data;
  private int id;
  private DateTime[] horarios;

  public string Descricao{get; set;}
  public string Status{get;set;}
  public DateTime Data{get;set;}
  public int Id{get;}

  public Consulta(string descricao, string status, DateTime data){
    this.descricao = descricao;
    this.status = status;
    this.data = data;
  }

  public override string ToString(){
    return $"Status: {status}\nDescrição: {descricao}\nData da Consulta: {data}";
  }
}