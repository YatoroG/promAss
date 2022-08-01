
/// <summary>
/// Основной класс 
/// </summary>
class Controller
{
    private Dictionary<string, IConnectable> connections = new Dictionary<string, IConnectable>();
    //SerialConnection serial_conn = new SerialConnection();
    public void CreateConnection()
    {
        throw new NotImplementedException();
    }

    public void GetConnection()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        //serial_conn.onRead += а что делать?
        throw new NotImplementedException();
    }
}