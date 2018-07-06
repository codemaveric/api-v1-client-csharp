using Info.Blockchain.API.Client;
using Info.Blockchain.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Info.Blockchain.API.Receive
{
    public class BalanceUpdate
    {
        private readonly IHttpClient _httpClient;

        public BalanceUpdate(IHttpClient httpClient = null)
        {
            _httpClient = (httpClient == null)
                ? new BlockchainHttpClient("https://api.blockchain.info/v2")
                : httpClient;
        }

        /// <summary>
        /// Subscribe to balance update notification whenever a transaction occur on the address
        /// </summary>
        /// <param name="key">Your blockchain.info receive payments v2 api key</param>
        /// <param name="address">The address you will like to monitor</param>
        /// <param name="callback">The callback URL to be notified when payment is made</param>
        /// <param name="notification">The request notification behaviour ('KEEP' | 'DELETE).</param>
        /// <param name="operationType">The operation type you would like to receive notifications for ('SPEND' | 'RECEIVE' | 'ALL').</param>
        /// <param name="confirmations">The number of confirmations the transaction needs to have before a notification is sent.</param>
        /// <returns></returns>
        public async Task<BalanceUpdateResponse> Subscribe(string key, string address, string callback, string notification = "KEEP", string operationType = "ALL", int confirmations = 3)
        {
            try
            {
                BalanceUpdateRequest request = new BalanceUpdateRequest
                {
                    key = key,
                    Address = address,
                    Callback = callback,
                    Confirmations = confirmations,
                    Notification = notification,
                    OperationType = operationType
                };
                return await _httpClient.PostAsync<BalanceUpdateRequest, BalanceUpdateResponse>("balance_update", request);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("API Key is not valid"))
                {
                    throw new ArgumentException(nameof(key), "the api key provided is invalid");
                }
                throw ex;
            }
        }

    }
}
