using System;

class Consulta{
  private string descricao{get;set;};
  private string status{get;set;};
  private DateTime data{get;set;};
  private DateTime[] horarios;

  public Consulta(string descricao, string status, DateTime data){
    this.descricao = descricao;
    this.status = status;
    this.data = data;
  }

  public override string ToString(){
    return $"Status: {status}\nDescrição: {descricao}\nData da Consulta: {data}";
  }
}