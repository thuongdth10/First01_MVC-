using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Size { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
