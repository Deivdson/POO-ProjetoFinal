using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

class MainClass{
  public static Funcionario f = new Funcionario("admin", 0100);
  
  public static NFuncionario NF = NFuncionario.Singleton;
  public static NMedico NM = NMedico.Singleton;
  public static NPaciente NP = NPaciente.Singleton;
  public static NConsulta NC = NConsulta.Singleton;
  
  private static Consulta cnslt = new Consulta();
  public static void Main(){
    NF.InserirFunc(f);
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    try{
      NC.Abrir();
      NF.Abrir();
      NM.Abrir();
      NP.Abrir();
      
    }catch(Exception erro){
      Console.WriteLine(erro.Message);
    }
    int op = 0;
    Console.WriteLine("---Sistema de Gerenciamento de Consultass---");
    do{
      try{
        op = Menu();
        switch(op){
          case 1: AreaFunc();break;
          case 2: AreaMed();break;
          case 3: AreaPac();break;
        }
      }
      catch(Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
        
    }while(op!=0);

    try{
      NC.Salvar();
      NF.Salvar();
      NM.Salvar();
      NP.Salvar();
      
    }catch(Exception erro){
      Console.WriteLine(erro.Message);
    }

    Console.WriteLine("Adios... *barulho do windows desligando*");

  }
  public static int Menu(){
    Console.WriteLine("\n---------Menu Inicial---------");
    Console.WriteLine("Entrar como:");
    Console.WriteLine("1 - Funcionário");
    Console.WriteLine("2 - Médico");
    Console.WriteLine("3 - Paciente");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void AreaFunc(){
    int op = 0;
    Console.WriteLine("\n--------------------");
    Console.WriteLine("\nLogin Funcionário:");
    Console.WriteLine("\nDigite o nome de usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine("\nDigite a senha:");
    int senha = int.Parse(Console.ReadLine());
    Funcionario NL = NF.ProcurarFunc(nome);
    if(nome != NL.Nome || senha != NL.Senha){
      Console.WriteLine("Dados incorretos! Tentar novamente (1) - Voltar ao menu inicial (0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)AreaFunc();
      else return;
    }else{

      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine($"Bem Vind@ {NL.Nome}! ");
      do{
        try{
          op = MenuFunc();
          switch(op){
            case 1: CadastrarMed();break;
            case 2: CadastrarPac();break;
            case 3: ListarMed();break;
            case 4: ListarPac();break;
            case 5: EditarMed();break;
            case 6: EditarPac();break;
            case 7: RemoverMed();break;
            case 8: RemoverPac();break;
            case 9: GerenciarConsultas();break;
            case 10: CadastrarFunc();break;
            case 11: ListarFunc();break;
            case 12: EditarFunc();break;
            case 13: RemoverFunc();break;
            case 14: ListarPacNome();break; 
            case 15: ListarMedNome();break;
            case 16:ToXml();break;
          }
        }
        catch(Exception erro){
          Console.WriteLine(erro.Message);
          op = 100;
        }  
      }while(op!=0);
    }
    Console.WriteLine();
  }

  public static void AreaMed(){
    int op = 0;
    Console.WriteLine("\n--------------------");
    //Verifica se existem médicos
    List<Medico> medicos = NM.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    //-------------------------------------------------
    Console.WriteLine("\nLogin Médico:");
    Console.WriteLine("\nDigite o nome de usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine("\nDigite o cpf:");
    int cpf = int.Parse(Console.ReadLine());

    Medico m = NM.ProcurarMed(nome);

    if(!(nome.Equals(m.Nome) || cpf.Equals(m.Cpf))){
      Console.WriteLine("Dados incorretos! Deseja tentar novamente (1) ou voltar ao menu inicial?(0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)AreaMed();
      else return;
    }else{

      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine($" Bem Vind@ {m.Nome}! ");
      do{
        try{
          op = MenuMed();
          switch(op){
            case 1: AgendarConsultaMed(m);break;
            case 2: ConsultasMed(m);break;
            case 3: AtualizarConsultaMed(m);break;
          }
        }
        catch(Exception erro){
          Console.WriteLine(erro.Message);
          op = 100;
        }  
      }while(op!=0);
    }
    Console.WriteLine();
  }

  public static void AreaPac(){
    int op = 0;
    Console.WriteLine("\n--------------------");
    //Verifica se existem pacientes.
    List<Paciente> pacientes = NP.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    //---------------------------------------------------
    Console.WriteLine("\nLogin Paciente:");
    Console.WriteLine("\nDigite o nome de usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine("\nDigite o cpf:");
    int cpf = int.Parse(Console.ReadLine());

    Paciente p = NP.ProcurarPac(nome);

    if(!(nome.Equals(p.Nome) || cpf.Equals(p.Cpf))){
      Console.WriteLine("Dados incorretos! Deseja tentar novamente (1) ou voltar ao menu inicial?(0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)AreaPac();
      else return;
    }else{
      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine($" Bem Vindo {p.Nome}! ");
      do{
        try{
          op = MenuPac();
          switch(op){
            case 1: AgendarConsultaPac(p);break;
            case 2: ConsultasPac(p);break;
          }
        }
        catch(Exception erro){
          Console.WriteLine(erro.Message);
          op = 100;
        }  
      }while(op!=0);
    }
    Console.WriteLine();
  }

  public static void GerenciarConsultas(){
    int op = 0;
    do{
        try{
          op = MenuGerenciamento();
          switch(op){
            case 1: AgendarConsultaFunc();break;
            case 2: ConsultasOP();break;
            case 3: AtualizarConsultaPac();break;
          }
        }
        catch(Exception erro){
          Console.WriteLine(erro.Message);
          op = 100;
        }  
      }while(op!=0);
  }

  public static int MenuFunc(){
    Console.WriteLine("\n------------Menu do funcionário-------------");
    Console.WriteLine("1 - Cadastrar médico       2 - Cadastrar paciente    ");
    Console.WriteLine("3 - Listar médico          4 - Listar paciente");
    Console.WriteLine("5 - Editar médico          6 - Editar paciente");
    Console.WriteLine("7 - Remover médico         8 - Remover paciente");
    Console.WriteLine("\n---------------------------");
    Console.WriteLine("\n>9 - Gerenciar Consultas<\n");
    Console.WriteLine("\n------------------------\n");
    Console.WriteLine("10 - Cadastrar novo funcionário | 11 - Listar funcionários");
    Console.WriteLine("12 - Atualizar funcionário      | 13 - Remover funcionário");
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("14 - Listar pacientes por nome  15 - Listar médicos por nome");
    Console.WriteLine("[16 - Salvar dados do sistema]");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuMed(){
    Console.WriteLine("\n---------Menu do Médico---------");
    Console.WriteLine("1 - Agendar consulta");
    Console.WriteLine("2 - Listar consultas");
    Console.WriteLine("3 - Atualizar consulta");

    Console.WriteLine("0 - Voltar");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuPac(){
    Console.WriteLine("\n---------Menu Paciente-----------");
    Console.WriteLine("1 - Solicitar consulta");
    Console.WriteLine("2 - Listar consultas");

    Console.WriteLine("0 - Voltar");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuGerenciamento(){
    Console.WriteLine("\n---------Menu Gerenciamento de Consultas---------");
    Console.WriteLine("1 - Agendar uma nova consulta");
    Console.WriteLine("2 - Listar consultas");
    Console.WriteLine("3 - Gerenciar consultas");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void CadastrarMed(){
    Console.WriteLine("---Cadastro de Medico---");
    Console.WriteLine("Informe o nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o cpf:");
    string cpf = Console.ReadLine();
    DateTime nascimento = new DateTime();
    
    try{
      Console.WriteLine("Informe a data de nascimento:");
      nascimento = DateTime.Parse(Console.ReadLine());
      if(DateTime.Now<=nascimento){
        throw new ArgumentOutOfRangeException("O valor informado não é valido");
      }
    }
    catch(FormatException){
      Console.WriteLine("Formato da data inválido");
    }

    Medico m = new Medico(nome, cpf, nascimento);
    NM.InserirMed(m);
  }
  public static void CadastrarPac(){
    Console.WriteLine("---Cadastro de Paciente---");
    Console.WriteLine("Informe o nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o cpf:");
    string cpf = Console.ReadLine();
    DateTime nascimento = new DateTime();
     
    try{ 
      Console.WriteLine("Informe a data de nascimento:");
      nascimento = DateTime.Parse(Console.ReadLine());
      if(DateTime.Now<=nascimento){
        throw new ArgumentOutOfRangeException("O valor informado não é valido");
      }
    } 
    catch(FormatException){
      Console.WriteLine("Formato da data inválido");
    }

   Paciente p = new Paciente(nome, cpf, nascimento);
    NP.InserirPac(p);
  }
  public static void CadastrarFunc(){
    Console.WriteLine("---Cadastro de Funcionarios---");
    Console.WriteLine("Informe o nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe a senha:");
    int senha = int.Parse(Console.ReadLine());

    Funcionario func = new Funcionario(nome, senha);
    NF.InserirFunc(func);

  }


  public static void ListarMed(){
    Console.WriteLine("---Lista de Médicos---");
    List<Medico> medicos = NM.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    var v1= medicos.Select(m=> new {
      Nome = m.Nome, 
      Idade = DateTime.Now.Year - m.Nascimento.Year
    });

    foreach(var obj in v1)Console.WriteLine(obj);
  }

  public static void ListarMedNome(){
    Console.WriteLine("---Lista de Médicos---");
    Console.WriteLine("\n Digite um nome: ");
    string n = Console.ReadLine();
    List<Medico> medicos = NM.ListarMedNome(n);
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado com esse nome.");
      return;
    }
    foreach(Medico m in medicos) Console.WriteLine($"Nome: {m.Nome} {m.Id}\n");
  }
  
  public static void ListarPac(){
    Console.WriteLine("---Lista de Pacientes---");
    List<Paciente> pacientes = NP.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
   
    var v1= pacientes.Select(p=> new {
      Nome = p.Nome, 
      Gasto_Total = p.Valores.Sum()
    });
    
    /* var v1= pacientes.Select(p=> new {
      Nome = p.Nome, 
      Gasto_Total = p.Consultas.Sum(vi=>vi.Custo)
    }); */

    foreach(var obj in v1)Console.WriteLine(obj);


    Console.WriteLine();
    var v2 = v1.GroupBy(obj=>obj.Nome, (key, valores) => new{
      Nome= key,
      Tamanho_Lista= valores.Count()
    });
    foreach(var obj in v2)Console.WriteLine(obj);
   /*  foreach(Paciente p in pacientes) Console.WriteLine($"{p.Nome}\n"); */
  }


  public static void ListarPacNome(){
    Console.WriteLine("---Lista de Pacientes---");
    Console.WriteLine("\n Digite um nome: ");
    string n = Console.ReadLine();
    List<Paciente> pacientes = NP.ListarPacNome(n);
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado com esse nome.");
      return;
    }
  
    foreach(Paciente p in pacientes) Console.WriteLine($"Nome: {p.Nome} ID: {p.Id}\n"); 
  }

  
  public static void ListarFunc(){
    Console.WriteLine("---Lista de Funcionários---");
    List<Funcionario> funcionarios = NF.ListarFunc();
    if(funcionarios.Count == 0){
      Console.WriteLine("Nenhum funcionário cadastrado.");
      return;
    }
    foreach(Funcionario func in funcionarios) Console.WriteLine($"{func.Nome}\n");
  }

  public static void EditarMed(){
    Console.WriteLine("\n-------Editar Médico-------");
    //Verifica se existem médicos
    List<Medico> medicos = NM.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    //-------------------------------------------------
    ListarMed();
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe um novo cpf:");
    string cpf = Console.ReadLine();
    DateTime data = new DateTime();
    try{
    Console.WriteLine("Informe uma nova data de nascimento:");
    data = DateTime.Parse(Console.ReadLine());
    if(DateTime.Now<=data){
        throw new ArgumentOutOfRangeException("O valor informado não é valido");
      }
    }
    catch(FormatException){
      Console.WriteLine("Formato da data invalido");
    }
    Medico m = new Medico(nome,cpf,data);
    NM.AtualizarMed(m);
  }
  public static void EditarPac(){
    Console.WriteLine("\n-------Editar Paciente-------");
    //Verifica se existem pacientes.
    List<Paciente> pacientes = NP.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    //---------------------------------------------------
    PacientesOP();
    Console.WriteLine("Informe o ID do paciente:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe um novo cpf:");
    string cpf = Console.ReadLine();
    Console.WriteLine("Informe uma nova data de nascimento:");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Paciente p = new Paciente(nome,cpf,data);
    NP.AtualizarPac(id,p);
  }
  public static void EditarFunc(){
    Console.WriteLine("\n-------Editar Funcionario-------");
    //Verifica se existem pacientes.
    List<Funcionario> funcionarios = NF.ListarFunc();
    if(funcionarios.Count == 0){
      Console.WriteLine("Nenhum funcionário cadastrado.");
      return;
    }
    //---------------------------------------------------
    ListarFunc();
    Console.WriteLine("Informe o funcionário que deseja atualizar:");
    string n = Console.ReadLine();
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe uma nova senha:");
    int senha = int.Parse(Console.ReadLine());
    Funcionario f = new Funcionario(nome, senha);
    NF.AtualizarFunc(n,f);
  }

  public static void RemoverMed(){
    Console.WriteLine("-----Exclusão de Médicos-----");
    //Verifica se existem médicos
    List<Medico> medicos = NM.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    //-------------------------------------------------
    ListarMed();
    Console.WriteLine("Informe o médico que deseja remover");
    string nome = Console.ReadLine();
    Medico m = NM.ProcurarMed(nome);
    NM.RemoverMed(m);
  }
  public static void RemoverPac(){
    Console.WriteLine("-----Exclusão de Pacientes-----");
    //Verifica se existem pacientes.
    List<Paciente> pacientes = NP.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    //---------------------------------------------------
    ListarPac();
    Console.WriteLine("Informe o paciente que deseja remover");
    string nome = Console.ReadLine();
    Paciente p = NP.ProcurarPac(nome);
    NP.RemoverPac(p);
  }
  public static void RemoverFunc(){
    Console.WriteLine("-----Exclusão de Funcionários-----");
    //Verifica se existem funcionarios.
    List<Funcionario> funcionarios = NF.ListarFunc();
    if(funcionarios.Count == 0){
      Console.WriteLine("Nenhum funcionário cadastrado.");
      return;
    }
    //---------------------------------------------------
    ListarFunc();
    Console.WriteLine("Informe o funcionário que deseja remover");
    string nome = Console.ReadLine();
    Funcionario f = NF.ProcurarFunc(nome);
    NF.RemoverFunc(f);
  }



  public static void AgendarConsultaMed(Medico m){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("Informe uma descrição:");
    string desc = Console.ReadLine();
    DateTime data = DateTime.Now;
    try{
    Console.WriteLine("Informe uma data e horário:");
    data = DateTime.Parse(Console.ReadLine());
    if(data<DateTime.Now) throw new ArgumentOutOfRangeException("Data inválida - a menos que você consiga voltar no tempo.");
    }
    catch(FormatException){
      Console.WriteLine("Formato da data inválido!");
    }

    Console.WriteLine("Selecione um paciente:");
    PacientesOP();
    int idPac = int.Parse(Console.ReadLine());
    Paciente p = NP.ProcurarPacID(idPac);
    string status = "Agendada";
    Consulta c = new Consulta(m,p,desc,status,data);
    c.Custo=10;
    NC.AgendarCnslt(c);
  }
  public static void ConsultasMed(Medico m){
    Console.WriteLine("---Lista de Consultas---");
    var consultas = NC.ListarConsultas().Where(s=>s.Medico.Id==m.Id).ToList();
    /* List<Consulta> consultas = NC.ListarConsultasIDM(m.Id); */
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
     
    foreach(Consulta c in consultas)
      Console.WriteLine($"{c.Id} | {c.Descricao} | {c.Diagnostico} | {c.Data}\n");
    
    /* var r1 = consultas.Where(s=>s.Id==m.Id);
    foreach(Consulta c in r1) Console.WriteLine(c); */
    /* var v1= consultas.Select(c=>c.Descricao);
    var v2= consultas.Select(c=>c.Paciente);
    foreach(Paciente s in v2){   
      Console.WriteLine($"Nome: {s.Nome}");
    } */
    /* foreach(Consulta c in consultas){
      if(c.Medico.Nome==m.Nome)Console.WriteLine($"{c}\n");
    } */ 
  }


  public static void AgendarConsultaPac(Paciente p){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("O que está sentindo:");
    string desc = Console.ReadLine();
    
    string status = "Em processo.";

    Consulta c = new Consulta(p,desc,status);
    c.Custo=15;
    
    NC.AgendarCnslt(c);
  }
  
  public static void ConsultasPac(Paciente p){
    Console.WriteLine("---Lista de Consultas---");
    /* List<Consulta> consultas = NC.ListarConsultasIDP(p.Id); */
    var consultas = NC.ListarConsultas().Where(s=>s.Paciente.Id==p.Id).ToList();
    
    /* List<Consulta> consultas = p.ListarCnslt(); */
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    foreach(Consulta c in consultas) Console.WriteLine($"{c.Id} | {c.Descricao} | {c.Diagnostico} | {c.Data}\n");
    /* var v1= consultas.Select(c=>c.Descricao);
    var v2 = consultas.Select(c=>c);
    foreach(String s in v1){   
      Console.WriteLine($"Descrição: {s}\n");
      
      foreach(string s1 in v1) Console.WriteLine($"Descrição: {s1}");
    } */    
  }

  public static void AtualizarConsultaMed(Medico m){
    Console.WriteLine("\n-------Atualizar Consulta-------");
    //Verifica se existem consultas.
    List<Consulta> consultas = NC.ListarConsultasIDM(m.Id);
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    //---------------------------------------------------
    foreach(Consulta c in consultas) Console.WriteLine(c);
    Console.WriteLine("Informe o ID da consulta:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o status atual da consulta:");
    string status = Console.ReadLine();
    Console.WriteLine("Informe o diagnóstico:");
    string diag = Console.ReadLine();
    Console.WriteLine("Informe o custo da consulta:");
    int custo = int.Parse(Console.ReadLine());

    NC.AtualizarConsultaMed(id,status,diag,custo);
  }
  public static void AtualizarConsultaPac(){
    Console.WriteLine("\n-------Gerenciamento de Consultas-------");
    //Verifica se existem paciente.
    List<Paciente> pacientes = NP.ListarPac();
    List<Medico> medicos = NM.ListarMed();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }

    //---------------------------------------------------
    Console.WriteLine("----Lista de pacientes----");
    foreach(Paciente p in pacientes){
      Console.WriteLine($"[{p.Nome}]\n");
      List<Consulta> consultas = NC.ListarConsultas().Where(s=>s.Paciente.Id==p.Id).ToList();
      if(consultas.Count == 0){
        Console.WriteLine("Nenhuma consulta cadastrada.");
        return;
      }
      foreach(Consulta c in consultas)
        Console.WriteLine($"{c.Id} | {c.Descricao} | {c.Data} | Custo: R$ {c.Custo}\n");
    }
    Console.WriteLine("Informe um paciente:");
    string pac = Console.ReadLine();
    Console.WriteLine("Informe o ID da consulta:");
    int id = int.Parse(Console.ReadLine());
    Paciente paciente = NP.ProcurarPac(pac);

    Console.WriteLine("Informe o status atual da consulta:");
    string status = Console.ReadLine();
    Console.WriteLine("Informe o custo da consulta:");
    int custo = int.Parse(Console.ReadLine());
    DateTime data = new DateTime();

    try{
    Console.WriteLine("Informe uma data e horário:");
    data = DateTime.Parse(Console.ReadLine());
    if(data<DateTime.Now) throw new ArgumentOutOfRangeException("Data inválida - a menos que você consiga voltar no tempo.");
    }
    catch(FormatException){
      Console.WriteLine("Formato da data inválido!");
    }

    Console.WriteLine("\n----Lista de médicos----");
    foreach(Medico m in medicos)
      Console.WriteLine($"ID: {m.Id} - Nome: {m.Nome}");

    Console.WriteLine("\nInforme um ID:");
    int index = int.Parse(Console.ReadLine());
    
    Medico medico = NM.ProcurarMedID(index);
    /*
    Consulta con = new Consulta(paciente.Nome, status, data);
    medico.AgendarCnslt(con);  */
    NC.AtualizarConsulta(id,medico,paciente,data,status,custo);
  }
  public static void AgendarConsultaFunc(){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("Informe uma descrição:");
    string desc = Console.ReadLine();
    DateTime data = DateTime.Now;
    try{
    Console.WriteLine("Informe uma data e horário:");
    data = DateTime.Parse(Console.ReadLine());
    if(data<DateTime.Now) throw new ArgumentOutOfRangeException("Data inválida - a menos que você consiga voltar no tempo.");
    }
    catch(FormatException){
      Console.WriteLine("Formato da data inválido!");
    }
    PacientesOP();
    Console.WriteLine("Selecione um paciente:");
    int idPac = int.Parse(Console.ReadLine());
    Paciente p = NP.ProcurarPacID(idPac);

    MedicosOP();
    Console.WriteLine("Selecione um médico:");
    int idMed = int.Parse(Console.ReadLine());
    Medico m = NM.ProcurarMedID(idMed);
    
    string status = "Agendada";
    Consulta c = new Consulta(m,p,desc,status,data);
    
    Console.WriteLine("Informe o custo");
    c.Custo=int.Parse(Console.ReadLine());
    NC.AgendarCnslt(c);
  }

  
  public static void MedicosOP(){
    Console.WriteLine("---Lista de Médicos---");
    List<Medico> medicos = NM.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico disponível.");
      return;
    }
    foreach(Medico m in medicos){
      Console.WriteLine($"{m.Id} - {m.Nome}\n");
    }    
  }
  public static void PacientesOP(){
    Console.WriteLine("---Lista de Paciente---");
    List<Paciente> pacientes = NP.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente disponível.");
      return;
    }
    foreach(Paciente p in pacientes){
      Console.WriteLine($"{p.Id} - {p.Nome}\n");
    }    
  }
  public static void ConsultasOP(){
    Console.WriteLine("---Lista de Consultas---");
    List<Consulta> consultas = NC.ListarConsultas();
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta cadastrada.");
      return;
    }
    foreach(Consulta c in consultas){
      Console.WriteLine($"{c.Id} - Paciente: {c.Paciente.Nome} - Médico: {c.Medico.Nome} - Data: {c.Data}\n");
    }    
  }

  public static void ToXml(){
    try{
      NC.Salvar();
      NF.Salvar();
      NM.Salvar();
      NP.Salvar();
      
    }catch(Exception erro){
      Console.WriteLine(erro.Message);
    }
  }
}


