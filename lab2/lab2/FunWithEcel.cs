using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CountTimeAndExport2EXCEL
{
    class FunWithExcel
    {
        public static void Save(IEnumerable<Element> numbers, string fileName)
        {
            Excel.Application app = null;
            Excel.Workbook book = null;
            bool exist = false;
            try
            {
                try
                {
                    app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                    exist = true;
                }
                catch
                {
                    app = new Excel.Application();
                }
                app.SheetsInNewWorkbook = 1;
                book = app.Workbooks.Add();
                Excel.Worksheet sheet = book.Worksheets.get_Item(1) as Excel.Worksheet;
                for (int i = 2; i < numbers.Count()+2; ++i)
                {
                    sheet.Cells[2, i] = numbers.ElementAt(i-2).Count.ToString();
                    sheet.Cells[3, i] = numbers.ElementAt(i-2).Time.ToString();
                }
                book.Saved = true;
                book.SaveAs(fileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (book != null)
                    book.Close();
                if (app != null && !exist)
                {
                    app.Quit();
                    System.Diagnostics.Process[] ps2 = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                    foreach (var p2 in ps2)
                    {
                        p2.Kill();
                    }
                }
            }
        }
    }
}
