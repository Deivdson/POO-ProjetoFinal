using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class Consulta : IComparable<Consulta>{
  private string medico, paciente;
  private string descricao;
  private string diagnostico;
  private string status;
  private DateTime data;
  private int id;
  private int custo;
  private List<DateTime> horarios = new List<DateTime>();
  

  public string Medico{get=>medico;set=>medico=value;}
  public string Paciente{get=>paciente;}
  public string Descricao{get=>descricao; set=>descricao=value;}
  public string Diagnostico{get=>diagnostico; set=>diagnostico=value;}
  public string Status{get=>status;set=>status=value;}
  public DateTime Data{get=>data;set=>data=value;}
  public int Id{get=>id; set=>id=value;}
  public int Custo{get=>custo; set=>custo=value;}

  public Consulta(){}

  public Consulta(string paciente,string descricao, string status){
    this.paciente = paciente;
    this.descricao = descricao;
    this.status = status;
    this.data = DateTime.Now;
  }

  public Consulta(string paciente, string status, DateTime data){
    this.paciente = paciente;
    this.status = status;
    this.data = data;
  }
  public Consulta(string medico, string paciente,string descricao, string status, DateTime data){
    this.medico = medico;
    this.paciente = paciente;
    this.descricao = descricao;
    this.status = status;
    this.data = data;
  }
  public void AdicionarH(DateTime horario){
    horarios.Add(horario);
  }
  public List<DateTime> Horarios(){
    horarios.Sort();
    return horarios;
  }
  public DateTime BuscaH(int index){
    for(int i=1; i<horarios.Count;i++){
      if(i==index)return horarios[i];
    }
    return horarios[0];
  }

  public int CompareTo(Consulta obj){
    return this.status.CompareTo(obj.Status);
  }
  
  public override string ToString(){
    return $"ID: {id}\nMédico responsável: {medico}\nPaciente: {paciente}\nStatus: {status}\nDescrição: {descricao}\nDiagnóstico: {diagnostico}\nData da Consulta: {data}";
  }
}