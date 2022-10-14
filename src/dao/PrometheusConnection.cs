using System;
using System.Threading;
using Prometheus;

public static class PrometheusConnection
{
    public static MetricServer server = new MetricServer(hostname: "localhost", port: 1234);
    //private static readonly Counter TickTock = Metrics.CreateCounter("sampleapp_ticks_total", "Just keeps on ticking");

    public static void Start()
    {
        server.Start();

        // while (true)
        // {
        //     TickTock.Inc();
        //     Thread.Sleep(TimeSpan.FromSeconds(1));
        // }
    }
}