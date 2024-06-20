using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "E-Posta")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter uzunluğunda olabilir")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [StringLength(10, ErrorMessage = "Maksimum 10 karakter uzunluğunda olabilir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre (Tekrar)")]
        [StringLength(10, ErrorMessage = "Maksimum 10 karakter uzunluğunda olabilir")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Rol")]
        [StringLength(10, ErrorMessage = "Maksimum 10 karakter uzunluğunda olabilir")]
        public string Role { get; set; }
    }
}
