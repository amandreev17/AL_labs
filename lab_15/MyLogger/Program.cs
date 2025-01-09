using Newtonsoft.Json;

using System.Text;


string textFilePath = "/Users/olesaandreeva/Desktop/test.txt";
ILoggerRepository textRepository = new TextFileLoggerRepository(textFilePath);
MyLogger textLogger = new MyLogger(textRepository);
textLogger.Log("Hello!");


string jsonFilePath = "/Users/olesaandreeva/Desktop/test.json";
ILoggerRepository jsonRepository = new JsonFileLoggerRepository(jsonFilePath);
MyLogger jsonLogger = new MyLogger(jsonRepository);
jsonLogger.Log("message op");
jsonLogger.Log("message op");



public interface ILoggerRepository
{
    void Log(string message);
}


public class TextFileLoggerRepository : ILoggerRepository
{
    private string filePath;

    public TextFileLoggerRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(filePath, message + Environment.NewLine, Encoding.UTF8);
    }
}


public class JsonFileLoggerRepository : ILoggerRepository
{
    private string filePath;
    private List<string> logEntries = new List<string>();

    public JsonFileLoggerRepository(string filePath)
    {
        this.filePath = filePath;

    }

    public void Log(string message)
    {
        logEntries.Add(message);
        string json = JsonConvert.SerializeObject(logEntries, Formatting.Indented);
        File.WriteAllText(filePath, json, Encoding.UTF8);


    }
}


public class MyLogger
{
    private ILoggerRepository _repository;

    public MyLogger(ILoggerRepository repository)
    {
        this._repository = repository;
    }

    public void Log(string message)
    {
        _repository.Log(message);
    }
}

