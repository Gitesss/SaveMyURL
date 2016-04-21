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
            context.Tags.Add(tag);

            var listOfTags = new List<Tag>();
            listOfTags.Add(tag);
            var link = new Link()
            {
                DateTime = DateTime.Now,
                Description = "O jak ja lubie wszystko i wszystkich",
                Image = null,
                Tags = listOfTags,
                RatingStars = 5,
                
            };
            context.Links.Add(link);

            var listOfLinks = new List<Link>();
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
