using RefactoringLab.Part02.Enrollment;

namespace Enrollement_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Enrollment ===");
            var studentId = "S100";
            var courseId = "CS201";
            var amount = 1500m;

            var enrollmentFacade = new EnrollmentFacade();
            enrollmentFacade.Enroll(studentId, courseId, amount);
        }
    }
}
