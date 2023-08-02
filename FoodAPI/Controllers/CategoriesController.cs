using AutoMapper;
using FoodAPI.DAL;
using FoodAPI.Entities;
using FoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories(
            int pageNum, int pageSize)
        {
            var categories = await _unitOfWork
                .CategoriesRepository
                .GetAllAsync(pageNum, pageSize);

            var categoryDtos = new List<CategoryDto>();

            foreach (var category in categories)
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);

                categoryDtos.Add(categoryDto);
            }

            return Ok(categoryDtos);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            var category = await _unitOfWork
                .CategoriesRepository
                .GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(
            CategoryForCreateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _unitOfWork
                .CategoriesRepository
                .Add(categoryEntity);

            await _unitOfWork.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtAction("GetCategoryById", new
            {
                categoryEntity.Id
            },
            categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(
            Guid id, CategoryForUpdateDto category)
        {
            var categoryEntity = await _unitOfWork
                .CategoriesRepository
                .GetByIdAsync(id);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(category, categoryEntity);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var isCategoryExist = await _unitOfWork
                .CategoriesRepository
                .IsExistAsync(id);
            
            if (!isCategoryExist)
            {
                return NotFound();
            }

            await _unitOfWork
                .CategoriesRepository
                .DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
     }
}
