using System;
namespace First01_MVC.Models
{
    public class Student
    {
        public Student()
        {

        }
        public Student(int Id, string Username, bool Gender)
        {
            this.Id = Id;
            this.Username = Username;
            this.Gender = Gender;

        }
        public int Id { get; set; }
        public string Username { get; set; }
        public bool Gender { get; set; }
        //public  void SuaGauGau()
        //{
        //    //do ST
        //    //new Object moi run dc
        //}
    }
}
