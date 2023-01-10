using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.delegates;

namespace TestTask.classes
{
    public class DataSet
    {
        public Guid Guid { get; set; }
        public List<DataSetRow> DataSetRows { get; set; } = new List<DataSetRow>();

        public event StatusDelegate StatusEvent = null!;

        public DataSet(List<DataSetRow> dataSetRows)
        {
            Guid = Guid.NewGuid();
            DataSetRows = dataSetRows;
        }

        public void BroadCast(int sleepTime)
        {
            try
            {
                StatusEvent(Guid, enums.StatusEnum.Processing);
                Thread.Sleep(sleepTime);
                StatusEvent(Guid,enums.StatusEnum.Sucses);
            }
            catch 
            {
                StatusEvent(Guid, enums.StatusEnum.Faild);
            }
        }
    }
}
