using RepositoryPatternExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPatternExample.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public String Name { get; set; }
    }
}
