using RSSClient.Interfaces.WebData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.WebData
{
    public class DataManager : IDataManager
    {
        /// <summary>
        /// Downloads the RSS data from the selected URLS
        /// </summary>
        /// <param name="urls">RSS URLs</param>
        /// <returns>List of string</returns>
        public string[] DownloadRSSData(string[] urls)
        {
            var taskList = new List<Task<string>>();
            string[] result = new string[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                using (WebClient client = new WebClient())
                {

                    try
                    {
                        var tasks = client.DownloadStringTaskAsync(urls[i]);
                        taskList.Add(tasks);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            try
            {
                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
            }

            return taskList
                .Where(x => x.Status == TaskStatus.RanToCompletion)
                .Select(x => x.Result)
                .ToArray();
        }
    }
}
