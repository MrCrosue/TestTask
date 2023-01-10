using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.classes
{
    public class DataSetRow
    {
        public int Id { get; set; }
        public string ColumnName { get; set; } = null!; 
        public string ColumnType { get; set; } = null!;

        public DataSetRow(int id, string columnName, string columnType)
        {
            Id = id;
            ColumnName = columnName;
            ColumnType = columnType;
        }
    }
}
