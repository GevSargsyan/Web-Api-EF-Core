using Core.Entites;
using Core.Repositories;
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
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkService(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }
        public async Task<int> Create(Homework homework)
        {
            if (homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            var isInvalid = homework.Link == null
                || string.IsNullOrWhiteSpace(homework.Title);

            if (isInvalid)
            {
                throw new Exception(HOMEWORK_IS_INVALID);
            }

            return  await _homeworkRepository.Add(homework);

           

        }

        public async Task<int> Delete(int homeworkId)
        {
            if (homeworkId == default(int))
            {
                throw new ArgumentException(nameof(homeworkId));
            }

          return  await _homeworkRepository.Delete(homeworkId);        


        }

        public async Task<Homework> Get(int homeworkId)
        {
            if (homeworkId == default(int))
            {
                throw new ArgumentException(nameof(homeworkId));
            }

           return await _homeworkRepository.Get(homeworkId);
           
        }

        public async Task<int> Update(Homework homework)
        {
            return await _homeworkRepository.Update(homework);
           
        }
    }
}
