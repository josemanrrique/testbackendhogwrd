using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartsApi
{
    ///<summary>
    ///Clase con los datos de las solicitudes de estudiantes.
    ///</summary>
    public class Student
    {
        ///<summary>
        ///Id de la solicitud
        ///</summary>
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public int Id { get; set; }
        ///<summary>
        ///Nombre del estudiante
        ///</summary>
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        ///<summary>
        ///Apellido del estudiante
        ///</summary>
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }
        ///<summary>
        ///Edad del estudiante
        ///</summary>
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public int Age { get; set; }
        ///<summary>
        ///Casa que desea el estudiante
        ///</summary>
        [Required]
        [OptionsMagicHouse]
        public string MagicHouse { get; set; }
        public Student()
        {
        }
        public Student(string[] data)
        {
            Id = Convert.ToInt32(data[0]);
            Name = data[1];
            LastName = data[2];
            Age = Convert.ToInt32(data[3]);            
            MagicHouse = data[4];            
        }
    }
}    