using Microsoft.Extensions.Options;
using Nest;
using System;

public class ElasticClientProvider
{
    public ElasticClientProvider()
    {
        // Create the connection settings
        ConnectionSettings connectionSettings =
            // Get the cluster URL from appsettings.json and pass it in
            new ConnectionSettings(new System.Uri(Environment.GetEnvironmentVariable("ELASTICCONNECTIONSTRING")));

        // This is going to enable us to see the raw queries sent to elastic when debugging (really useful)
        connectionSettings.EnableDebugMode();

        // Get the index name from appsettings.json and pass it in
        connectionSettings.DefaultIndex("book");
        
        // Create the actual client
        this.Client = new ElasticClient(connectionSettings);
    }

    public ElasticClient Client { get; }
}