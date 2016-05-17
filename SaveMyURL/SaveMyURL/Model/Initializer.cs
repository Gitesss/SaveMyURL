using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace SaveMyURL.Model
{
    public static class Initializer 
    {

        public static void Seed(ApplicationContext context)
        {

            var tag = new Tag()
            {
                Name = "geek",

            };
            var tag2 = new Tag()
            {
                Name = "Szkoła",

            };
            context.Tags.Add(tag);


            var listOfTags = new List<Tag>();
            listOfTags.Add(tag);
            listOfTags.Add(tag2);
            var link = new Link()
            {
                DateTime = DateTime.Now,
                Description = "O jak ja lubie wszystko i wszystkich",
                URL = "https://www.facebook.com/",
                Image = null,
                Tags = listOfTags,
                RatingStars = 5,
                
            };
            var link2 = new Link()
            {
                DateTime = DateTime.Now,
                URL = "https://www.o2.pl/",
                Description = "cos nie gra",
                Image = null,
                Tags = listOfTags,
                RatingStars = 5,

            };
            context.Links.Add(link);

            var listOfLinks = new List<Link>();
            listOfLinks.Add(link2);
            listOfLinks.Add(link);
            var group = new Group()
            {
                Name = "komputerek",
                Links = listOfLinks,
                Image = null,
            };
            context.Groups.Add(group);




            context.SaveChanges();
        }
    }
}
