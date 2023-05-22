using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainig441
{
    public class WallsUtils
    {

        public static List <Wall> CreateWalls(Document doc, double width,double depth, ElementId levelId, ElementId level2Id)
        {

            List<Wall> walls = new List<Wall>();

            double dx = width / 2;
            double dy = depth / 2;

            List<XYZ> points = new List<XYZ>();
            points.Add(new XYZ(-dx, -dy, 0));
            points.Add(new XYZ(dx, -dy, 0));
            points.Add(new XYZ(dx, dy, 0));
            points.Add(new XYZ(-dx, dy, 0));
            points.Add(new XYZ(-dx, -dy, 0));

            for (int i = 0; i < 4; i++)
            {
               Line line= Line.CreateBound(points[i], points[i + 1]);
                Wall wall = Wall.Create(doc, line, levelId, false);
                wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).Set(level2Id);
                walls.Add(wall);
            }
           
            return walls;
        }

        
    }
}
  