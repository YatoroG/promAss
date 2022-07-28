using System;
using System.IO.Ports;

public class SerialConnection : IConnectable
{
    private SerialPort port;
    string name;
    public void Connect()
    {
        try
        {
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
            port.PortName = name;
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
        object obj; 

        try
        {
            port.PortName = name;
            obj = port.ReadLine();
            return obj;
        }
        catch
        {
            return null;
        }
    }

    public void SendMessage(object message)
    {
        if (message is null)
        {
            Console.WriteLine("Message is empty");
        }
        else
        {
            port.WriteLine(String.Format("{0}: {1}", name, message));
        }
    }
}