namespace SurvivorWebApi.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now; // ← When initialized automatically creating CreateDate
            ModifiedDate = DateTime.Now; // ← This is also for set first create but after future modified date tracking I used 'EF ChangeTracker' 
        }
    }
}
