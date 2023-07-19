using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string? PostName { get; set; }

        public string? PostTitle { get; set; }

        public string? MetaTitle { get; set; }

        public string? Slug { get; set; }

        public bool Published { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public int BlogId { get; set; }

        public int UserId { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
