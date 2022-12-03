using DapperGRP.Api.Configurations;
using DapperGRP.Api.ViewModel;
using DapperGRP.Domain.Entities;
using DapperGRP.Domain.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/products/create", async (ProductVm product, IProductRepository productRepository) =>
{
    return await productRepository
    .CreateAsync(new Product(product.Name, product.Description, product.Price)) ? "Successfully Created" : "Could not create";
}
).WithName("CreateProduct");

app.MapGet("/products/get-all", async (IProductRepository productRepository) =>
    await productRepository.FindAllAsync()
);

app.MapGet("/products/get-by-id", async (string id, IProductRepository productRepository) =>
    await productRepository.FindByIdAsync(Guid.Parse(id))
);

app.MapPut("/products/update/{id}", async (string id, ProductVm product, IProductRepository productRepository) =>
{
    var entity = await productRepository.FindByIdAsync(Guid.Parse(id));

    if(entity == null)
        Results.NotFound();
   
    entity.Update(product.Name, product.Description, product.Price);
    return await productRepository.UpdateAsync(entity) ? "Successfully updated!":"Couldn't update";
}  
);

app.MapDelete("/product/delete/{id}", async (string id, IProductRepository productRepository) =>
{
    return await productRepository.DeleteAsync(Guid.Parse(id)) ? "Successfully deleted" : "Could not delete";
});

app.Run();
