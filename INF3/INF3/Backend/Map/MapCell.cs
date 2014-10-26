using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend.Map
{
    class MapCell
    {
        private int x;
        private int y;
        private List<INF3.enums.Property> property;

        public MapCell(int x, int y, List<INF3.enums.Property> property)
        {
            this.x = x;
            this.y = y;
            this.property = new List<INF3.enums.Property>();
            
            this.property.AddRange(property);
        }
    }
}
