using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.ViewModel
{
    public class ProductUpdateViewModel
    {
        public string Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Stock { get; set; }
        public float Price { get; set; }


    }
}
