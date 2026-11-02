 

namespace   WS1
{
    public interface IStudentManager
    {
        //1
        void AddStudent();
        //2
        void DisplayStudents();
        //3
        Student SearchById(string id);
        //4
        List<Student> SearchByName(string name);
        //5
        public void UpdateStudent();
        //6
        public void DeleteStudent();
        //7
        List<Student> FindTopStudent();
        //8
        public void SortByGPA();
        //9
        public void CountRanks();
        //10
        public float CalculateAverageGPA();
        //11
        List< Student> GetStudentsAboveAverageGPA();


    }
}