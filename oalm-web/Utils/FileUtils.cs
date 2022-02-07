using System;
using System.IO;
using System.Threading;

namespace oalm_web.Utils;

public sealed class FileUtils
{
    private const int WaitInterval = 1000;
    private const string GitKeepFile = ".gitkeep";

    public static Boolean CheckIfFileExist(string filename)
    {
        int attempts = 0;
        bool result;
        do
        {
            Thread.Sleep(WaitInterval);
            result = File.Exists(filename);
        } while (result == false && attempts++ < 3);

        return result;
    }

    public static void DeleteFilesInFolder(string folder)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(folder);
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in fileInfos)
        {
            if (!fileInfo.Name.Equals(GitKeepFile))
            {
                fileInfo.Delete();
            }
        }
    }
}