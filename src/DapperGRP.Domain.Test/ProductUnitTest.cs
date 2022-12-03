using DapperGRP.Domain.Entities;
using FluentAssertions;

namespace DapperGRP.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create a Product With Valid State Using Full Constructor")]
        public void CreateProduct_ValidParameters_ResultObjectValidState_FullConstructor()
        {
            Action action = () => new Product(Guid.NewGuid().ToString(), "Product Name", "Product Description", 9.99m);

            action.Should()
                .NotThrow<CustomException.DomainValidateException>();
        }

        [Fact(DisplayName = "Create a Product With Valid State")]
        public void CreateProduct_ValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name", "Product Description", 9.99m);

            action.Should()
                .NotThrow<CustomException.DomainValidateException>();
        }

        [Fact(DisplayName = "Create Product Missing Name")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product("", "Product Description", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Name is invalid. Name is required.");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product("Ps", "Product Description", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Name is invalid. Too short, minimun 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Long Name")]
        public void CreateProduct_LongNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product("Product Nameaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 
                "Product Description", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Name is invalid. Too long, maximun 100 characters.");
        }

        [Fact(DisplayName = "Create Product Missing Description")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product("Product Name", "", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Description is invalid. Description is required.");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionRequiredShortDescription()
        {
            Action action = () => new Product("Product Name", "Des", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Description is invalid. Too short, minimun 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Long Description")]
        public void CreateProduct_LongDescriptionValue_DomainExceptionRequiredLongDescription()
        {
            Action action = () => new Product("Product Name", "Product Description aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 9.99m);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Description is invalid. Too long, maximun 300 characters.");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionRequiredInvalidPrice()
        {
            Action action = () => new Product("Product Name", "Product Description", -1);
            action.Should().Throw<CustomException.DomainValidateException>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Update Product With Valid State")]
        public void UpdateProduct_ValidParameters_ResultObjectValidState()
        {
            var entity =  new Product("Product Name", "Product Description", 9.99m);
            entity.Update("Product Name Update", "Product Description Update", 11.11m);

            Assert.True(entity.Name.Equals("Product Name Update") &&
                        entity.Description.Equals("Product Description Update") &&
                        entity.Price == 11.11m);
        }
    }
}