using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBE
{
    public class ProxyBase
    {

        protected virtual void OnDestroy() { }
        public void Destroy()
        {
            OnDestroy();
        }
    }
}
