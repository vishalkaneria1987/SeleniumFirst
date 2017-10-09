using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumFirst.Utilities
{
    class ExcelUtilities
    {
        string sFilePath;
        string sSheetName;

        public ExcelUtilities(string sFilePath, string sSheetName)
        {
            this.sFilePath = sFilePath;
            this.sSheetName = sSheetName;
        }
        public Dictionary<string, Dictionary<string, string>> ReadExcelSheetData()             
        {
            Dictionary<string, Dictionary<string, string>> dictSheetData = new Dictionary<string, Dictionary<string, string>>();
            IList<string> lstColHeaderNames = new List<string>();

            /**driver
             * 
             * dictSheetData==>{"Row1":{"":"","":"","":""},"Row2":{"":"","":"","":""},.......}===>  ReadExcelSheetData("c://abc//def//file.xlsx", "sheetname");
             * for(i = 1 ; idictSheetData.size(); i++) { Idictionary<string, string> rowdata = dictSheetData["Row"+i.ToString()];}
             * rowdata==> {"colname1":"colval1","colname2":"colval2","colname3":"colval3"}
             *              
             */

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(this.sFilePath);       
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[this.sSheetName];
            Excel.Range xlRange = xlWorksheet.UsedRange;                           

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                Dictionary<string, string> dictRowData = null;

                for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                {
                    dictRowData = new Dictionary<string, string>();
                    //Excel.Range row = xlRange.Rows[rowIndex];

                   for (int colIndex = 1; colIndex <= colCount; colIndex++)
                    {
                        string data = xlRange.Cells[rowIndex,colIndex].Value2.ToString();
                        if (rowIndex == 1)
                        {
                            lstColHeaderNames.Add(data);                           
                            continue;
                        }
                        dictRowData.Add(lstColHeaderNames[colIndex-1], data);
                    }
                    if(rowIndex != 1)
                    {
                        dictSheetData.Add("Row" + (rowIndex-1).ToString(), dictRowData);                       
                       // Console.Write(xlRange.Cells[rowIndex].Value2.ToString() + "\t");        //added extra line as cw

                    }
                }
                return dictSheetData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }
    }
}
