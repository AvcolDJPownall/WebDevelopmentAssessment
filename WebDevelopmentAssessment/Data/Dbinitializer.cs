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

            string[] inittags = new string[]
            {
                "HD",
                "Cat",
                "Dog",
                "Public Domain"
            };

            foreach (var str in inittags)
            {
                Tag tag = new Tag {Text = str};
                context.Tags.Add(tag);
            }

            context.SaveChanges();
        }
    }
}