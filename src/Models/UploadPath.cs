using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploader.Models
{
    public class UploadPath
    {
        // The root folder for save any file
        public static string UPLOAD_FOLDER = "~/Uploads";

        // folder for save image file
        public static string IMAGE_FOLDER = UPLOAD_FOLDER + "/Images/";

        // folder for save other file
        public static string FILE_FOLDER =  UPLOAD_FOLDER + "/Files/"; 
    }
}