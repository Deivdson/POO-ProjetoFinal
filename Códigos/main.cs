using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass{
  private static Funcionario f = new Funcionario("admin", 0100);
  private static NFuncionario NF = new NFuncionario();
  private static Consulta cnslt = new Consulta();
  public static void Main(){
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
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

    if(nome != f.Nome || senha != f.Senha){
      Console.WriteLine("Dados incorretos! Deseja tentar novamente (1) ou voltar ao menu inicial?(0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)AreaFunc();
      else return;
    }else{

      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine($"Bem Vindo {f.Nome}! ");
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
            case 9: AddHorario();break;
            case 10: Horarios();break;
            case 11: AtualizarConsultaPac();break;
            case 12: CadastrarFunc();break;
            case 13: ListarFunc();break;
            case 14: EditarFunc();break;
            case 15: RemoverFunc();break;
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
    List<Medico> medicos = f.ListarMed();
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

    Medico m = f.ProcurarMed(nome);

    if(!(nome.Equals(m.Nome) || cpf.Equals(m.Cpf))){
      Console.WriteLine("Dados incorretos! Deseja tentar novamente (1) ou voltar ao menu inicial?(0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)AreaMed();
      else return;
    }else{

      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine($" Bem Vindo {m.Nome}! ");
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
    List<Paciente> pacientes = f.ListarPac();
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

    Paciente p = f.ProcurarPac(nome);

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

  public static int MenuFunc(){
    Console.WriteLine("\n------------Menu do funcionário-------------");
    Console.WriteLine("1 - Cadastrar médico       2 - Cadastrar paciente    ");
    Console.WriteLine("3 - Listar médico          4 - Listar paciente");
    Console.WriteLine("5 - Editar médico          6 - Editar paciente");
    Console.WriteLine("7 - Remover médico         8 - Remover paciente");
    Console.WriteLine("9 - Adicionar horário      10 - Listar horários");
    Console.WriteLine("11 - Gerenciar Consultas");
    Console.WriteLine("\n------------------------\n");
    Console.WriteLine("12 - Cadastrar novo funcionário | 13 - Listar funcionários");
    Console.WriteLine("14 - Atualizar funcionário      | 15 - Remover funcionário");
    Console.WriteLine("----------------------------------------------");
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
    Console.WriteLine("1 - Agendar consulta");
    Console.WriteLine("2 - Listar consultas");

    Console.WriteLine("0 - Voltar");
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
    Console.WriteLine("Informe a data de nascimento:");
    DateTime nascimento = DateTime.Parse(Console.ReadLine());

    Medico m = new Medico(nome, cpf, nascimento);
    f.InserirMed(m);
  }
  public static void CadastrarPac(){
    Console.WriteLine("---Cadastro de Paciente---");
    Console.WriteLine("Informe o nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o cpf:");
    string cpf = Console.ReadLine();
    Console.WriteLine("Informe a data de nascimento:");
    DateTime nascimento = DateTime.Parse(Console.ReadLine());

    Paciente p = new Paciente(nome, cpf, nascimento);
    f.InserirPac(p);

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
    List<Medico> medicos = f.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    foreach(Medico m in medicos) Console.WriteLine($"{m.Nome}\n");
  }
  public static void ListarPac(){
    Console.WriteLine("---Lista de Pacientes---");
    List<Paciente> pacientes = f.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    foreach(Paciente p in pacientes) Console.WriteLine($"{p.Nome}\n");
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
    List<Medico> medicos = f.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    //-------------------------------------------------
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe um novo cpf:");
    string cpf = Console.ReadLine();
    Console.WriteLine("Informe uma nova data de nascimento:");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Medico m = new Medico(nome,cpf,data);
    f.AtualizarMed(m);
  }
  public static void EditarPac(){
    Console.WriteLine("\n-------Editar Paciente-------");
    //Verifica se existem pacientes.
    List<Paciente> pacientes = f.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    //---------------------------------------------------
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe um novo cpf:");
    string cpf = Console.ReadLine();
    Console.WriteLine("Informe uma nova data de nascimento:");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Paciente p = new Paciente(nome,cpf,data);
    f.AtualizarPac(p);
  }
  public static void EditarFunc(){
    Console.WriteLine("\n-------Editar Paciente-------");
    //Verifica se existem pacientes.
    List<Funcionario> funcionarios = NF.ListarFunc();
    if(funcionarios.Count == 0){
      Console.WriteLine("Nenhum funcionário cadastrado.");
      return;
    }
    //---------------------------------------------------
    Console.WriteLine("Informe um novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe uma nova senha:");
    int senha = int.Parse(Console.ReadLine());
    Funcionario f = new Funcionario(nome, senha);
    NF.AtualizarFunc(f);
  }



  public static void RemoverMed(){
    Console.WriteLine("-----Exclusão de Médicos-----");
    //Verifica se existem médicos
    List<Medico> medicos = f.ListarMed();
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    //-------------------------------------------------
    ListarMed();
    Console.WriteLine("Informe o médico que deseja remover");
    string nome = Console.ReadLine();
    Medico m = f.ProcurarMed(nome);
    f.RemoverMed(m);
  }
  public static void RemoverPac(){
    Console.WriteLine("-----Exclusão de Pacientes-----");
    //Verifica se existem pacientes.
    List<Paciente> pacientes = f.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    //---------------------------------------------------
    ListarPac();
    Console.WriteLine("Informe o paciente que deseja remover");
    string nome = Console.ReadLine();
    Paciente p = f.ProcurarPac(nome);
    f.RemoverPac(p);
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
    Console.WriteLine("Selecione uma Data:");
    Horarios();
    int index = int.Parse(Console.ReadLine());
    DateTime data = cnslt.BuscaH(index);

    Console.WriteLine("Selecione um paciente:");
    PacientesOP();
    string paciente = Console.ReadLine();
    Paciente p = f.ProcurarPac(paciente);
    string status = "Agendada";
    Consulta c = new Consulta(paciente,desc,status,data);
    m.AgendarCnslt(c);
    p.AgendarCnslt(c);
  }
  public static void ConsultasMed(Medico m){
    Console.WriteLine("---Lista de Consultas---");
    List<Consulta> consultas = m.ListarConsultas();
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    foreach(Consulta c in consultas) Console.WriteLine($"{c}\n");
  }


  public static void AgendarConsultaPac(Paciente p){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("O que está sentindo:");
    string desc = Console.ReadLine();
    
    string status = "Em processo.";

    Consulta c = new Consulta(p.Nome,desc,status);
    p.AgendarCnslt(c);
  }
  public static void ConsultasPac(Paciente p){
    Console.WriteLine("---Lista de Consultas---");
    List<Consulta> consultas = p.ListarConsultas();
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    foreach(Consulta c in consultas) Console.WriteLine($"{c}\n");
  }


  public static void AtualizarConsultaMed(Medico m){
    Console.WriteLine("\n-------Atualizar Consulta-------");
    //Verifica se existem consultas.
    List<Consulta> consultas = m.ListarConsultas();
    if(consultas.Count == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    //---------------------------------------------------
    Console.WriteLine("Informe o ID da consulta:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o status atual da consulta:");
    string status = Console.ReadLine();
    Console.WriteLine("Informe o diagnóstico:");
    string diag = Console.ReadLine();

    m.AtualizarConsulta(id,status,diag);
  }
  public static void AtualizarConsultaPac(){
    Console.WriteLine("\n-------Gerenciamento de Consultas-------");
    //Verifica se existem paciente.
    List<Paciente> pacientes = f.ListarPac();
    List<Medico> medicos = f.ListarMed();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    if(medicos.Count == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }

    //---------------------------------------------------
    Console.WriteLine("Lista de pacientes:");
    foreach(Paciente p in pacientes){
      Console.WriteLine($"[{p.Nome}]\n");
      List<Consulta> consultas = p.ListarConsultas();
      if(consultas.Count == 0){
        Console.WriteLine("Nenhuma consulta cadastrada.");
        return;
      }
      foreach(Consulta c in consultas)
        Console.WriteLine($"{c}\n");
    }
    Console.WriteLine("Informe um paciente:");
    string pac = Console.ReadLine();
    Console.WriteLine("Informe o ID da consulta:");
    int id = int.Parse(Console.ReadLine());
    Paciente paciente = f.ProcurarPac(pac);

    Console.WriteLine("Informe o status atual da consulta:");
    string status = Console.ReadLine();
    Console.WriteLine("Informe uma data e horário:");
    DateTime data = DateTime.Parse(Console.ReadLine());


    Console.WriteLine("Lista de médicos:");
    foreach(Medico m in medicos)
      Console.WriteLine($"ID: {m.Id} - Nome: {m.Nome}");

    Console.WriteLine("Informe um ID:");
    int index = int.Parse(Console.ReadLine());
    Medico medico = f.ProcurarMedID(index);


    paciente.AtualizarConsulta(id,medico,data,status);
  }



  public static void AddHorario(){
    Console.WriteLine("\n-----Adição de Horários-----");
    Console.WriteLine("Informe um novo horário:");
    DateTime h = DateTime.Parse(Console.ReadLine());
    cnslt.AdicionarH(h);
  }
  public static void Horarios(){
    Console.WriteLine("---Lista de Horários---");
    List<DateTime> horarios = cnslt.Horarios();
    if(horarios.Count == 0){
      Console.WriteLine("Nenhum horário disponível.");
      return;
    }
    int cont=1;
    foreach(DateTime h in horarios){
      Console.WriteLine($"{cont} - {h} ({h.DayOfWeek})\n");
      cont++;
    }
  }


  
  public static void MedicosOP(){
    Console.WriteLine("---Lista de Médicos---");
    List<Medico> medicos = f.ListarMed();
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
    List<Paciente> pacientes = f.ListarPac();
    if(pacientes.Count == 0){
      Console.WriteLine("Nenhum paciente disponível.");
      return;
    }
    foreach(Paciente p in pacientes){
      Console.WriteLine($"{p.Id} - {p.Nome}\n");
    }    
  }
}


