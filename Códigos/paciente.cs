using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class Paciente : IComparable<Paciente>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private List<int> valores = new List<int>();
  private List<Consulta> consultas = new List<Consulta>();

  public string Nome{get=>nome;set=>nome=value;}
  public string Cpf{get=>cpf;set=>cpf=value;}
  public DateTime Nascimento{get=>nascimento;set=>nascimento=value;}
  public int Id{get=>id;set=>id=value;}
  public List<int> Valores{get=>valores;set=>valores=value;}

  private Paciente(){}
  /*
  static Paciente obj = new Paciente();
  public static Paciente Singleton {get=>obj;} */
  
  public Paciente(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }

  public void AgendarCnslt(Consulta c){
    int max=0;
    /* foreach(Consulta obj in consultas)
      if(obj.Id>max)max=obj.Id;
    c.Id=max+1; */
    valores.Add(c.Custo);
    max = consultas.Max(obj=>obj.Id);
    c.Id = max+1;
    consultas.Add(c); 
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }
/*   public List<Consulta> ListarConsultasId(){
    consultas.Sort();
    return consultas;
  } */
  
  public void AtualizarConsulta(int id, Medico m, DateTime data, string status){
    Consulta consulta = ProcurarConsulta(id);
    consulta.Medico = m.Nome;
    consulta.Data = data;
    consulta.Status = status;
    m.AgendarCnslt(consulta);
  }
  public Consulta ProcurarConsulta(int id){
    for (int i=0; i<consultas.Count ;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }
  public int CompareTo(Paciente obj){
    return this.nome.CompareTo(obj.Nome);
  }
  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de Nascimento: {nascimento}";
  }

  public void AbrirConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    consultas = arquivo.Abrir($"./Arquivos_Consulta/ConsultasPac{id}.xml");

  }
  public void SalvarConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    arquivo.Salvar($"./Arquivos_Consulta/ConsultasPac{id}.xml",ListarConsultas());

  }
}
