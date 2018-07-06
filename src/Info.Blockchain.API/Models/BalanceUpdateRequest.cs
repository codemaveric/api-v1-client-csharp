using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Info.Blockchain.API.Models
{
    public class BalanceUpdateRequest
    {
       
        [JsonProperty("key")]
        public string key { get; set; }       
        [JsonProperty("addr")]
        public string Address { get; set; }        
        [JsonProperty("callback")]
        public string Callback { get; set; }        
        [JsonProperty("onNotification")]
        public string Notification { get; set; }        
        [JsonProperty("op")]
        public string OperationType { get; set; }        
        [JsonProperty("confs")]
        public int Confirmations { get; set; }
    }

}
