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

            int GetRandomTagID()
            {
                Random rng = new Random();
                int tagnum = rng.Next(0, 3);
                var randtaglist = context.Tags.ToList().OrderBy(rand => rng.Next());
                return randtaglist.First().TagID;
            }

            context.Tags.AddRange(InitTags);
            context.SaveChanges();

            Picture[] InitPictures = new Picture[]
            {
                new Picture{ PictureID=0, Title="cats lol", ImageURL="https://www.thiscatdoesnotexist.com", TagID=GetRandomTagID()}
            };

            context.Pictures.AddRange(InitPictures);

            context.SaveChanges();
        }
    }
}