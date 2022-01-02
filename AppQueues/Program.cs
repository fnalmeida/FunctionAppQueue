// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using System.Text;

Console.WriteLine("Hello, Function Queue teste!");

// To do: Inserir string de conexão azure storage para testes 
string _connection = "";

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
    queueClient.SendMessage("{ msg: 'Fabricio 2' }");
}

Console.WriteLine("Mensagem enviada para a fila.");


