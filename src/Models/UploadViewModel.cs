using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploader.Models
{
    public class UploadViewModel
    {
        public HttpPostedFileBase File { get; set; }
    }
}