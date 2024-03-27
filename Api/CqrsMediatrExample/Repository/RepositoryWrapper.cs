using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;

        private IPostRepository _post;
        private IUserRepository _user;
        private IlessonsRepository _lessons;
        private ICoursesRepository _courses;
        private IStudentRepository _student;
        private IJournalRepository _journal;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_repoContext);
                }
                return _student;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }



        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_repoContext);
                }
                return _post;
            }
        }





        public IlessonsRepository Lessons
        {
            get
            {
                if (_lessons == null)
                {
                    _lessons = new LessonsRepository(_repoContext);
                }
                return _lessons;
            }
        }

        public ICoursesRepository Courses
        {
            get
            {
                if (_courses == null)
                {
                    _courses = new CoursesRepository(_repoContext);
                }
                return _courses;
            }
        }



        public IJournalRepository Journal
        {
            get
            {
                if (_journal == null)
                {
                    _journal = new JournalRepository(_repoContext);
                }
                return _journal;
            }
        }



        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
