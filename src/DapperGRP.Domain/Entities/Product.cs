﻿using DapperGRP.Domain.CustomException;

namespace DapperGRP.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get;  private set; }
        public decimal Price { get;  private set; }

        public Product(string name, string description, decimal price)
           => validateProperties(name, description, price);

        public Product(Guid id, string name, string description, decimal price) : base(id)
           => validateProperties(name, description, price);

        public void Update(string name, string description, decimal price)
            => validateProperties(name, description, price);

        private void validateProperties(string name, string description, decimal price)
        {
            DomainValidateException.When(string.IsNullOrEmpty(name), "Name is inválid. Name is required.");
            DomainValidateException.When(name.Length <= 2, "Name is invalid. Too short, minimun 3 characters.");
            DomainValidateException.When(name.Length > 100, "Name is invalid. Too long, maximun 100 characters.");

            DomainValidateException.When(string.IsNullOrEmpty(description), "Name is inválid. Name is required.");
            DomainValidateException.When(description.Length <= 5, "Description is invalid. Too short, minimun 5 characters.");
            DomainValidateException.When(description.Length > 300, "Description is invalid. Too long, maximun 300 characters.");

            DomainValidateException.When(price < 0, "Invalid price value");

            Name = name;
            Description = description;
            Price = price;
        }
    }
}
