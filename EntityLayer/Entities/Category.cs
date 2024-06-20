using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Ad")]
        [StringLength (50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
