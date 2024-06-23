namespace StudentApplicatie.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int LabPoints { get; set; }
        public int Id { get; set; }
        public int ExamenPoints { get; set; }
        public int? ClassGroupId {get; set;}
        public virtual ClassGroup? ClassGroup { get; set; }
    }

    
}
