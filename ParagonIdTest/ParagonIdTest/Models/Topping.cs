using System;
using System.Collections.Generic;
using System.Text;

namespace ParagonIdTest.Models
{
    public class Topping
    {
        public Topping(string id, string topingName)
        {
            Id = id;
            TopicName = topingName;
        }

        public string Id { get; set; }

        public string TopicName { get; set; }
    }
}
