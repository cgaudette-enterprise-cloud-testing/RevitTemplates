﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Nice3point.Revit.AddIn.View;
using Nice3point.Revit.AddIn.ViewModel;

namespace Nice3point.Revit.AddIn.Commands
{
    [Transaction(TransactionMode.ReadOnly)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiDocument = commandData.Application.ActiveUIDocument;
            var document = uiDocument.Document;
#if (CommandStyle)
            /*caret*/
#else

#endif
            var viewModel = new SimpleViewModel();
            var view = new SimpleView(viewModel);
            view.ShowDialog();

            return Result.Succeeded;
        }
    }
}