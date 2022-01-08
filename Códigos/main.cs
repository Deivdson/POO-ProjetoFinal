using System;

class MainClass{
  public static void Main(){
    Paciente p = new Paciente("juka", "010293", 04-04-2001);
    int op = 0;
    Console.WriteLine("---Sistema de Gerenciamento de Consultass---");
    do{
      try{
        op = Menu();
        switch(op){
          case 1: MenuFunc();break;
          case 2: MenuMed();break;
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
    Console.WriteLine("\n--------------------");
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

  public static int MenuFunc(){
    Console.WriteLine("\n--------------------");
    Funcionario f = new Funcionario("admin", 0100);
    Console.WriteLine("Menu Funcionário - Bem Vindo! ");
    Console.WriteLine(f.nome);
    
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuMed(){
    Console.WriteLine("\n--------------------");
    Console.WriteLine("Menu Médico - Bem Vindo!");

    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuPac(){
    Console.WriteLine("\n--------------------");
    Console.WriteLine("Menu Paciente - Bem Vindo !");

    Console.WriteLine("0 - Sair");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
}