using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.enums;

namespace TestTask.delegates
{
    public delegate void StatusDelegate(Guid guid,StatusEnum status);
}
