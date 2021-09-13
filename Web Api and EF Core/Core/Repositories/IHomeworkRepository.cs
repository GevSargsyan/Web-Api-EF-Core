using Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
  public  interface IHomeworkRepository
    {
        Task<int> Add(Homework newHomework);
        Task<int>  Update(Homework homework);
        Task<int> Delete(int homeworkId);
        Task<List<Homework>> Get();
        Task<Homework> Get(int homeworkId);
    }
}
