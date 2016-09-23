using System.ComponentModel.DataAnnotations;

namespace PersistenciaDatos
{
    public class Usuario
    {
        [Required]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Minimo 8 caracteres")]
        [StringLength(8, ErrorMessage = "Maximo {8} caracteres")]
        public string dni { get; set; }

        //En este segundo ejemplo, la longitud de la contraseña no importa, 
        //pero la contraseña debe contener al menos 1 número, al menos 1 minúscula, y al menos 1 mayúscula.
        //  ^\w*(?=\w*\d)(?=\w*[a-z])(?=\w*[A-Z])\w*$

        //En este  tercer ejemplo:
        //Debe tener al menos 10 caracteres
        //Debe contener al menos uno una letra minúscula, una letra mayúscula, un dígito y un carácter especial
        //caracteres especiales válidos son - @ # $% ^ & + =
        //      ^.*(?=.{10,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$

        //Valida una contraseña segura.Debe tener entre 8 y 10 caracteres, 
        //contener al menos un dígito y un carácter alfabético, y no debe contener caracteres especiales.
        //   [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$", ErrorMessage = "La contraseña debe al menos un dígito y un carácter alfabético, y no debe contener caracteres especiales.")]
        [Required]
        [RegularExpression(@"^.*(?=.{10,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Debe contener al menos uno una letra minúscula, una letra mayúscula, un dígito y un carácter especial")]
        public string password { get; set; }
    }
}
