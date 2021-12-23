using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.SharedModel
{
    public class RoomGraphics
    {
        //[Key]
        //public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int XSpan { get; set; }
        public int YSpan { get; set; }
        public float RowPercent { get; set; }

    }
}
