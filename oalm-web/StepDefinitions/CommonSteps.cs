using System.IO;
using NUnit.Framework;
using oalm_web.Config;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public class CommonSteps
{
    private string _downloadFolder = Environment.Config.GetProjectFolder() + Environment.Config.DownloadsFolder;
    private Context _context;

    public CommonSteps(Context context)
    {
        _context = context;
    }
    
    [Then("verifies that the file '(.*)' is downloaded")]
    public void VerifyDownloadedFile(string filename)
    {
        Assert.True(FileUtils.CheckIfFileExist(_downloadFolder + filename));
    }
}