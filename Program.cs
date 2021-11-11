using System;

namespace DIO.Projeto.Series
{
  class Program
  {
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
    {
      string userOption = GetUserOption();

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            ListSeries();
            break;
          case "2":
            InsertSerie();
            break;
          case "3":
            UpdateSerie();
            break;
          case "4":
            DeleteSerie();
            break;
          case "5":
            ViewSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        userOption = GetUserOption();
      }
      Console.WriteLine("Thank you for using our services!");
      Console.ReadLine();

    }

    private static void ListSeries()
    {
      Console.WriteLine("List series");

      var list = repository.List();

      if (list.Count == 0)
      {
        Console.WriteLine("The list are empty.");
        return;
      }

      foreach (var serie in list)
      {
        var excluded = serie.returnExcluded();

        Console.WriteLine("#ID {0}: - {1} - {2}", serie.returnId(), serie.returnTitle(), (excluded ? "* Deleted *" : ""));
      }
    }

    private static void InsertSerie()
    {
      Console.WriteLine("Insert a new serie");

      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genre), i));
      }
      Console.WriteLine("Enter the number of the genre: ");
      int serieGenre = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter the title of the serie: ");
      string serieTitle = Console.ReadLine();

      Console.WriteLine("Enter year of the production");
      int serieYear = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter a description: ");
      string serieDescription = Console.ReadLine();

      Serie newSerie = new Serie(Id: repository.NextId(), genre: (Genre)serieGenre, title: serieTitle, year: serieYear, description: serieDescription);

      repository.Insert(newSerie);
    }

    private static void UpdateSerie()
    {
      Console.WriteLine("Enter the serie Id: ");
      int serieIndice = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genre), i));
      }

      Console.WriteLine("Enter the number of the genre: ");
      int serieGenre = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter the title of the serie: ");
      string serieTitle = Console.ReadLine();

      Console.WriteLine("Enter year of the production");
      int serieYear = int.Parse(Console.ReadLine());

      Console.WriteLine("Enter a description: ");
      string serieDescription = Console.ReadLine();

      Serie updateSerie = new Serie(Id: serieIndice, genre: (Genre)serieGenre, title: serieTitle, year: serieYear, description: serieDescription);

      repository.Update(serieIndice, updateSerie);
    }
    private static void DeleteSerie()
    {
      Console.WriteLine("Enter the id of the serie you want to delete: ");
      int serieIndice = int.Parse(Console.ReadLine());

      repository.Exclude(serieIndice);
    }
    private static void ViewSerie()
    {
      Console.WriteLine("Enter the id of the serie: ");
      int serieIndice = int.Parse(Console.ReadLine());

      var serie = repository.ReturnById(serieIndice);

      Console.WriteLine(serie);
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("Welcome to DIO Series Project");
      Console.WriteLine("Please, select one option:");

      Console.WriteLine("1 - List series");
      Console.WriteLine("2 - Insert a new serie");
      Console.WriteLine("3 - Update serie");
      Console.WriteLine("4 - Delete serie");
      Console.WriteLine("5 - View serie");
      Console.WriteLine("C - Clear Screen");
      Console.WriteLine("X - Exit");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;


    }
  }
}
