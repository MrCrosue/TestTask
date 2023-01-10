using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.enums;

namespace TestTask.classes
{
    public class DataSource
    {
        public string Host { get; set; } = null!;
        public string DataBase { get; set; } = null!;
        public string User { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Provider { get; set; } = null!;

        private List<DataSet> dataSets = new List<DataSet>();
        private ConcurrentDictionary<Guid, StatusEnum> statuses = new ConcurrentDictionary<Guid, StatusEnum>();

        public DataSource(string host, string dataBase, string user, string password, string provider, List<DataSet> dataSets)
        {
            Host = host;
            DataBase = dataBase;
            User = user;
            Password = password;
            Provider = provider;
            this.dataSets = dataSets;
            foreach (DataSet ds in dataSets) { statuses[ds.Guid] = StatusEnum.NotStarted; }
        }

        private void SetStatus(Guid guid, StatusEnum st)
        {
            statuses[guid] = st;
        }
        public void BroadCastAll()
        {
            Random random = new Random();
            foreach(DataSet dataSet in dataSets)
            {
                Thread thread = new Thread(() => dataSet.BroadCast(random.Next(1000,2000)));
                thread.Start();
                dataSet.StatusEvent += SetStatus;
            }
        }
    
        public ConcurrentDictionary<Guid, StatusEnum> GetAllStatus() { return statuses; }
    }
}
