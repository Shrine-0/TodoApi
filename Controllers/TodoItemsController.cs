using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using MySql.Data.MySqlClient;
namespace TodoApi.Controllers
{
   
    public class DatabaseConnection
        {
            private readonly string _connectionString;
            private MySqlConnection _connection;

            public DatabaseConnection(string connectionString)
            {
                _connectionString = connectionString;
            }

            public void Connect()
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
            }

            public void Disconnect()
            {
                _connection.Close();
            }

            public void ExecuteSql(string sql)
            {
                var command = new MySqlCommand(sql, _connection);
                command.ExecuteNonQuery();
            }
        }
[Route("api/Todoitems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        /**() private readonly TodoContext _context;

         public TodoItemsController(TodoContext context)
         {
             _context = context;
         }

         // GET: api/TodoItems
         [HttpGet]
         public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
         {
             return await _context.TodoItems.ToListAsync();
         }

         // GET: api/TodoItems/5
         [HttpGet("{id}")]
         public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
         {
             var todoItem = await _context.TodoItems.FindAsync(id);

             if (todoItem == null)
             {
                 return NotFound();
             }

             return todoItem;
         }

         // PUT: api/TodoItems/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
         {
             if (id != todoItem.Id)
             {
                 return BadRequest();
             }

             _context.Entry(todoItem).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!TodoItemExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

         // POST: api/TodoItems
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
         {
             _context.TodoItems.Add(todoItem);
             await _context.SaveChangesAsync();

            // return CreatedAtAction("GetTodoItem", new { id = todoItem.ID }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
         }

         // DELETE: api/TodoItems/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteTodoItem(int id)
         {
             var todoItem = await _context.TodoItems.FindAsync(id);
             if (todoItem == null)
             {
                 return NotFound();
             }

             _context.TodoItems.Remove(todoItem);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool TodoItemExists(int id)
         {
             return _context.TodoItems.Any(e => e.Id == id);
         }**/

                private readonly DatabaseConnection _databaseConnection;

        public  TodoItemsController()
        {
            _databaseConnection = new DatabaseConnection("Server=127.0.0.1;Database=ApexRestaurantDB;Uid=root;Pwd=forlorn123X;");
            _databaseConnection.Connect();

        }

        [HttpGet]
        public string GetData()
        {
            // Execute a SQL query
            _databaseConnection.ExecuteSql("SELECT * FROM Customers");

            // Return some data
            return "Data retrieved from the database";
        }
    }
}
