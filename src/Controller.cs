using System.Threading;
using Prometheus;
/// <summary>
/// Основной класс 
/// </summary>
class Controller
{
    private Dictionary<string, IConnectable> connections = new Dictionary<string, IConnectable>();
    // SerialConnection sender = new SerialConnection(); 
    // SerialConnection reciever = new SerialConnection(); 

    /*  15.10.22 00:19 RA.Permyakov
        За все, что связанно с прометеем отвечает PrometheusConnection
    */
    // private static readonly Gauge gauge = Metrics.CreateGauge("sixty_nine","Noice");  За все, что связанно с прометеем отвечает PrometheusConnection
    public void SendToProm(string message)
    {
        // message = message.Substring(7); пока просто инкрементируем счетчик
        PrometheusConnection.gauge.Inc();
    }
    public bool CreateConnection(string com_port)
    {
        /*  15.10.22 00:14 RA.Permyakov
            Отлов исключений здесь не нужен. Смотри внимательнее код. У нас в
            функции sender.Connect(...); уже ловится исключение. Здесь его уже никогда не будет
        */

        // try
        // {
        //     sender.Connect("COM14");
        //     reciever.Connect("COM88");            
        // }
        // catch
        // {
        //     Console.WriteLine("Cannot create connection");
        // }

        SerialConnection sc = new SerialConnection();        // создали
        if (sc.Connect((string) com_port))               // если подключение успешно
        {
            sc.onRead += SendToProm;                     // подписали обработчик
            connections.Add(com_port, sc);               // положили в словарь
            return true;
        }
        return false;
    }

    public IConnectable GetConnection(string name_connection)
    {
        return connections[name_connection];
    }

    public void Start()
    {
        if (!CreateConnection("COM14")) return; 
        
        PrometheusConnection.Start();

        while(true)
        {
            // sender.SendMessage("69");        по шишью - отправка сообщения из hterm должна приводить к появлению метрики
            // reciever.onRead += SendToProm;   один раз только это должно происходить
            IConnectable tmp = GetConnection("COM14");   
            tmp.ReadData();  
        }
    }
}