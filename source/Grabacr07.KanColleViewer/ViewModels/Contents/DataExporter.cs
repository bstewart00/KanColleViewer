using System;
using System.Collections.Generic;
using System.IO;
using Grabacr07.KanColleWrapper;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
    public class DataExporter
    {
        private string DumpFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KanColleViewer!");
        private string DumpPath => Path.Combine(this.DumpFolder, $"ExportedShips-{DateTime.Now.ToString("yyyy-M-d")}.json");

        public void Export(OrganizationModel organizationModel)
        {
            File.WriteAllText(this.DumpPath, organizationModel.ToJson());
        }
    }
}
