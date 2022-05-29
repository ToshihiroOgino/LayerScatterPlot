using System.Reflection.Metadata;
namespace bitmapGen
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Generating...");

      List<Data> list = Data_Loader("./data1.csv");
      Plot_Graph(list, "data1");

      list = Data_Loader("./data2.csv");
      Plot_Graph(list, "data2");

      Console.WriteLine("Done!");
    }

    static List<Data> Data_Loader(string path)
    {
      List<Data> list = new List<Data>();
      list = new List<Data>();
      Data data = new Data();
      using (var sr = new StreamReader(path))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          string[] arr = line.Split(',');
          data.x = float.Parse(arr[0]);
          data.y = float.Parse(arr[1]);
          data.label = int.Parse(arr[2]);
          list.Add(data);
        }
      }
      return list;
    }

    static void Plot_Graph(List<Data> list, string name)
    {
      Graph gp = new Graph();
      foreach (Data data in list)
        gp.plotData(data);
      gp.saveImg(name);
    }
  }
}
