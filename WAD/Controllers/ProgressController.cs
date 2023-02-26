using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using WAD.Models;
using WAD.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WAD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;
        public ProgressController(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        // GET: api/<ProgressController>
        [HttpGet]
        public IActionResult Get()
        {
            var progress = _progressRepository.GetProgress();
            return new OkObjectResult(progress);
        }

        // GET api/<ProgressController>/5
        [HttpGet("{id}", Name = "GetC")]
        public IActionResult Get(int id)
        {
            var progress = _progressRepository.GetProgressById(id);
            return new OkObjectResult(progress);
        }

        // POST api/<ProgressController>
        [HttpPost]
        public IActionResult Post([FromBody] Progress progress)
        {
            using (var scope = new TransactionScope())
            {
                _progressRepository.InsertProgress(progress);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = progress.ID }, progress);
            }
        }

        // PUT api/<ProgressController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Progress progress)
        {
            if (progress != null)
            {
                using (var scope = new TransactionScope())
                {
                    _progressRepository.UpdateProgress(progress);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<ProgressController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _progressRepository.DeleteProgress(id);
            return new OkResult();
        }
    }
}
