namespace immfegi.External;

public class UniqueFileName
{
    public string GetUniqueFileName(string fileName, string extension, string folderPath)
    {
        string newFileName = fileName;
        int count = 1;


        while (File.Exists(Path.Combine(folderPath, newFileName + extension)))
        {
            newFileName = $"{fileName}_{count}";
            count++;
        }

        return $"{newFileName}{extension}";
    }
}