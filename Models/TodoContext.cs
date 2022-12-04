using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
 
namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems {set;get;} =null!;//creating a table TodoItem
        public DbSet<TodoItemDTO> TodoItemDTOs {set;get;} =null!; //creating another table TodoItemDTO   


    }
}