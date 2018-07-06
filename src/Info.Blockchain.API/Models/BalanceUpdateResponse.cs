using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Info.Blockchain.API.Models
{
    public class BalanceUpdateResponse
    {
        /// <summary>
        /// The id in the response can be used to delete
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// The address you will like to monitor
        /// </summary>
        [JsonProperty("addr", Required = Required.Always)]
        public string Address { get; set; }
        /// <summary>
        /// The operation type you would like to receive notifications for ('SPEND' | 'RECEIVE' | 'ALL').
        /// </summary>
        [JsonProperty("op", Required = Required.Always)]
        public string OperationType { get; set; }
        /// <summary>
        /// The number of confirmations the transaction needs to have before a notification is sent.
        /// </summary>
        [JsonProperty("confs", Required = Required.Always)]
        public int Confirmations { get; set; }
        /// <summary>
        /// The callback URL to be notified when payment is made
        /// </summary>
        [JsonProperty("callback", Required = Required.Always)]
        public string Callback { get; set; }
        /// <summary>
        /// The request notification behaviour ('KEEP' | 'DELETE).
        /// </summary>
        [JsonProperty("onNotification", Required = Required.Always)]
        public string Notification { get; set; }
    }

}
