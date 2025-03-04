using EasyNetQ.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQ.Console {
    public class Person {
        public Person(string fullName, string document, DateTime birthday) {
            FullName = fullName;
            Document = document;
            Birthday = birthday;
        }

        public string FullName { get; set; }
        public string Document { get; set; }
        public DateTime Birthday { get; set; }
    }
}