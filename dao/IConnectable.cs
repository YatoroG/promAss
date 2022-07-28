/// <summary>
/// Интерфейс наследуется объектами, которые будут 
/// устанавливать соединение и считывать данные с датчиков
/// (неважно каких ваще) 
/// </summary>
interface IConnectable
{
    /// <summary>
    /// Осуществляет подключение объекта к устройству
    /// </summary>
    /// <param name="SerialPortName"></param>
    void Connect(); 

    /// <summary>
    /// Осуществляет отключение 
    /// </summary>
    /// <param name="SerialPortName"></param>
    void Disconnect(); 

    /// <summary>
    /// Прием данных
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    string ReadData();

    /// <summary>
    /// Отправка данных
    /// </summary>
    /// <param name="message"></param>
    void SendMessage(object message);
    
}