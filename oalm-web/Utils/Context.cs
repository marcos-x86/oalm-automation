using System.Collections.Generic;

namespace oalm_web.Utils;

public class Context
{
    private List<PVCurveData> _pvCurveData;

    public Context()
    {
        _pvCurveData = new List<PVCurveData>();
    }

    public void StorePVCurveData(PVCurveData data)
    {
        _pvCurveData.Add(data);
    }

    public List<PVCurveData> GetPVCurveData()
    {
        return _pvCurveData;
    }
}