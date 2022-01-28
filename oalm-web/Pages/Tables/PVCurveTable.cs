using System;
using oalm_web.Pages.Constants;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Tables;

public class PVCurveTable
{
    private const string CellBaseLocator =
        "//div[@id='row{0}gridTerm']//div[@columnindex='{1}' and @role='gridcell']//div";

    public void SetCellData(PVCurveColumn column, string row, string data)
    {
        int numericRow = Int32.Parse(row);
        string cellXpathLocator = String.Format(CellBaseLocator, --numericRow, (int) column);
        By cellLocator = By.XPath(cellXpathLocator);
        WebDriverActions.DoubleClick(cellLocator);
        WebDriverActions.SetText(cellLocator, data);
        WebDriverActions.PressEnter(cellLocator);
    }

    public Boolean IsCellContainingData(PVCurveColumn column, string row, string data)
    {
        int numericRow = Int32.Parse(row);
        string cellXpathLocator = String.Format(CellBaseLocator, --numericRow, (int) column);
        By cellLocator = By.XPath(cellXpathLocator);
        string content = WebDriverActions.GetText(cellLocator);
        return content.Equals(data);
    }
}