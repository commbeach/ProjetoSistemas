using NSwag.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;
using TodoApi.controller;
using TodoApi.view;

var builder = WebApplication.CreateBuilder(args);

builder.RenderBuild();

var app = builder.Build();

app.RenderMenu();

app.ParaEndpoints();

app.Run();