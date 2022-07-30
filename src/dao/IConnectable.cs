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
    void Connect(object name); 

    /// <summary>
    /// Осуществляет отключение 
    /// </summary>
    void Disconnect(); 

    /// <summary>
    /// Прием данных
    /// </summary>
    /// <returns>Возвращает прочитанную строку или массив байт. При ошибке возвращает null</returns>
    object ReadData();

    /// <summary>
    /// Отправка данных
    /// </summary>
    /// <param name="message">Массив байт или строка для отправки</param>
    void SendMessage(object message);
}