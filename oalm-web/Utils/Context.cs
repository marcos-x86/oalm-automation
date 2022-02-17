using System.Collections.Generic;

namespace oalm_web.Utils;

public class Context
{
    private List<PVCurveData> _pvCurveData;
    private string _pvCurveId;

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

    public string GetPVCurveId()
    {
        return _pvCurveId;
    }

    public void SetPVCurveId(string id)
    {
        _pvCurveId = id;
    }
}