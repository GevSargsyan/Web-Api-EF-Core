using Core.Entites;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
            if (newHomework is null)
            {
                throw new ArgumentNullException(nameof(newHomework));
            }

            var newHomeworkEntity = new Entities.Homework
            {
                Title = newHomework.Title,
                Description = newHomework.Description,
                Link = newHomework.Link,
            };

            await _context.Homeworks.AddAsync(newHomeworkEntity);
            await _context.SaveChangesAsync();

            return newHomeworkEntity.Id;
        }

        public async Task<int> Delete(int homeworkId)
        {
          var homework =  _context.Homeworks.FirstOrDefault(x => x.Id == homeworkId);
            if (homework != null)
            {
                _context.Homeworks.Remove(homework);
               await _context.SaveChangesAsync();
                return homework.Id;
            }

            return 0;
        }

        //public async Task<List<Homework>> Get()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Homework> Get(int homeworkId)
        {
            var homework = await _context.Homeworks.FirstOrDefaultAsync(x => x.Id == homeworkId);
            if (homework != null)
            {
                var homeworkcore = new Core.Entites.Homework
                {
                    Title = homework.Title,
                    Description = homework.Description,
                    Link = homework.Link,

                };
                return homeworkcore;
            }

            return null;
        }

        public async Task<int> Update(Homework homework)
        {
            var homeworkforupdate = await _context.Homeworks.FirstOrDefaultAsync(x=>x.Id==homework.Id);
            if (homeworkforupdate != null)
            {
                homeworkforupdate.Title = homework.Title;
                homeworkforupdate.Description = homework.Description;
                homeworkforupdate.Link = homework.Link;

                await _context.SaveChangesAsync();
                return homeworkforupdate.Id;
            };
            return 0;
        }
    }
}
