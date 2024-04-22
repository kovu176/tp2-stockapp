using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;

namespace StockApp.Domain.Test
{
    #region Testes positivos
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }


        #endregion

        #region Testes negativos

        [Fact(DisplayName = "Create Category With Invalid State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("invalid id value.");
        }

        [Fact(DisplayName = "Create Category With Invalid State Name (Short)")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidShortName()
        {
            Action action = () => new Category(1, "ca");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Null State Name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
    }

    #endregion
}

