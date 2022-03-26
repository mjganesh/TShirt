using System;
using System.ComponentModel.DataAnnotations;

namespace TShirt.Models
{
    public class Shirt
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Size Size { get; set; }

        public DateTime CurrentDate { get; set; }

    }

    public enum Size
    {

        Small = 0,
        Medium = 1,
        Large = 2
    }
}
