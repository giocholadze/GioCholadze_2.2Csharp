using ClosedXML.Excel;
using System.ComponentModel;
using System.Reflection;

namespace ExcelImportExport.Controllers
{
    public class WorkWithExcel<T>
    {
        public IXLWorksheet AddHeader(XLWorkbook wb, List<T> objs)
        {
            T obj = objs.FirstOrDefault();
            var ws = wb.Worksheets.Add(obj.GetType().Name).SetTabColor(XLColor.Green);
            PropertyInfo[] properties = obj.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var displayNameAttribute = properties[i].GetCustomAttributes(typeof(DisplayNameAttribute), false);
                string displayName = (displayNameAttribute.Length != 0)
                    ? ((DisplayNameAttribute)displayNameAttribute[0]).DisplayName
                    : properties[i].Name;

                ws.Cell(1, i + 1).Value = displayName;
                ws.Cell(1, i + 1).Style.Font.Bold = true;
            }

            return ws;
        }

        public IXLWorksheet AddBody(IXLWorksheet ws, List<T> objs)
        {
            for (int i = 0; i < objs.Count; i++)
            {
                PropertyInfo[] props = objs[i].GetType().GetProperties();
                for (int j = 0; j < props.Length; j++)
                {
                    var propValue = props[j].GetValue(objs[i], null);
                    ws.Cell(2 + i, j + 1).Value = propValue?.ToString() ?? string.Empty;
                }
            }

            return ws;
        }

        public XLWorkbook Generate(List<T> objs)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = AddHeader(wb, objs);
            ws = AddBody(ws, objs);
            return wb;
        }
    }
}
