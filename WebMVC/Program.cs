﻿using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entities.Concrate;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.AutoMapper;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSession(); 

// DbContext
builder.Services.AddDbContext<ContractContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Dependency Injection
builder.Services.AddScoped<IContractService, ContractManager>();
builder.Services.AddScoped<IContractDal, EfContractDal>();
builder.Services.AddScoped<IOrganizationService, OrganizationManager>();
builder.Services.AddScoped<IOrganizationDal, EfOrganizationDal>();
builder.Services.AddScoped<IAmountTypeService, AmountTypeManager>();
builder.Services.AddScoped<IAmountTypeDal, EfAmountTypeDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryTypeService, CategoryTypeManager>();
builder.Services.AddScoped<ICategoryTypeDal, EfCategoryTypeDal>();
builder.Services.AddScoped<IContractStatusService, ContractStatusManager>();
builder.Services.AddScoped<IContractStatusDal, EfContractStatusDal>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
builder.Services.AddScoped<IPaymentMethodDal, EfPaymentMethodDal>();
builder.Services.AddScoped<IGuaranteeService, GuaranteeManager>();
builder.Services.AddScoped<IGuaranteeDal, EfGuaranteeDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();


builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// App
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession(); 

app.UseAuthentication(); 
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
