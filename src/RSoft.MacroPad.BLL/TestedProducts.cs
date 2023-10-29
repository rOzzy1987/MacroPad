using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSoft.MacroPad.BLL
{
    public static class TestedProducts
    {
        /// <summary>
        /// indicates which products are tested and working with this software
        /// </summary>
        private static (ushort VendorId, ushort ProductId)[] _values { get; } = new[] 
        {
            (4489,34960) 
        }.Select(x => ((ushort)x.Item1,(ushort)x.Item2)).ToArray();

        /// <summary>
        /// Checks if product is already tested and working with this library
        /// </summary>
        /// <param name="VendorId"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public static bool IsTested(ushort VendorId, ushort ProductId) 
            => _values.Contains((VendorId, ProductId));
    }
}
