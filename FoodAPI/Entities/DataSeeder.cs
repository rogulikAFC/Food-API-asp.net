using FoodAPI.DbContexts;
using Microsoft.AspNetCore.Mvc;

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
                        /* Recipe = new List<Step>()
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
                        }, */
                        CategoryId = new Guid("0B823D5D-483B-4F79-BDA9-ACB9F8E4AA23")
                    },
                    new Dish()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Spagetti",
                        Description = "Lorem ipsum Spagetti dorem",
                        /* Recipe = new List<Step>()
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
                        }, */
                        CategoryId = new Guid("0B823D5D-483B-4F79-BDA9-ACB9F8E4AA23")
                    },
                    new Dish()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cheese",
                        Description = "Lorem ipsum cheese dorem",
                        /* Recipe = new List<Step>()
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
                        }, */
                        CategoryId = new Guid("D306A61C-B6A3-46F1-9DCD-0D9871CFF0BE")
                    }
                };

                _foodContext.Dishes.AddRange(dishes);
                _foodContext.SaveChanges();
            }

            if (!_foodContext.Steps.Any())
            {
                var steps = new List<Step>()
                {
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 1",
                         DishId = new Guid("506125BE-0012-436D-AD12-DC898C0A294F"),
                         SerialNumber = 1
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 2",
                         DishId = new Guid("506125BE-0012-436D-AD12-DC898C0A294F"),
                         SerialNumber = 2
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 3",
                         DishId = new Guid("506125BE-0012-436D-AD12-DC898C0A294F"),
                         SerialNumber = 3
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 4",
                         DishId = new Guid("506125BE-0012-436D-AD12-DC898C0A294F"),
                         SerialNumber = 4
                     },

                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 1",
                         DishId = new Guid("7800BE7D-1E71-47AA-943F-F73A0F568B1D"),
                         SerialNumber = 1
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 2",
                         DishId = new Guid("7800BE7D-1E71-47AA-943F-F73A0F568B1D"),
                         SerialNumber = 2
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 3",
                         DishId = new Guid("7800BE7D-1E71-47AA-943F-F73A0F568B1D"),
                         SerialNumber = 3
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 4",
                         DishId = new Guid("7800BE7D-1E71-47AA-943F-F73A0F568B1D"),
                         SerialNumber = 4
                     },

                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 1",
                         DishId = new Guid("84EF128C-319E-4638-8790-FD5FE96734A6"),
                         SerialNumber = 1
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 2",
                         DishId = new Guid("84EF128C-319E-4638-8790-FD5FE96734A6"),
                         SerialNumber = 2
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 3",
                         DishId = new Guid("84EF128C-319E-4638-8790-FD5FE96734A6"),
                         SerialNumber = 3
                     },
                     new Step()
                     {
                         Id = Guid.NewGuid(),
                         Text = "Step 4",
                         DishId = new Guid("84EF128C-319E-4638-8790-FD5FE96734A6"),
                         SerialNumber = 4
                     },
                };

                _foodContext.Steps.AddRange(steps);
                _foodContext.SaveChanges();
            }
        }
    }
}
