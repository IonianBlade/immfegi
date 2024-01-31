namespace immfegi.External;

public static class UniqueFileName
{
    public static string GetUniqueFileName(string fileName, string extension, string folderPath)
    {
        var newFileName = fileName;
        var count = 1;


        while (File.Exists(Path.Combine(folderPath, newFileName + extension)))
        {
            newFileName = $"{fileName}_{count}";
            count++;
        }

        return $"{newFileName}{extension}";
    }
}