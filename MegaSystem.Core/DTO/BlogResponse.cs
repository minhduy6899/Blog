using AutoMapper;
using MegaSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.DTO
{
    public class BlogResponse
    {
        public int Id { get; set; }

        public string? BlogName { get; set; }

        public ICollection<string>? Posts { get; set; }

    }
   
}
