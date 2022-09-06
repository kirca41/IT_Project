using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IT_Project.Models
{
    public class HttpPostedFileBaseCustom : HttpPostedFileBase
    {
        private readonly byte[] fileBytes;
        string contentType;
        string fileName;

        public HttpPostedFileBaseCustom(byte[] fileBytes, string contentType = null, string fileName = null)
        {
            this.fileBytes = fileBytes;
            this.contentType = contentType;
            this.fileName = fileName;
        }

        public override int ContentLength
        {
            get { return (int)fileBytes.Length; }
        }

        public override string ContentType
        {
            get { return contentType; }
        }

        public override string FileName
        {
            get { return fileName; }
        }

        public override Stream InputStream { get; }
    }

}