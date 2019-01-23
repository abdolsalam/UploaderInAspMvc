using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploader.Models
{
    /// <summary>
    /// To keep the result of the upload
    /// </summary>
    public class UploadResult
    {
        public bool Error { get; set; }
        
        // Error message occurred during file upload
        public string ErrorMessage { get; set; }

        public string FileAddress { get; set; }
    }
}