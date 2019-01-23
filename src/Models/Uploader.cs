using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FileUploader.Models
{
    /// <summary>
    /// Uploader help you to upload file easily
    /// </summary>
    public class Uploader
    {
        /// <summary>
        /// Whitelist extensions to allow file upload, you can added your extention
        /// </summary>
        public static string[] _whiteListExtentions = { ".jpeg", ".jpg", ".png", ".txt", ".zip", ".pdf" };

        /// <summary>
        /// Save the file to destination
        /// </summary>
        /// <param name="file">file that you want to save it</param>
        /// <param name="destination">destination for save file</param>
        /// <returns>Result of file upload</returns>
        public static UploadResult Upload(HttpPostedFileBase file, string destination)
        {
            try
            {
                var result = CheckFile(file);
                if (result.Error)
                {
                    return result;
                }
                else
                {
                    var savedFileName = SaveFile(file, destination);
                    return UploadResultFactory.MakeSuccess(savedFileName);
                }
            }
            catch (Exception ex)
            {
                return UploadResultFactory.MakeError(ex.Message);
            }
        }

        /// <summary>
        /// Checking that the file is not null, its size is not zero and its extension is correct
        /// </summary>
        /// <param name="file">Sended file for check</param>
        /// <returns>Result of checing file</returns>
        private static UploadResult CheckFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return UploadResultFactory.MakeError("The file is empty.");
            }

            if (file.ContentLength <= 0)
            {
                return UploadResultFactory.MakeError("The file size is zero.");
            }

            if (!IsWhiteExtention(TakeFileExtention(file)))
            {
                return UploadResultFactory.MakeError("File format is not acceptable.");
            }

            return UploadResultFactory.MakeSuccess();
        }

        /// <summary>
        /// Check the file extention in white extention list
        /// </summary>
        /// <param name="extention">The file extention</param>
        /// <returns>true if the extention in white extention list</returns>
        private static bool IsWhiteExtention(string extention)
        {
            return _whiteListExtentions.Contains(extention);
        }

        /// <summary>
        /// Take the file extention
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the file extention</returns>
        private static string TakeFileExtention(HttpPostedFileBase file)
        {
            return file.FileName.Substring(file.FileName.LastIndexOf('.'));
        }

        /// <summary>
        /// Save file in hard drive
        /// </summary>
        /// <param name="file">The file that you want to save</param>
        /// <param name="destination">Destination file save file</param>
        /// <returns>The file name that has been saved</returns>
        private static string SaveFile(HttpPostedFileBase file, string destination)
        {
            // Today's date to put at the beginning of the file name
            string TodayDate = DateTime.Now.Ticks.ToString(); 

            string fileName = TodayDate + "_" + Path.GetFileName(file.FileName);

            string savePath = Path.Combine(HostingEnvironment.MapPath(destination), fileName);

            file.SaveAs(savePath);

            return fileName; // return the file name for insert into database
        }
    }
}