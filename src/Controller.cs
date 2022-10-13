
/// <summary>
/// Основной класс 
/// </summary>
class Controller
{
    public void SendToProm(string message)
    {
        return;
    }
    private Dictionary<string, IConnectable> connections = new Dictionary<string, IConnectable>();
    SerialConnection serial_conn = new SerialConnection();
    public void CreateConnection()
    {
        serial_conn.Connect("COM14");
        serial_conn.SendMessage("huyi");
        //throw new NotImplementedException();
    }

    public void GetConnection()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        //serial_conn.onRead += SendToProm;
        //throw new NotImplementedException();
        CreateConnection();
        //PrometheusConnection.Start();
    }
}