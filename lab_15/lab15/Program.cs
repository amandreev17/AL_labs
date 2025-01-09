using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

string place = "/Users/olesaandreeva/Desktop/test";
var watcher = new FileSystemWatcher(place);
var observer = new FileChangeObserver();
watcher.AddObserver(observer);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

public interface Observer
{
    void Update(string filePath);
}


public class FileChangeObserver : Observer
{
    public void Update(string filePath)
    {
        Console.WriteLine($"Changed: {filePath}");
    }
}


public class FileSystemWatcher
{
    private string _directory;
    private List<Observer> _observers = new List<Observer>();
    private HashSet<string> _lastState;
    private Timer _timer;

    public FileSystemWatcher(string directory)
    {
        _directory = directory;
        _lastState = GetDirectoryState();
        _timer = new Timer(500);
        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();
    }

    private HashSet<string> GetDirectoryState()
    {
        var files = Directory.GetFiles(_directory);
        return new HashSet<string>(files);
    }

    public void AddObserver(Observer observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers(string filePath)
    {
        foreach (var observer in _observers)
        {
            observer.Update(filePath);
        }
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        var currentState = GetDirectoryState();
        var newFiles = currentState.Except(_lastState);
        var deletedFiles = _lastState.Except(currentState);

        foreach (var file in newFiles)
        {
            NotifyObservers(file);
        }

        foreach (var file in deletedFiles)
        {
            NotifyObservers(file);
        }

        _lastState = currentState;
    }
}
