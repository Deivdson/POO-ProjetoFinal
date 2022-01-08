using System;

class Funcionario{
  private string nome{get; set;};
  private int senha{get; set;};
  private Medico[] medicos = new Medico[10];
  private Paciente[] pacientes = new Paciente[10];
  private int nm, np;

  public Funcionario(string nome, int senha){
    this.nome = nome;
    this.senha = senha;
  }

  public InserirMed(Medico m){
    if(nm == medicos.Lenght){
      Array.Resize( ref medicos, 2*medicos.Lenght);
    }
    medicos[nm] = m;
    nm++;
  }
  public InserirPac(Paciente p){
    if(np == pacientes.Lenght){
      Array.Resize( ref pacientes, 2*pacientes.Lenght);
    }
    paciente[np] = p;
    np++;
  }
  public Medico[] ListarMed(){
    Medico[] m = new Medico[nm];
    Array.Copy(medicos, c, nm);
    return c;
  }
  public Paciente[] ListarPac(){
    Paciente[] p = new Paciente[np];
    Array.Copy(pacientes, p, np);
    return p;
  }
  //Procurar
  public Medico ListarMedId(int id){
    for(int i=0; i<nm ;i++){
      if(medicos[i].id==id)return medicos[i];
    }
    return null;
  }
  //Procurar
  public Paciente ListarPacId(int id){
    for (int i=0; i<np ;I++){
      if(pacientes.Getid()==id)return pacientes[i];
    }
    return null;
  }
}