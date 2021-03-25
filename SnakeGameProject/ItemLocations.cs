using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class ItemLocations
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public string ItemName { get; set; } //I think this can be done better through inheritence
        public Char ItemIcon { get; set; }
        public int PointValue { get; set; }

        public ItemLocations()
        {

        }
        public ItemLocations(int xAxis, int yAxis, string itemName, Char itemIcon)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            ItemName = itemName;
            ItemIcon = itemIcon;
        }
        public ItemLocations(int xAxis, int yAxis, string itemName, Char itemIcon,int pointValue)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            ItemName = itemName;
            ItemIcon = itemIcon;
            PointValue = pointValue;
        }
    }
}
