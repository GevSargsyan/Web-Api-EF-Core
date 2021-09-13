using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Contracts;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        private readonly IMapper _mapper;

        public HomeworkController(IHomeworkService homeworkService, IMapper mapper)
        {
            _homeworkService = homeworkService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
           var homeworkscore =  await _homeworkService.Get();
            if (homeworkscore != null)
            {
                var homeworks = _mapper.Map<List<Contracts.Homework>>(homeworkscore);
                return Ok(homeworks);
            }


            return BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _homeworkService.Get(id);
            var contractresult = _mapper.Map<Contracts.Homework>(result);
            if (result != null)
            {
                return Ok(contractresult);

            }
            throw new Exception("Null");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Homework request)
        {
            //var homework = new Core.Entites.Homework
            //{
            //    Title = request.Title,
            //    Description = request.Description,
            //    Link = request.Link

            //};

            var homework = _mapper.Map<Core.Entites.Homework>(request);

            var result = await _homeworkService.Create(homework);

            return Ok(result);
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {

            var result = await _homeworkService.Delete(id);
            if (result == 0)
            {
                throw new Exception("Null Id");
            }
            return Ok(id);
        }

        [HttpPut]

        public async Task<ActionResult> Update(HomeworkCreate homework)
        {
            if (homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            //var homeworkcore = new Core.Entites.Homework
            //{
            //    Id = homework.Id,
            //    Title = homework.Title,
            //    Description = homework.Description,
            //    Link = homework.Link

            //};

            var homeworkcore = _mapper.Map<Core.Entites.Homework>(homework);

            var result = await _homeworkService.Update(homeworkcore);

            return Ok(result);

        }
    }
}
