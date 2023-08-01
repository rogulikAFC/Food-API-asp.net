using AutoMapper;
using FoodAPI.DAL;
using FoodAPI.Entities;
using FoodAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StepsController(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}", Name = "GetStepById")]
        public async Task<ActionResult<StepDto>> GetStepById(Guid id)
        {
            var step = await _unitOfWork
                .StepsRepository
                .GetByIdAsync(id);

            var stepDto = _mapper.Map<StepDto>(step);

            return Ok(stepDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostStep(StepForCreateDto step)
        {
            var stepEntity = _mapper.Map<Step>(step);

            var dishId = step.DishId;

            var isDishExists = await _unitOfWork
                .DishesRepository
                .IsExist(dishId);

            if (!isDishExists)
            {
                return NotFound(nameof(dishId));
            }

            await _unitOfWork
                .StepsRepository
                .AddStepAsync(dishId, stepEntity);

            await _unitOfWork.SaveChangesAsync();

            var stepDto = _mapper.Map<StepDto>(stepEntity);

            return CreatedAtAction("GetStepById", new
            {
                stepEntity.Id
            },
            stepDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Step>> UpdateStep(
            Guid id, StepForUpdateDto step)
        {
            var stepEntity = await _unitOfWork
                .StepsRepository
                .GetByIdAsync(id);

            if (stepEntity == null)
            {
                return NotFound(nameof(stepEntity));
            }

            _mapper.Map(step, stepEntity);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStep(Guid id)
        {
            var isStepExists = await _unitOfWork
                .StepsRepository
                .IsExist(id);

            if (!isStepExists) 
            {
                return NotFound();
            }

            await _unitOfWork
                .StepsRepository
                .DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
