namespace Asmaa.Pl.Helper
{
    public class FileHelper
    {
//          باي مجلد رح اخزن الداتا (انا عملت داخل الروت مجلد الايميج)          نوع الداتا تبعت الفايل               
        public static string UplodeFile(IFormFile file,string folderName)
        {
            string floderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files",folderName);
            /*                C: \Users\user\Desktop\asp\seesion1\Asmaa\Asma.pl\wwwroot\files\Images\
             *                C:\Users\user\Desktop\asp\seesion1\Asmaa\Asma.pl\wwwroot\files\Images\
            */
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath=Path.Combine(floderPath,fileName);
            var fileStream=new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        
        }
        public static void DeleteFile(string fileName,string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files",folderName,fileName);
            if (File.Exists(filePath)) { 
            File.Delete(filePath);
            }
        }
    }
}
