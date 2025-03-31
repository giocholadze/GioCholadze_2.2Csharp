using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Task_6.Services
{
    public class ExcellService<T>
    {
        public MemoryStream Generate(List<T> values)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add(typeof(T).Name);
                worksheet = AddHead(worksheet);
                worksheet = AddBody(worksheet, values);
                MemoryStream memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }

        public IXLWorksheet AddHead(IXLWorksheet worksheet)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 1; i <= properties.Length; i++)
            {
                var attributes = properties[i].GetCustomAttributes(typeof(DisplayNameAttribute), false);
                worksheet.Cell(1, i).Value = attributes.Length > 0 ? ((DisplayNameAttribute)attributes[0]).DisplayName : properties[i].Name;
            }
            return worksheet;
        }

        public IXLWorksheet AddBody(IXLWorksheet worksheet, List<T> info)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < info.Count; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {
                    var propertyInfo = properties[j].GetValue(info[i], null);
                    worksheet.Cell(2 + i, 1 + j).Value = propertyInfo.ToString();
                }
            }
            return worksheet;
        }
    }
}
