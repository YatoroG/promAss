/// <summary>
/// Интерфейс наследуется объектами, которые будут 
/// устанавливать соединение и считывать данные с датчиков
/// (неважно каких ваще) 
/// </summary>
interface IConnectable
{
    // подключение
    void Connect(string SerialPortName); 

    // отключение
    void Disconnect(string SerialPortName); 

    // чтение
    string ReadData(object obj);

    // передача сообщения
    void SendMessage(string message);
    
}