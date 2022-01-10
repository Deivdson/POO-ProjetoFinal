using System;

class MainClass{
  private static Funcionario f = new Funcionario("admin", 0100);
  private static Consulta cnslt = new Consulta();
  public static void Main(){
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

  public static int AreaFunc(){
    Consulta c = new Consulta();
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
      else return 0;
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
            case 5: RemoverMed();break;
            case 6: RemoverPac();break;
            case 7: AddHorario(c);break;
            case 8: Horarios(c);break;
          }
        }
        catch(Exception erro){
          Console.WriteLine(erro.Message);
          op = 100;
        }  
      }while(op!=0);
    }
    Console.WriteLine();
    return op;
  }

  public static int AreaMed(){
    int op = 0;
    Console.WriteLine("\n--------------------");
    //Verifica se existem médicos
    Medico[] medicos = f.ListarMed();
    if(medicos.Length == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return op;
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
      else return 0;
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
    return op;
  }

  public static int AreaPac(){
    int op = 0;
    Console.WriteLine("\n--------------------");
    //Verifica se existem pacientes.
    Paciente[] pacientes = f.ListarPac();
    if(pacientes.Length == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return op;
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
      else return 0;
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
    return op;
  }

  public static int MenuFunc(){
    Console.WriteLine("\n---------Menu do funcionário---------");
    Console.WriteLine("1 - Cadastrar médico");
    Console.WriteLine("2 - Cadastrar paciente");
    Console.WriteLine("3 - Listar médico");
    Console.WriteLine("4 - Listar paciente");
    Console.WriteLine("5 - Remover médico");
    Console.WriteLine("6 - Remover paciente");
    Console.WriteLine("7 - Adicionar horário");
    Console.WriteLine("8 - Listar horários");
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
    Console.WriteLine("Informe o id:");
    int id = int.Parse(Console.ReadLine());

    Medico m = new Medico(nome, cpf, nascimento,id);
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
    Console.WriteLine("Informe o id:");
    int id = int.Parse(Console.ReadLine());

    Paciente p = new Paciente(nome, cpf, nascimento,id);
    f.InserirPac(p);

  }
  public static void ListarMed(){
    Console.WriteLine("---Lista de Médicos---");
    Medico[] medicos = f.ListarMed();
    if(medicos.Length == 0){
      Console.WriteLine("Nenhum médico cadastrado.");
      return;
    }
    foreach(Medico m in medicos) Console.WriteLine($"{m.Nome}\n");
  }
  public static void ListarPac(){
    Console.WriteLine("---Lista de Pacientes---");
    Paciente[] pacientes = f.ListarPac();
    if(pacientes.Length == 0){
      Console.WriteLine("Nenhum paciente cadastrado.");
      return;
    }
    foreach(Paciente p in pacientes) Console.WriteLine($"{p.Nome}\n");
  }
  public static void RemoverMed(){
    Console.WriteLine("-----Exclusão de Médicos-----");
    //Verifica se existem médicos
    Medico[] medicos = f.ListarMed();
    if(medicos.Length == 0){
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
    Paciente[] pacientes = f.ListarPac();
    if(pacientes.Length == 0){
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

  public static void AgendarConsultaMed(Medico m){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("Informe uma descrição:");
    string desc = Console.ReadLine();
    Console.WriteLine("Informe um ID:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Selecione uma Data:");
    Horarios(cnslt);
    int index = int.Parse(Console.ReadLine());
    DateTime data = cnslt.BuscaH(index);
    string status = "Agendada";
    Consulta c = new Consulta(desc,status,data,id);
    m.AgendarCnslt(c);
  }
  public static void ConsultasMed(Medico m){
    Console.WriteLine("---Lista de Consultas---");
    Consulta[] consultas = m.ListarConsultas();
    if(consultas.Length == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    foreach(Consulta c in consultas) Console.WriteLine($"{c}\n");
  }

  public static void AgendarConsultaPac(Paciente p){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("Informe uma descrição:");
    string desc = Console.ReadLine();
    Console.WriteLine("Informe um ID:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Selecione uma Data:");
    Horarios(cnslt);
    int index = int.Parse(Console.ReadLine());
    DateTime data = cnslt.BuscaH(index);
    string status = "Agendada";

    Consulta c = new Consulta(desc,status,data,id);
    p.AgendarCnslt(c);
  }
  public static void ConsultasPac(Paciente p){
    Console.WriteLine("---Lista de Consultas---");
    Consulta[] consultas = p.ListarConsultas();
    if(consultas.Length == 0){
      Console.WriteLine("Nenhuma consulta agendada.");
      return;
    }
    foreach(Consulta c in consultas) Console.WriteLine($"{c}\n");
  }
  public static void AtualizarConsultaMed(Medico m){
    Console.WriteLine("\n-------Atualizar Consulta-------");
    Console.WriteLine("Informe o ID da consulta:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o status atual da consulta:");
    string status = Console.ReadLine();
    Console.WriteLine("Informe o diagnóstico:");
    string diag = Console.ReadLine();

    m.AtualizarConsulta(id,status,diag);
  }
  public static void AddHorario(Consulta c){
    Console.WriteLine("\n-----Adição de Horários-----");
    Console.WriteLine("Informe um novo horário:");
    DateTime h = DateTime.Parse(Console.ReadLine());
    cnslt.AdicionarH(h);
  }
  public static void Horarios(Consulta c){
    Console.WriteLine("---Lista de Horários---");
    DateTime[] horarios = cnslt.Horarios();
    if(horarios.Length == 0){
      Console.WriteLine("Nenhum horário disponível.");
      return;
    }
    int cont=1;
    foreach(DateTime h in horarios){
      Console.WriteLine($"{cont} - {h} ({h.DayOfWeek})\n");
      cont++;
    }
    
  }
}


