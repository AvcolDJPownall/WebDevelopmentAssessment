using WebDevelopmentAssessment.Data;
using WebDevelopmentAssessment.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebDevelopmentAssessment.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebContentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tags.Any()) return; // Only seed db once

            string[] InitTags = new string[]
            {
                "HD",
                "Cat",
                "Dog",
                "Public Domain"
            };

            ICollection<Tag> GetRandomTags()
            {

                Random rng = new Random();
                int tagnum = rng.Next(0, 3);

                var newtags = new List<Tag>();
                var randtaglist = InitTags.OrderBy(rand => rng.Next());

                for (int i = 0; i < tagnum; i++)
                {
                    string randtag = randtaglist.ToArray()[i];
                    newtags.Add(new Tag { Text = randtag });
                }
                return newtags;
            }

            Picture[] InitPictures = new Picture[]
            {
                new Picture{ ID=0, Title="cats lol", ImageURL="https://www.thiscatdoesnotexist.com", Tags=GetRandomTags()}
            };

            foreach (var str in InitTags)
            {
                Tag tag = new Tag {Text = str};
                context.Tags.Add(tag);
            }
            context.Pictures.AddRange(InitPictures);

            context.SaveChanges();
        }
    }
}