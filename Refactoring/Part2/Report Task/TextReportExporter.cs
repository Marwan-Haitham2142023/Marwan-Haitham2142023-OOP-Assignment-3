namespace Report_Task;

public class TextReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(" | ", r)));

    
}
