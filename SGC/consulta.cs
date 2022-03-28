using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class Consulta : IComparable<Consulta>{
  private Medico medico;
  private Paciente paciente;
  private int medId;
  private int pacId;
  private string descricao;
  private string diagnostico;
  private string status;
  private DateTime data;
  private int id;
  private int custo;
  

  public Medico Medico{get=>medico;set=>medico=value;}
  public Paciente Paciente{get=>paciente;set=>paciente = value;}
  public string Descricao{get=>descricao; set=>descricao=value;}
  public string Diagnostico{get=>diagnostico; set=>diagnostico=value;}
  public string Status{get=>status;set=>status=value;}
  public DateTime Data{get=>data;set=>data=value;}
  public int Id{get=>id; set=>id=value;}
  public int Custo{get=>custo; set=>custo=value;}
  public int PacId{get=>pacId;}
  public int MedId{get=>medId;}


  public Consulta(){}

  public Consulta(Paciente paciente,string descricao, string status){
    this.paciente = paciente;
    this.pacId = paciente.Id;
    this.descricao = descricao;
    this.status = status;
    this.data = DateTime.Now;
  }

  public Consulta(Paciente paciente, string status, DateTime data){
    this.paciente = paciente;
    this.pacId = paciente.Id;
    this.status = status;
    this.data = data;
  }
  public Consulta(Medico medico, Paciente paciente,string descricao, string status, DateTime data){
    this.medico = medico;
    this.medId = medico.Id;
    this.paciente = paciente;
    this.pacId = paciente.Id;
    this.descricao = descricao;
    this.status = status;
    this.data = data;
  }

  public int CompareTo(Consulta obj){
    return this.status.CompareTo(obj.Status);
  }
  
  public override string ToString(){
    return $"ID: {id}\nMédico responsável: {medico.Nome}\nPaciente: \n{paciente.Nome}\nStatus: {status}\nDescrição: {descricao}\nDiagnóstico: {diagnostico}\nData da Consulta: {data}\nCusto: R$ {custo}";
  }
}