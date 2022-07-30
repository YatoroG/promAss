using System;
using System.IO.Ports;

public class SerialConnection : IConnectable
{
    private SerialPort port;
    public string name {get;}

    public void Connect(string com_port)
    {       
        try
        {   
            name = com_port;
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
        object message; 

        try
        {
            message = port.ReadLine();
            return (String)message;
        }
        catch
        {
            return (String)message;
        }
    }

    public void SendMessage(object message)
    {
        if (string.IsNullOrEmpty(message))
        {
            Console.WriteLine("Message is empty");
            return null;
        }

        port.WriteLine(String.Format("{0}: {1}", name, message));
    }
}