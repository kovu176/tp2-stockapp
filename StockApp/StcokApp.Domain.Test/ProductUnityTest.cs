using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;

namespace StockApp.Domain.Test
{
    #region Testes Positivos
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create product with valid id")]
        public void CreateProduct_WithValidId_ResultValidState()
        {
            Action action = () => new Product { Id = 1, Name = "Valid product name" };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid name")]
        public void CreateProduct_WithValidName_ResultValidState()
        {
            Action action = () => new Product { Id = 1, Name = "Valid product name" };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid description")]
        public void CreateProduct_WithValidDescription_ResultValidState()
        {
            Action action = () => new Product
            {
                Id = 1,
                Name = "Valid product name",
                Description = "Valid product description"
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid price")]
        public void CreateProduct_WithValidPrice_ResultValidState()
        {
            Action action = () => new Product
            {
                Id = 1,
                Name = "Valid product name",
                Description = "Valid product description",
                Price = 100.0m
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid stock")]
        public void CreateProduct_WithValidStock_ResultValidState()
        {
            Action action = () => new Product
            {
                Id = 1,
                Name = "Valid product name",
                Description = "Valid product description",
                Price = 100.0m,
                Stock = 50
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid image")]
        public void CreateProduct_WithValidImage_ResultValidState()
        {
            Action action = () => new Product
            {
                Id = 1,
                Name = "Valid product name",
                Description = "Valid product description",
                Price = 100.0m,
                Stock = 50,
                Image = "validImage.jpg"
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with valid all parameters")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product
            {
                Id = 1,
                Name = "Valid product name",
                Description = "Valid product description",
                Price = 100.0m,
                Stock = 50,
                Image = "validImage.jpg",
                CategoryId = 1
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create product with invalid id")]
        public void CreateProduct_WithInvalidId_ShouldThrowValidationException()
        {
            Action action = () => new Product(-1, "valid product name", "Valid description",
                10.50m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("invalid negative values for id");
        }

        [Fact(DisplayName = "Create product with null name")]
        public void CreateProduct_WithNullName_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, null, "Valid description",
                10.50m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create product with short name")]
        public void CreateProduct_WithShortName_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "pr", "Valid description",
                10.50m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters.");
        }

        [Fact(DisplayName = "Create product with null description")]
        public void CreateProduct_WithNullDescription_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "valid name", null,
                10.50m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create product with short description")]
        public void CreateProduct_WithShortDescription_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "valid name", "de",
                10.50m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short. Minimum 5 characters.");
        }

        [Fact(DisplayName = "Create product with invalid price")]
        public void CreateProduct_WithInvalidPrice_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "valid product name", "Valid description",
                -1.00m, 100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price. Price cannot be negative.");
        }

        [Fact(DisplayName = "Create product with invalid stock")]
        public void CreateProduct_WithInvalidStock_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "valid product name", "Valid description",
                10.50m, -100, "image.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock. Stock cannot be negative.");
        }

        [Fact(DisplayName = "Create product with invalid image")]
        public void CreateProduct_WithInvalidEmpty_ShouldThrowValidationException()
        {
            Action action = () => new Product(1, "valid product name", "Valid description",
                10.50m, 100, "", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name. image is required");
        }
        #endregion
    }
}
