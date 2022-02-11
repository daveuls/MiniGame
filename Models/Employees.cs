using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Name_Game.Models
{
    public class Employees
    {
        public string FirstName { get; set; }
        public Headshot Headshot { get; set; }
        public string Id { get; set; }
        public string JobTitle { get; set; }
        public string LastName { get; set; }
        public string Slug { get; set; }
        //public SocialLinks[] SocialLinks { get; set; }
        public string Type { get; set; }
    }

    public class Headshot
    {
        public string Alt { get; set; }
        public int Height { get; set; }
        public string Id { get; set; }
        public string MimeType { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class SocialLinks
    {
        public string CallToAction { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}