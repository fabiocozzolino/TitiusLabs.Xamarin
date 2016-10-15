using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TitiusLabs.Core
{
    public class DelegateEqualityComparer<T>:IEqualityComparer<T>
    {
        Func<T, T, bool> _func;
        
		public DelegateEqualityComparer(Func<T,T,bool> func)
        {
            this._func = func;
        }

        public bool Equals(T x, T y)
        {
            return _func(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
