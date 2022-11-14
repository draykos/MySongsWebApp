using Microsoft.AspNetCore.Mvc;
using MySongs.DTO;
using MySongs.BLL.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MySongsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly IStudentService studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            this.logger = logger;
            this.studentService = studentService;
        }

        [HttpGet()]
        [Route("/api/students")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var list = studentService.GetStudents();
                var result = await Task.FromResult(list);
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Create([FromBody] StudentCreateDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var student = studentService.Create(model);
                var result = await Task.FromResult(student);

                return CreatedAtAction(nameof(Read),
                    new { id = result.ID }, result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.ToString());
                return StatusCode(500);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<StudentDTO>> Read(int id)
        {
            try
            {
                var student = studentService.Read(id);
                if (student == null)
                {
                    return NotFound();
                }

                var result = await Task.FromResult(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.ToString());
                return StatusCode(500);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDTO model)
        {
            try
            {
                model.ID = id;
                await Task.Run(() => studentService.Update(model));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.ToString());
                return StatusCode(500);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => studentService.Delete(id));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.ToString());
                return StatusCode(500);
            }
        }
    }
}