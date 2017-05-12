using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.Models;

namespace WindowsFormsApp
{
    static class UnionConverter
    {
        public static DataTable StudentsListToTable(List<Student> students)
        {
            var table = new DataTable("Events");
            table.Columns.Add(new DataColumn("Id", Type.GetType("System.Int32")));
            table.Columns.Add(new DataColumn("Имя"));
            table.Columns.Add(new DataColumn("Фамилия"));
            table.Columns.Add(new DataColumn("Отчество"));
            table.Columns.Add(new DataColumn("Факультет"));
            table.Columns.Add(new DataColumn("Группа"));
            foreach (var student in students)
            {
                table.Rows.Add(new object[] { student.ID, student.FirstName, student.LastName, student.FatherName, student.Faculty, student.Group });
            }
            return table;
        }

        public static DataTable EvetsListToTable(List<UnionEvent> events)
        {
            var table = new DataTable("Events");
            var col = new DataColumn();
            table.Columns.Add(new DataColumn("Id", Type.GetType("System.Int32")));
            table.Columns.Add(new DataColumn("Название"));
            table.Columns.Add(new DataColumn("Место"));
            table.Columns.Add(new DataColumn("Дата", Type.GetType("System.DateTime")));
            foreach (var unionEvent in events)
            {
                table.Rows.Add(new object[] { unionEvent.Id, unionEvent.Name, unionEvent.Place, unionEvent.Date });
            }
            return table;
        }
    }
}
