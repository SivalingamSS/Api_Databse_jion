using System.ComponentModel.DataAnnotations;

namespace Api_Databse_CRUD.Model
{
    public class model
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public int empage { get; set; }
        public string empdept { get; set; }
        public string empplace { get; set; }
    }
    public class model2
    {
        [Key]   
        public int sno { get; set; }
        public int salary { get; set; }
    }
   
}
