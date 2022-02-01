using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoAPI.API.Models; // Added for access to the DTO's
using ToDoAPI.DATA.EF; // Access to the EF layer
using System.Web.Http.Cors; // Added for access to modify the CORS funcitonality in this controller

namespace ToDoAPI.API.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToDoController : ApiController
    {

        ToDoEntities db = new ToDoEntities();

        public IHttpActionResult GetToDos()
        {
            List<ToDoViewModel> todos = db.TodoItems.Include("TodoItem").Select(t => new ToDoViewModel()
            {
                TodoId = t.TodoId,
                Action = t.Action,
                Details = t.Details,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.Category.CategoryId,
                    Name = t.Category.Name,
                    Description = t.Category.Description
                }

            }).ToList();

            if (todos.Count == 0)
            {
                return NotFound(); // 404 Error
            }

            return Ok(todos); // 200 sucess code and pass todo into the Ok response

        } // End GetTodos()

        // api/todo/id - Get Todo (READ)
        public IHttpActionResult GetTodo(int id)
        {
            ToDoViewModel todo = db.TodoItems.Include("Category").Where(t => t.TodoId == id).Select(t => new ToDoViewModel()
            {
                TodoId = t.TodoId,
                Action = t.Action,
                Details = t.Details,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.Category.CategoryId,
                    Name = t.Category.Name,
                    Description = t.Category.Description
                }
            }).FirstOrDefault();

            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        } // End GetTodo

        // POST - Create functionality
        // api/todo (HttpPost)
        public IHttpActionResult PostTodo(ToDoViewModel todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            TodoItem newTodoItem = new TodoItem()
            {

                Action = todo.Action,
                Details = todo.Details,
                Done = todo.Done,
                CategoryId = todo.CategoryId
            };

            db.TodoItems.Add(newTodoItem);
            db.SaveChanges();
            return Ok(newTodoItem);
        } // End PostTodo()

        // PUT = Edit
        // api/todo (HttpPut)
        public IHttpActionResult PutTodo(ToDoViewModel todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TodoItem existingTodo = db.TodoItems.Where(t => t.TodoId == todo.TodoId).FirstOrDefault();

            if (existingTodo != null)
            {
                existingTodo.TodoId = todo.TodoId;
                existingTodo.Action = todo.Action;
                existingTodo.Details = todo.Details;
                existingTodo.Done = todo.Done;
                existingTodo.CategoryId = todo.CategoryId;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        } // End PutTodo()

        // api/todo/id
        public IHttpActionResult DeleteTodo(int id)
        {
            TodoItem todo = db.TodoItems.Where(t => t.TodoId == id).FirstOrDefault();

            if (todo != null)
            {
                db.TodoItems.Remove(todo);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        } // End Delete

        // dispose of any connections to db after we are done
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    } // End class
} // End namespace
