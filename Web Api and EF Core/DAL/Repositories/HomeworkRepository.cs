using Core.Entites;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly Context _context;

        public HomeworkRepository(Context context)
        {
            _context = context;
        }
        public async Task<int> Add(Homework newHomework)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int homeworkId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Homework>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Homework> Get(int homeworkId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Homework homework)
        {
            throw new NotImplementedException();
        }
    }
}
