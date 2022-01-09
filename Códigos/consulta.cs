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

  public Consulta(string descricao, string status, DateTime data, int id){
    this.descricao = descricao;
    this.status = status;
    this.data = data;
    this.id = id;
  }

  public override string ToString(){
    return $"ID: {id}\nStatus: {status}\nDescrição: {descricao}\nData da Consulta: {data}";
  }
}