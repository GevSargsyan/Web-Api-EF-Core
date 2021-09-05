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
        Task<bool> Delete(int homeworkId);
    }
}
