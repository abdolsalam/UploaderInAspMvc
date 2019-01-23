using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploader.Models
{
    /// <summary>
    /// Factory of upload result that help to initialize upload result
    /// </summary>
    public class UploadResultFactory
    {
        /// <summary>
        /// Initialize UploadResult for error
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Upload result that error is true with message</returns>
        public static UploadResult MakeError(string message)
        {
            return new UploadResult()
            {
                Error = true,
                ErrorMessage = message
            };
        }

        /// <summary>
        /// Initialize UploadResult for success
        /// </summary>
        /// <returns>Uplaod result that error is false</returns>
        public static UploadResult MakeSuccess()
        {
            return new UploadResult()
            {
                Error = false,
            };
        }

        /// <summary>
        /// Initialize UploadResult for success that has file address
        /// </summary>
        /// <param name="fileAddress"></param>
        /// <returns>Upload result that error false with file address</returns>
        public static UploadResult MakeSuccess(string fileAddress)
        {
            return new UploadResult()
            {
                Error = false,
                FileAddress = fileAddress
            };
        }
    }
}