using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//Request
//Получить все пункты задач
app.MapGet("/request", async (TodoDb db) =>
    await db.Requests
    .ToListAsync());

//Получение элемента по идентификатору
app.MapGet("/request/{id}", async (int id, TodoDb db) =>
    await db.Requests.FindAsync(id)
        is Request todo
            ? Results.Ok(todo)
            : Results.NotFound());

//Добавление нового элемента
app.MapPost("/request", async (Request request, TodoDb db) =>
{
    db.Requests.Add(request);
    await db.SaveChangesAsync();

    return Results.Created($"/request/{request.RequestID}", request);
});

//Обновление существующего элемента 
app.MapPut("/request/{id}", async (int id, Request inputRequest, TodoDb db) =>
{
    var request = await db.Requests.FindAsync(id);

    if (request is null) return Results.NotFound();

    request.UserID = inputRequest.UserID;
    request.CourseID = inputRequest.CourseID;
    request.StatusID = inputRequest.StatusID;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Удаление элемента 
app.MapDelete("/request/{id}", async (int id, TodoDb db) =>
{
    if (await db.Requests.FindAsync(id) is Request todo)
    {
        db.Requests.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//User
//Получить все пункты задач
app.MapGet("/user", async (TodoDb db) =>
    await db.Users
    .ToListAsync());

//Получение элемента по идентификатору
app.MapGet("/user/{id}", async (int id, TodoDb db) =>
    await db.Users.FindAsync(id)
        is User todo
            ? Results.Ok(todo)
            : Results.NotFound());

//Добавление нового элемента
app.MapPost("/user", async (User user, TodoDb db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/user/{user.UserID}", user);
});

//Обновление существующего элемента 
app.MapPut("/user/{id}", async (int id, User inputUser, TodoDb db) =>
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Login = inputUser.Login;
    user.Password = inputUser.Password;
    user.LastName = inputUser.LastName;
    user.FirstName = inputUser.FirstName;
    user.MiddleName = inputUser.MiddleName;
    user.Email = inputUser.Email;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Удаление элемента 
app.MapDelete("/user/{id}", async (int id, TodoDb db) =>
{
    if (await db.Courses.FindAsync(id) is Course todo)
    {
        db.Courses.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//Course
//Получить все пункты задач
app.MapGet("/course", async (TodoDb db) =>
    await db.Courses
    .ToListAsync());

//Получение элемента по идентификатору
app.MapGet("/course/{id}", async (int id, TodoDb db) =>
    await db.Courses.FindAsync(id)
        is Course todo
            ? Results.Ok(todo)
            : Results.NotFound());

//Добавление нового элемента
app.MapPost("/course", async (Course course, TodoDb db) =>
{
    db.Courses.Add(course);
    await db.SaveChangesAsync();

    return Results.Created($"/course/{course.CourseID}", course);
});

//Обновление существующего элемента 
app.MapPut("/course/{id}", async (int id, Course inputCourse, TodoDb db) =>
{
    var course = await db.Courses.FindAsync(id);

    if (course is null) return Results.NotFound();

    course.CourseName = inputCourse.CourseName;
    course.StartDate = inputCourse.StartDate;
    course.EndDate = inputCourse.EndDate;
    course.Description = inputCourse.Description;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Удаление элемента 
app.MapDelete("/course/{id}", async (int id, TodoDb db) =>
{
    if (await db.Courses.FindAsync(id) is Course todo)
    {
        db.Courses.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

//RequestStatus
//Получить все пункты задач
app.MapGet("/requestStatus", async (TodoDb db) =>
    await db.RequestStatuses
    .ToListAsync());

//Получение элемента по идентификатору
app.MapGet("/requestStatus/{id}", async (int id, TodoDb db) =>
    await db.RequestStatuses.FindAsync(id)
        is RequestStatus todo
            ? Results.Ok(todo)
            : Results.NotFound());

//Добавление нового элемента
app.MapPost("/requestStatus", async (RequestStatus requestStatus, TodoDb db) =>
{
    db.RequestStatuses.Add(requestStatus);
    await db.SaveChangesAsync();

    return Results.Created($"/requestStatus/{requestStatus.StatusID}", requestStatus);
});

//Обновление существующего элемента 
app.MapPut("/requestStatus/{id}", async (int id, RequestStatus inputRequestStatus, TodoDb db) =>
{
    var requestStatus = await db.RequestStatuses.FindAsync(id);

    if (requestStatus is null) return Results.NotFound();

    requestStatus.StatusName = inputRequestStatus.StatusName;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Удаление элемента 
app.MapDelete("/requestStatus/{id}", async (int id, TodoDb db) =>
{
    if (await db.RequestStatuses.FindAsync(id) is RequestStatus todo)
    {
        db.RequestStatuses.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();