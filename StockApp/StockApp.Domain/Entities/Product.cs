using StockApp.Domain.Validation;
using System;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region Constructors
        public Product()
        {

        }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
            Category = new Category();
            ValidateDomain(name, description, price, stock, image, categoryId, id);
        }
        #endregion

        #region Private Methods
        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryId, int id)
        {
            DomainExceptionValidation.When(id < 0, "invalid negative values for id");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short. Minimum 5 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price. Price cannot be negative.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock. Stock cannot be negative.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image name. image is required");
            DomainExceptionValidation.When(image.Length > 250, "Invalid image name. too long, maximum 250 characters.");
        }
        #endregion
    }
}
