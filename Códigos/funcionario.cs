using System;

class Funcionario{
  private string nome;
  private int senha;
  private Medico[] medicos = new Medico[10];
  private Paciente[] pacientes = new Paciente[10];
  private int nm, np;

  public string Nome{get => nome; set => nome = value;}
  public int Senha{get => senha; set => senha = value;}

  public Funcionario(string nome, int senha){
    this.nome = nome;
    this.senha = senha;
  }

  public void InserirMed(Medico m){
    if(nm == medicos.Length){
      Array.Resize( ref medicos, 2*medicos.Length);
    }
    medicos[nm] = m;
    nm++;
  }
  public void InserirPac(Paciente p){
    if(np == pacientes.Length){
      Array.Resize( ref pacientes, 2*pacientes.Length);
    }
    pacientes[np] = p;
    np++;
  }
  public Medico[] ListarMed(){
    Medico[] m = new Medico[nm];
    Array.Copy(medicos, m, nm);
    return m;
  }
  public Paciente[] ListarPac(){
    Paciente[] p = new Paciente[np];
    Array.Copy(pacientes, p, np);
    return p;
  }
  //Procurar
  public Medico ListarMedId(int id){
    for(int i=0; i<nm ;i++){
      if(medicos[i].Id==id)return medicos[i];
    }
    return null;
  }
  //Procurar
  public Paciente ListarPacId(int id){
    for (int i=0; i<np ;i++){
      if(pacientes[i].Id==id)return pacientes[i];
    }
    return null;
  }
}