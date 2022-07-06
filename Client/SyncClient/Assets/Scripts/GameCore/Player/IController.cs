using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public interface IController
    {
        void ApplyController(TickData data);
        void AppendOneTickData(TickData data);
    }
}
