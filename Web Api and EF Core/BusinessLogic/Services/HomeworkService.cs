using Core.Entites;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class HomeworkService : IHomeworkService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invalid!";
        public async Task<int> Create(Homework homework)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int homeworkId)
        {
            throw new NotImplementedException();
        }
    }
}
