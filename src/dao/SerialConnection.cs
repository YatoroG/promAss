using System;
using System.IO.Ports;

public class SerialConnection : IConnectable
{
    private SerialPort port;
    public void Connect()
    {
        try
        {
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
            return message;
        }
        catch
        {
            return message;
        }
    }

    public void SendMessage(object message)
    {
        if (string.IsNullOrEmpty(message))
        {
            Console.WriteLine("Message is empty");
            return null;
        }
    }
}