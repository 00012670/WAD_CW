using Microsoft.AspNetCore.Mvc;
using WAD.Repositories;
using WAD.Models;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WAD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitRepository _habitRepository;
        public HabitController(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        // GET: api/<HabitController>
        [HttpGet]
        public IActionResult Get()
        {
            var habits = _habitRepository.GetHabits();
            return new OkObjectResult(habits);
        }

        // GET api/<HabitController>/5
        [HttpGet, Route("{id}", Name = "GetP")]
        public IActionResult Get(int id)
        {
            var habit = _habitRepository.GetHabitById(id);
            return new OkObjectResult(habit);
        }

        // POST api/<HabitController>
        [HttpPost]
        public IActionResult Post([FromBody] Habit habit)
        {
            using (var scope = new TransactionScope())
            {
                _habitRepository.InsertHabit(habit);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = habit.ID }, habit);
            }
        }

        // PUT api/<HabitController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Habit habit)
        {
            if (habit != null)
            {
                using (var scope = new TransactionScope())
                {
                    _habitRepository.UpdateHabit(habit);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<HabitController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habitRepository.DeleteHabit(id);
            return new OkResult();
        }
    }
}
