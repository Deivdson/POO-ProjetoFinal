using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class Medico : IComparable<Medico>{
  private string nome;
  private string cpf;
  private DateTime nascimento;
  private int id;
  private List<Consulta> consultas = new List<Consulta>();

  public string Nome{get => nome;set=>nome=value;}
  public string Cpf{get => cpf;set=>cpf=value;}
  public DateTime Nascimento{get => nascimento;set=>nascimento=value;}
  public int Id{get => id;set=>id=value;}

  public Medico(){}
  
  public Medico(string nome, string cpf, DateTime nascimento){
    this.nome = nome;
    this.cpf = cpf;
    this.nascimento = nascimento;
  }
  public void AgendarCnslt(Consulta c){
    //p.AgendarCnslt();
    int max=0;
    /* foreach(Consulta obj in consultas)
      if(obj.Id>max)max=obj.Id;
    c.Id=max+1; */
    max = consultas.Max(obj=>obj.Id);
    c.Id = max+1;
    consultas.Add(c);
  }

  public List<Consulta> ListarConsultas(){
    consultas.Sort();
    return consultas;
  }

  public Consulta ListarCId(int id){
    for(int i=0; i<consultas.Count;i++){
      if(consultas[i].Id==id)return consultas[i];
    }
    return null;
  }
  
  public void AtualizarConsulta(int id, string status, string diag){
    Consulta consulta = ListarCId(id);
    consulta.Status = status;
    consulta.Diagnostico = diag;
  }

  public int CompareTo(Medico obj){
    return this.nome.CompareTo(obj.Nome);
  }

  public override string ToString(){
    return $"Nome: {nome}\nCPF: {cpf}\nData de nascimento: {nascimento}\nID: {id}";
  }

  public void AbrirConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    consultas = arquivo.Abrir($"./Arquivos_Consulta/ConsultasMed{id}.xml");
    
    /* XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
    StreamReader leitor = new StreamReader($"./Arquivos_Consulta/ConsultasMed{id}.xml", Encoding.Default);
    consultas = (List<Consulta>) xml.Deserialize(leitor);
    leitor.Close(); */
  }
  public void SalvarConsultas(){
    Arquivo<List<Consulta>> arquivo = new Arquivo<List<Consulta>>();
    arquivo.Salvar($"./Arquivos_Consulta/ConsultasMed{id}.xml",ListarConsultas());
    
    /* XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
    StreamWriter f = new  StreamWriter($"./Arquivos_Consulta/ConsultasMed{id}.xml", false, Encoding.Default);
      xml.Serialize(f, consultas);
    f.Close(); */
  }
}