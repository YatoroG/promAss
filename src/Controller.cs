using System.Threading;
using Prometheus;
/// <summary>
/// Основной класс 
/// </summary>
class Controller
{
    private Dictionary<string, IConnectable> connections = new Dictionary<string, IConnectable>();
    SerialConnection sender = new SerialConnection();
    SerialConnection reciever = new SerialConnection();
    private static readonly Gauge gauge = Metrics.CreateGauge("sixty_nine","Noice");
    public void SendToProm(string message)
    {
        message = message.Substring(7);
        gauge.Inc(Convert.ToInt32(message));
    }
    public void CreateConnection()
    {
        try
        {
            sender.Connect("COM14");
            reciever.Connect("COM88");            
        }
        catch
        {
            Console.WriteLine("Cannot create connection");
        }
    }

    public void GetConnection()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        CreateConnection();
        PrometheusConnection.Start();

        while(true)
        {
            sender.SendMessage("69");
            reciever.onRead += SendToProm;
            reciever.ReadData();
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

    }
}