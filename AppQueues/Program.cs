// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using System.Text;

Console.WriteLine("Hello, World!");

string _connection = "DefaultEndpointsProtocol=https;AccountName=storage2fna;AccountKey=qCzXhvFqhbUxcBfCdmc0HME45ZhUz+gNujCa/a6gYmg/nAwJFJOa0NyrBXY1uS64UxK0+1mfylkk5zQova/x/g==;EndpointSuffix=core.windows.net";

// Instantiate a QueueClient which will be used to create and manipulate the queue

var options = new QueueClientOptions();
options.MessageEncoding = QueueMessageEncoding.Base64;

var queueClient = new QueueClient(_connection,
                                  "input-queue",
                                  options);


// Create the queue if it doesn't already exist
queueClient.CreateIfNotExists();

if (queueClient.Exists())
{
    // Send a message to the queue
    queueClient.SendMessage("{ msg: 'Fabricio' }");
}

Console.WriteLine("Mensagem enviada para a fila.");


