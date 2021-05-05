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

            User[] InitUsers = new User[]
            {
                new User{UserName="Jim Cart", Email="jim@coolsite.com", ProfilePicture="https://thispersondoesnotexist.com/image", PasswordHash=PasswordHashGenerator.GenerateHash("password123")},
                new User{UserName="Foo Bar", Email="foo@foobar.com", ProfilePicture="./img/user.png", PasswordHash=PasswordHashGenerator.GenerateHash("f00b@r")}
            };

            context.Users.AddRange(InitUsers);
            context.SaveChanges();

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
                new Picture{Title="cats lol", ImageURL="https://www.thiscatdoesnotexist.com", TagID=GetRandomTagID(), UserID=0},
                new Picture{Title="my user icon", ImageURL="./img/user.png", TagID=GetRandomTagID(), UserID=1}
            };

            context.Pictures.AddRange(InitPictures);

            context.SaveChanges();
        }
    }
}