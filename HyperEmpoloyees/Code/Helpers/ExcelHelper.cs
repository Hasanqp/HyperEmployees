﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace HyperEmpoloyees.Code.Helpers
{
    public static class ExcelHelper
    {
        public static void Export(DataTable dataTable, string sheetName)
        {
            // Define Save Dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Excel File(Xlsx)|*.xlsx";
            saveFileDialog.Title = "Export Excel File";

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    // Export
                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        xLWorkbook.AddWorksheet(dataTable, sheetName);
                        using (MemoryStream ma = new MemoryStream())
                        {
                            xLWorkbook.SaveAs(ma);
                            File.WriteAllBytes(saveFileDialog.FileName, ma.ToArray());
                        }
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
