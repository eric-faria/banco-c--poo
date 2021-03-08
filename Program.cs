using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>(); 
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() !=  "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default: 
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();


            } 

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Transferência");
            System.Console.WriteLine();

            System.Console.WriteLine("Conta de origem: ");
            int origem = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            System.Console.WriteLine("Conta de detino: ");
            int destino = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            System.Console.WriteLine("Valor da transferência: R$ ");
            double valor = double.Parse(Console.ReadLine());
            System.Console.WriteLine();

            ListaContas[origem].Transferir(valor, ListaContas[destino]);
        }

        private static void Sacar()
        {
            System.Console.WriteLine("Número da conta: ");
            int IndiceConta = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            System.Console.WriteLine("valor do saque: R$ ");
            double valorSaque = double.Parse(Console.ReadLine());
            System.Console.WriteLine();

            ListaContas[IndiceConta].Sacar(valorSaque); 
        }

        private static void Depositar()
        {
            System.Console.WriteLine("Número da conta: ");
            int IndiceConta = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            System.Console.WriteLine("Valor do depósito: R$ ");
            double valorDeposito = double.Parse(Console.ReadLine());
            System.Console.WriteLine();

            ListaContas[IndiceConta].Depositar(valorDeposito); 
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas");
            System.Console.WriteLine();

            if (ListaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada");
                return;
            } 

            for (int i = 0; i < ListaContas.Count; i ++)
            {
                Conta conta = ListaContas[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir Nova Conta");
            System.Console.WriteLine();
            
            System.Console.WriteLine("Digite 1 para pessoa física e 2 para pessoa jurídica.");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            System.Console.WriteLine("Saldo inicial: R$ ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Crédito: R$ ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta (   TipoConta: (TipoConta)entradaTipoConta,
                                            Saldo: entradaSaldo,
                                            Credito: entradaCredito,
                                            Nome: entradaNome
                                        );

            ListaContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario ()
        {
            Console.WriteLine();
            Console.WriteLine("Internet Banking");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine();
            
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();   

            string OpcaoUsuario = Console.ReadLine().ToUpper(); 
            Console.WriteLine();
            return OpcaoUsuario;   
        }

    
    }
}
