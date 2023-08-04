using AutoMapper;
using FoodAPI.DAL;
using FoodAPI.Entities;
using FoodAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DishesController> _logger;

        public DishesController(
            IUnitOfWork unitOfWork, IMapper mapper, ILogger<DishesController> logger)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<DishDto>>> GetAllDishes(
            int pageNum, int pageSize)
        {
            var dishes = await _unitOfWork
                .DishesRepository
                .GetAllAsync(pageNum, pageSize);

            var dishDtos = new List<DishDto>();

            foreach (var dish in dishes)
            {
                var dishDto = _mapper.Map<DishDto>(dish);

                dishDtos.Add(dishDto);
            }

            return Ok(dishDtos);
        }

        [HttpGet("{id}", Name = "GetDishById")]
        public async Task<ActionResult<DishDto>> GetDishById(Guid id)
        {
            var dish = await _unitOfWork
                .DishesRepository
                .GetByIdAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        [HttpPost]
        public async Task<ActionResult<DishDto>> PostDish(
            DishForCreateDto dish)
        {
            if (dish.CategoryId != null)
            {
                var isCategoryExists = await _unitOfWork
                    .CategoriesRepository
                    .IsExistAsync((Guid)dish.CategoryId);

                if (!isCategoryExists)
                {
                    return NotFound(dish.CategoryId);
                }
            }

            var dishEntity = _mapper.Map<Dish>(dish);

            _unitOfWork.DishesRepository.Add(dishEntity);

            await _unitOfWork.SaveChangesAsync();

            var dishDto = _mapper.Map<DishDto>(dishEntity);

            return CreatedAtAction("GetDishById", new
            {
                dishEntity.Id
            },
            dishDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDish(
            DishForUpdateDto dish, Guid id)
        {
            var dishEntity = await _unitOfWork
                .DishesRepository
                .GetByIdAsync(id);

            if (dishEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(dish, dishEntity);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchDish(
            JsonPatchDocument<Dish> patchDoc, Guid id)
        {
            var dish = await _unitOfWork
                .DishesRepository
                .GetByIdAsync(id);

            if (dish == null)
            {
                return NotFound(nameof(dish));
            }

            patchDoc.ApplyTo(dish, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDish(Guid id)
        {
            var isDishExist = await _unitOfWork
                .DishesRepository
                .IsExistAsync(id);

            if (!isDishExist)
            {
                return NotFound();
            }

            await _unitOfWork
                .DishesRepository
                .DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
