using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Model
{
    [Table("tbl_Task")]
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DueDate { get; set; }
        public TimeOnly DueTime { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int User { get; set; }
        public int Category { get; set; }
        public DateTime Reminders { get; set; }
    }
}