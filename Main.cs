using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

namespace RevitAPITrainig441
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            View activeView = doc.ActiveView;
            Level level = activeView.GenLevel;
            ElementId levelId = level.Id;

            Level level1 = LevelsUtils.GetLevel(commandData)[0];
            Level level2 = LevelsUtils.GetLevel(commandData)[1];

            double width = UnitUtils.ConvertToInternalUnits(10000, UnitTypeId.Millimeters);
            double depth = UnitUtils.ConvertToInternalUnits(5000, UnitTypeId.Millimeters);

            Transaction transaction = new Transaction(doc, "Создание модели");
            transaction.Start();

                List<Wall> walls = WallsUtils.CreateWalls(doc, width, depth, level1.Id, level2.Id);
            transaction.Commit();



            return Result.Succeeded;
        }
    }
}
