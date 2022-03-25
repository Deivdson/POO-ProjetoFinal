using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;


class NMedico{
  private List<Medico> meds = new List<Medico>();

  public void InserirMed(Medico m){
    int max=0;
    /* foreach(Medico obj in meds)
      if(obj.Id>max)max=obj.Id;
    m.Id=max+1; */

    max = meds.Max(obj=>obj.Id);
    m.Id = max+1;
    meds.Add(m);
  }

  public List<Medico> ListarMed(){
    return meds.OrderBy(obj=>obj.Nome).ToList();
  }

  public List<Medico> ListarMedNome(string n){
    return meds.Where(m=>m.Nome==n).ToList();
  }
  
  //Procurar
  public Medico ProcurarMed(string nome){
    for(int i=0; i<meds.Count ;i++){
      if(meds[i].Nome==nome)return meds[i];
    }
    return null;
  }
  //Procurar id
  public Medico ProcurarMedID(int id){
    for(int i=0; i<meds.Count ;i++){
      if(meds[i].Id==id)return meds[i];
    }
    return null;
  }
  
  public void RemoverMed(Medico m){
    meds.RemoveAt(meds.IndexOf(m));
    List<Consulta> consultas = m.ListarConsultas();
    foreach(Consulta c in consultas){
      c.Descricao = null;
      c.Diagnostico = null;
      c.Status = null;
    }
  }
  
  public void AtualizarMed(Medico m){
    Medico medico = ProcurarMedID(m.Id);
    medico.Nome = m.Nome;
    medico.Cpf = m.Cpf;
    medico.Nascimento = m.Nascimento;
  }

  public void AbrirMeds(){
    Arquivo<List<Medico>> arquivo = new Arquivo<List<Medico>>();
    meds = arquivo.Abrir("./Medicos.xml");
    /* foreach(Medico m in meds) m.AbrirConsultas(); */
    
  }
  public void SalvarMeds(){
    Arquivo<List<Medico>> arquivo = new Arquivo<List<Medico>>();
    arquivo.Salvar("./Medicos.xml",ListarMed());
    /* foreach(Medico m in meds) m.SalvarConsultas(); */
    
  }

  
}