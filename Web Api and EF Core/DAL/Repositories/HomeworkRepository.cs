using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeworkRepository(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(Homework newHomework)
        {
            if (newHomework is null)
            {
                throw new ArgumentNullException(nameof(newHomework));
            }

            //var newHomeworkEntity = new Entities.Homework
            //{
            //    Title = newHomework.Title,
            //    Description = newHomework.Description,
            //    Link = newHomework.Link,
            //};

            var newHomeworkEntity = _mapper.Map<DAL.Entities.Homework>(newHomework);


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
                //var homeworkcore = new Core.Entites.Homework
                //{
                //    Title = homework.Title,
                //    Description = homework.Description,
                //    Link = homework.Link,

                //};

                var homeworkcore = _mapper.Map<Core.Entites.Homework>(homework);
                return homeworkcore;
            }

            return null;
        }

        public async Task<List<Homework>> Get()
        {
            var homeworks = await _context.Homeworks.ToListAsync();
            if (homeworks != null)
            {
                var homeworkscore = _mapper.Map<List<Core.Entites.Homework>>(homeworks);

                return homeworkscore;
            }


            return null;
        }

        public async Task<int> Update(Homework homework)
        {
            var homeworkentity = _mapper.Map<DAL.Entities.Homework>(homework);
            var homeworkforupdate = await _context.Homeworks.FirstOrDefaultAsync(x=>x.Id== homeworkentity.Id);
            if (homeworkforupdate != null)
            {
                homeworkforupdate.Title = homeworkentity.Title;
                homeworkforupdate.Description = homeworkentity.Description;
                homeworkforupdate.Link = homeworkentity.Link;
                homeworkforupdate.LessonId = homeworkentity.LessonId;

                await _context.SaveChangesAsync();
                return homeworkforupdate.Id;
            };
            return 0;
        }
    }
}
