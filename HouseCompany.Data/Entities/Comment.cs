using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseCompany.Data.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public byte[] UserPhoto { get; set; }
        public string ImageMimeType { get; set; }
    }
}