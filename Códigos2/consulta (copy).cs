using System;

class Consulta{
  private string medico, paciente;
  private string descricao;
  private string diagnostico;
  private string status;
  private DateTime data;
  private int id;
  private DateTime[] horarios = new DateTime[10];
  private int nh;

  public string Medico{get=>medico;}
  public string Paciente{get=>paciente;}
  public string Descricao{get=>descricao; set=>descricao=value;}
  public string Diagnostico{get=>diagnostico; set=>diagnostico=value;}
  public string Status{get=>status;set=>status=value;}
  public DateTime Data{get=>data;set=>data=value;}
  public int Id{get=>id;}

  public Consulta(){}

  public Consulta(string medico, string paciente,string descricao, string status, DateTime data, int id){
    this.medico = medico;
    this.paciente = paciente;
    this.descricao = descricao;
    this.status = status;
    this.data = data;
    this.id = id;
  }
  public void AdicionarH(DateTime horario){
    if(nh==horarios.Length){
      Array.Resize(ref horarios, 2*horarios.Length);
    }
    horarios[nh] = horario;
    nh++;
  }
  public DateTime[] Horarios(){
    DateTime[] h = new DateTime[nh];
    Array.Copy(horarios, h, nh);
    return h;
  }
  public DateTime BuscaH(int index){
    for(int i=1; i<nh;i++){
      if(i==index)return horarios[i];
    }
    return horarios[0];
  }
  public override string ToString(){
    return $"ID: {id}\nMédico responsável: {medico}\nPaciente: {paciente}\nStatus: {status}\nDescrição: {descricao}\nDiagnóstico: {diagnostico}\nData da Consulta: {data}";
  }
}