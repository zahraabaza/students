namespace students_Api.Entites
{
    public class Student: BaseEntity
    {
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
