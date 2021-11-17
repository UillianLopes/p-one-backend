using POne.Financial.Domain.Queries.Outputs.Categories;
using System;

namespace POne.Financial.Domain.Queries.Outputs.SubCategories
{
    public class SubCategoryOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryOuput Category { get; set; }
    }
}
