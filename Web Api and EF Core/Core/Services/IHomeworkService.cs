using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IHomeworkService
    {
        Task<int> Create(Homework homework);
        Task<int> Delete(int homeworkId);
        Task<Homework> Get(int homeworkId);
        Task<int> Update(Homework homework);
    }
}
