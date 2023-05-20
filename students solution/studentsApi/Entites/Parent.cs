namespace students_Api.Entites
{
    public class Parent: BaseEntity
    {
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
