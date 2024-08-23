using System.Globalization;

class Program
{
  static void Main()
  {
    bool checkChoice = true;

    while (checkChoice)
    {
      Console.WriteLine("Escolha uma das opções abaixo:");
      Console.WriteLine("1 - Boas Vindas");
      Console.WriteLine("2 - Concatenar nome e sobrenome");
      Console.WriteLine("3 - Calculo entre dois valores");
      Console.WriteLine("4 - Contar caracteres de uma palavra");
      Console.WriteLine("5 - Verifica placa");
      Console.WriteLine("6 - Exibir a data atual");
      Console.WriteLine("0 - SAIR");

      string choice = Console.ReadLine();

      if (int.TryParse(choice, out _))
      {
        int parseChoice = int.Parse(choice);

        switch (parseChoice)
        {
          case 0:
            {
              checkChoice = false;
            }
            break;
          case 1:
            {
              Console.WriteLine(BoasVindas());
            }
            break;
          case 2:
            {
              Console.WriteLine(ConcatenarNomeCompleto());
            }
            break;
          case 3:
            {
              Console.WriteLine(OperacoesComNumeros());
            }
            break;
          case 4:
            {
              Console.WriteLine($"A quantidade de carateres é {ContarCaracteres()}");
            }
            break;
          case 5:
            {
              Console.WriteLine($"A placa é valida? {CheckPlacas()}");
            }
            break;
          case 6:
            {
              DataAtual();
            }
            break;
          default:
            {
              Console.WriteLine("Valor Inválido, escolha um número de 0 a 6, conforme o Menu\n");
            }
            break;
        }
      }
      else
      {
        Console.WriteLine("Valor Inválido, escolha um número de 0 a 6, conforme o Menu\n");
      }

    }
  }

  static string BoasVindas()
  {
    Console.WriteLine("Digite seu Nome: ");
    string name = Console.ReadLine();

    return $"Olá {name}! Seja muito bem-vindo!\n";
  }

  static string ConcatenarNomeCompleto()
  {
    Console.WriteLine("Digite seu primeiro Nome:");
    string name = Console.ReadLine();

    Console.WriteLine("Digite seu sobrenome:");
    string lastName = Console.ReadLine();

    return $"{name} {lastName}\n";
  }

  static string OperacoesComNumeros()
  {
    Console.WriteLine("Digite o primeiro número:");
    string firstValue = Console.ReadLine();

    Console.WriteLine("Digite o segundo número:");
    string secondValue = Console.ReadLine();

    double sum = 0;
    double subtract = 0;
    double multiplication = 0;
    double division = 0;

    if (double.TryParse(firstValue, out _) && double.TryParse(secondValue, out _))
    {
      double firstValueParse = double.Parse(firstValue);
      double secondValueParse = double.Parse(secondValue);
      sum = firstValueParse + secondValueParse;
      subtract = firstValueParse - secondValueParse;
      multiplication = firstValueParse * secondValueParse;
      division = firstValueParse / secondValueParse;
    }
    else
    {
      Console.WriteLine("Por favor, digite apenas números!\n");
    }

    return $@"
    O valor da soma dos dois números é {sum}
    O valor da subtração dos dois números é {subtract}
    O valor da multiplicação dos dois números é {multiplication}
    O valor da divisão dos dois números é {division}
    ";
  }

  static int ContarCaracteres()
  {
    Console.WriteLine("Digite uma palavra ou frase...");
    string wordOrPhrase = Console.ReadLine();

    int count = wordOrPhrase.Replace(" ", "").Length;
    return count;
  }

  static bool CheckPlacas()
  {
    Console.WriteLine("Digite uma placa contendo 3 letras e 4 numeros...");

    string placa = Console.ReadLine();
    bool check = true;

    if (placa.Length != 7)
    {
      Console.WriteLine("A Placa deve ter 7 caracteres. Digite a placa novamente...");
      placa = Console.ReadLine();
    }

    for (int i = 0; i < placa.Length; i++)
    {
      bool checkChar = Char.IsNumber(placa[i]);
      if (i < 3 && checkChar)
      {
        check = false;
      }
      else if (i >= 3 && !checkChar)
      {
        check = false;
      }

      if (!check) break;
    }
    return check;
  }

  static void DataAtual()
  {
    string formatoCompleto = DateTime.Now.ToString("dd MMMM yyyy - hh:mm:ss", new CultureInfo("pt-BR"));
    string formatoBR = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
    string formato24h = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("pt-BR"));
    string formatoMesPorExtenso = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("pt-BR"));

    Console.WriteLine($@"
      Data completa: {formatoCompleto},
      Data no formato dd/mm/aaaa: {formatoBR},
      Hora no formato 24 horas: {formato24h},
      Data com mês por extenso: {formatoMesPorExtenso}!
      "
    );
  }
}