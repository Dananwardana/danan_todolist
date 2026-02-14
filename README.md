# Danan TodoList API

REST API sederhana Todo List menggunakan ASP.NET Core Web API dan SQLite.

## Cara Menjalankan
1. clone repository: `git clone https://github.com/Dananwardana/danan_todolist.git`

2. masuk ke folder project: `cd danan_todolist`

3. install dependency: `dotnet restore`

4. setup database (migration): `dotnet ef database update`

5. jalankan projek: `dotnet run`

6. Akses Swagger UI: https://localhost:<port>/swagger

## Versi .NET
.NET 8

## Database
Menggunakan SQLite.
File database todos.db akan dibuat otomatis setelah menjalankan: dotnet ef database update

## Endpoint
1. POST /api/todos
2. GET /api/todos
3. GET /api/todos/{id}
4. PUT /api/todos/{id}/complete
5. DELETE /api/todos/{id}
