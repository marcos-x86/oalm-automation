using oalm_web.Pages.Tables;

namespace oalm_web.Pages;

public class MarketStructurePage : HomeBasePage
{
    private PVCurveTable _pvCurveTable;

    public MarketStructurePage()
    {
        _pvCurveTable = new PVCurveTable();
    }

    public PVCurveTable GetPvCurveTable()
    {
        return _pvCurveTable;
    }
}