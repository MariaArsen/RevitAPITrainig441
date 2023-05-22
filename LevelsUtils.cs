using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainig441
{
    public class LevelsUtils
    {
        public static List<Level> GetLevel(ExternalCommandData commandData)
        {
            //var doc = commandData.Application.ActiveUIDocument.Document;
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
           

            List<Level> Levels = new FilteredElementCollector(doc)
                     .OfClass(typeof(Level))
                     .OfType<Level>()
                     .ToList();

            Level level1 = Levels
               .Where(x => x.Name.Equals("Уровень 1"))
               .FirstOrDefault();
           

            Level level2 = Levels
              .Where(x => x.Name.Equals("Уровень 2"))
              .FirstOrDefault();

            Levels = new List<Level>() { level1, level2};

            return Levels;
        }

    }
}
