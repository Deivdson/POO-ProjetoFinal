using System;

class MainClass{
  private static Funcionario f = new Funcionario("admin", 0100);
  public static void Main(){
    int op = 0;
    Console.WriteLine("---Sistema de Gerenciamento de Consultass---");
    do{
      try{
        op = Menu();
        switch(op){
          case 1: AreaFunc();break;
          case 2: AreaMed();break;
          case 3: MenuPac();break;
        }
      }
      catch(Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
        
    }while(op!=0);

    Console.WriteLine("------Adios------");

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
      if(i==1)MenuFunc();
      else return 0;
    }else{

      Console.WriteLine("\n--------------------");
      Console.WriteLine($"Bem Vindo {f.Nome}! ");
      do{
        try{
          op = MenuFunc();
          switch(op){
            case 1: CadastrarMed();break;
            case 2: CadastrarPac();break;
            case 3: ListarMed();break;
            case 4: ListarPac();break;
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
    Console.WriteLine("\nLogin Médico:");
    Console.WriteLine("\nDigite o nome de usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine("\nDigite o cpf:");
    int cpf = int.Parse(Console.ReadLine());

    Medico m = f.ProcurarMed(nome);

    if(!(nome.Equals(m.Nome) || cpf.Equals(m.Cpf))){
      Console.WriteLine("Dados incorretos! Deseja tentar novamente (1) ou voltar ao menu inicial?(0)");
      int i = int.Parse(Console.ReadLine());
      if(i==1)MenuMed();
      else return 0;
    }else{

      Console.WriteLine("\n--------------------");
      Console.WriteLine($"Bem Vindo {m.Nome}! ");
      do{
        try{
          op = MenuMed();
          switch(op){
            case 1: AgendarConsultaMed(m);break;
            case 2: ConsultasMed(m);break;
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
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuMed(){
    Console.WriteLine("\n---------Menu do funcionário---------");
    Console.WriteLine("1 - Agendar consulta");
    Console.WriteLine("2 - Listar consultas");

    Console.WriteLine("0 - Voltar");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuPac(){
    Console.WriteLine("\n--------------------");
    Paciente p = new Paciente("juka", "010293", DateTime.Parse("04/04/2001"), 15);
    Console.WriteLine("Menu Paciente - Bem Vindo !");

    Console.WriteLine("0 - Voltar");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void CadastrarMed(){
    Console.WriteLine("---Cadastrar de Medico---");
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
    Console.WriteLine("---Cadastrar de Paciente---");
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

  public static void AgendarConsultaMed(Medico m){
    Console.WriteLine("\n--------Agendamento de Consulta---------");
    Console.WriteLine("Informe uma descrição:");
    string desc = Console.ReadLine();
    Console.WriteLine("Informe um ID:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Selecione uma Data:");
    DateTime data = DateTime.Parse(Console.ReadLine());
    string status = "Agendada";
    Consulta c = new Consulta(desc,status,data,id);
    m.AgendarCnslt(c);

    Console.WriteLine(m);
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
}


