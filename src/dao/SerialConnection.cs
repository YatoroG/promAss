using System;
using System.IO.Ports;

public class SerialConnection : IConnectable
{
    private SerialPort port = new SerialPort();
    public string name { get; private set; } = "";
    public delegate void EventHandler(string message);
    public event EventHandler? onRead;
    public bool Connect(object com_port)
    {
        try
        {
            name = (string)com_port;
            port.PortName = name;
            port.Open();
            Console.WriteLine("Connection is opened");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public void Disconnect()
    {
        try
        {
            port.Close();
            Console.WriteLine("Connection is closed");
        }
        catch
        {
            Console.WriteLine("An error occurred");
        }
    }

    public object ReadData()
    {
        string message;

        try
        {
            message = port.ReadLine();
            onRead?.Invoke(message);
            return (String)message;
        }
        catch
        {
            return null;
        }
    }

    public void SendMessage(object message)
    {
        if (string.IsNullOrEmpty((string)message))
        {
            Console.WriteLine("Message is empty");
            return;
        }

        port.WriteLine(String.Format("{0}: {1}", name, message));
    }
}