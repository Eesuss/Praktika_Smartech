namespace Contracts
{
    public interface IRepositoryWrapper
    {

        IPostRepository Post { get; }
        IUserRepository User { get; }
        IStudentRepository Student { get; }
        IlessonsRepository Lessons { get; }
        ICoursesRepository Courses { get; }
        ILessonContentRepository LessonsContent { get; }
        IJournalRepository Journal { get; }

        void Save();
    }
}
