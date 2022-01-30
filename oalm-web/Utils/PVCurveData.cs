using oalm_web.Pages.Constants;

namespace oalm_web.Utils;

public class PVCurveData
{
    public PVCurveColumn _column { get; set; }
    public string _row { get; set; }
    public string _value { get; set; }

    public PVCurveData(PVCurveColumn column, string row, string value)
    {
        _column = column;
        _row = row;
        _value = value;
    }
}