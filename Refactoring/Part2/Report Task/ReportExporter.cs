using System;
using System.Collections.Generic;
using System.Text;

namespace Report_Task;

    public abstract  class ReportExporter
    {
        public void Export(string path)
        {
            var rows = Load();
            if (!Validate(rows))
                throw new InvalidOperationException("Invalid data");
            var content = Format(rows);
            Save(path, content);
        }
        private  List<string[]> Load()
        {
            return new List<string[]>
            {
                new string[] { "Id", "Name" },
                new string[] { "1", "Keyboard" },
                new string[] { "2", "Mouse" }
            };
        }
        private bool Validate(List<string[]> rows) =>
        rows.Count > 1 && rows[0].Length > 0;

        protected abstract string Format(List<string[]> rows);
        private void Save(string path, string content) =>
        File.WriteAllText(path, content);

    }


    

