using FoodAPI.DbContexts;

namespace FoodAPI.Entities
{
    public class DataSeeder
    {
        private readonly FoodContext _foodContext;

        public DataSeeder(FoodContext foodContext)
        {
            _foodContext = foodContext
                ?? throw new ArgumentNullException(nameof(foodContext));
        }

        public void Seed()
        {
            if (!_foodContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Breakfast"
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Launch"
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dinner"
                    }
                };

                _foodContext.Categories.AddRange(categories);
                _foodContext.SaveChanges();
            }

            if (!_foodContext.Dishes.Any())
            {
                var dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pizza",
                        Description = "Lorem ipsum pizza dorem",
                        Recipe = new List<Step>()
                        {
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 1"
                            },
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 2"
                            },new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 3"
                            },
                        },
                        CategoryId = new Guid("A2D77B5C-D09F-4E5A-9313-8CCCCB7BF5E3")
                    },
                    new Dish()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Spagetti",
                        Description = "Lorem ipsum Spagetti dorem",
                        Recipe = new List<Step>()
                        {
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 1"
                            },
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 2"
                            },new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 3"
                            },
                        },
                        CategoryId = new Guid("E5D5CFAA-19EB-4D9E-88C6-1F293C2E3062")
                    },
                    new Dish()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cheese",
                        Description = "Lorem ipsum cheese dorem",
                        Recipe = new List<Step>()
                        {
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 1"
                            },
                            new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 2"
                            },new Step()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Step 3"
                            },
                        },
                        CategoryId = new Guid("99335D66-5505-4196-BF2E-EAD926AD40FF")
                    }
                };

                _foodContext.Dishes.AddRange(dishes);
                _foodContext.SaveChanges();
            }
        }
    }
}
