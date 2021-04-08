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

            Tag[] InitTags = new Tag[]
            {
                new Tag{Text="HD"},
                new Tag{Text="Cat"},
                new Tag{Text="Dog"},
                new Tag{Text="Public Domain"}
            };

            ICollection<Tag> GetRandomTags()
            {

                Random rng = new Random();
                int tagnum = rng.Next(0, 3);

                var newtags = new List<Tag>();
                var randtaglist = context.Tags.ToList().OrderBy(rand => rng.Next());

                for (int i = 0; i < tagnum; i++)
                {
                    Tag randtag = randtaglist.ToArray()[i];
                    newtags.Add(randtag);
                }
                return newtags;
            }

            context.Tags.AddRange(InitTags);
            context.SaveChanges();

            Picture[] InitPictures = new Picture[]
            {
                new Picture{ ID=0, Title="cats lol", ImageURL="https://www.thiscatdoesnotexist.com", Tags=GetRandomTags()}
            };

            context.Pictures.AddRange(InitPictures);

            context.SaveChanges();
        }
    }
}