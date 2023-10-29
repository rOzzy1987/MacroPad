using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSoft.MacroPad.Infrastructure
{
    internal static class Extensions
    {
        public static IEnumerable<Control> AsEnumerable(this Control.ControlCollection coll)
        {
            for(var i = 0; i < coll.Count; i++)
            {
                yield return coll[i];
            }
        }

        public static IEnumerable<T> As<T>(this Control.ControlCollection coll)
        {
            return coll.AsEnumerable().Where(x => x is T).Cast<T>();
        }
    }
}
