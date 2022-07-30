using System;
using System.IO.Ports;

public class SerialConnection : IConnectable
{
    private SerialPort port;
    public string name { get; private set;} = "";

    public void Connect(object com_port)
    {
        try
        {
            name = (string) com_port;
            port.PortName = name;
            port.Open();
            Console.WriteLine("Connection is opened");
        }
        catch
        {
            Console.WriteLine("An error occurred");
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
            return (String)message;
        }
        catch
        {
            return null;
        }
    }

    public void SendMessage(object message)
    {
        if (string.IsNullOrEmpty((string) message))
        {
            Console.WriteLine("Message is empty");
            return;
        }

        port.WriteLine(String.Format("{0}: {1}", name, message));
    }
}