using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyTester.Domain
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Patronymic { get; set; }

        public virtual List<PersonsAnswers> PersonsAnswers { get; set; } 


    }
}
