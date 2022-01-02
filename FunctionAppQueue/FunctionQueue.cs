using System;
using Azure.Storage.Queues;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionAppQueue
{
    public class FunctionQueue
    {
        [FunctionName("FunctionQueue")]
        public void Run([QueueTrigger("input-queue", Connection = "AzureWebJobsStorage")]
                    string myQueueItem, 
                    [Table("teste")] CloudTable cloudTableTeste,
                    ILogger log)
        {

            log.LogInformation($" Queue trigger function iniciada para: {myQueueItem}");

            var data = JsonConvert.DeserializeObject<Teste>(myQueueItem);
            data.PartitionKey = "teste";
            data.RowKey = Guid.NewGuid().ToString();

            log.LogInformation($" Inserindo da CloudTable Teste ");

            var tableOperation = TableOperation.Insert(data);
            var result = cloudTableTeste.Execute(tableOperation);
            

            log.LogInformation($" {myQueueItem} Gravado em tabela.");

        }
    }

    public class Teste : TableEntity
    {
        public Teste()
        {   
        }

        public string msg { get; set; }
    }
}
