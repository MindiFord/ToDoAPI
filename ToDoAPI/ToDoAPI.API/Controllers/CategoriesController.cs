using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoAPI.API.Models;
using ToDoAPI.DATA.EF;
using System.Web.Http.Cors;

namespace ToDoAPI.API.Controllers
{

    // Enable Cors
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {

        // Create object to connect to db
        ToDoEntities db = new ToDoEntities();

        // api/categories
        public IHttpActionResult GetCategories()
        {
            List<CategoryViewModel> categories = db.Categories.Include("Category").Select(c => new CategoryViewModel()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            }).ToList();

            if (categories.Count == 0)
            {
                return NotFound();
            }

            return Ok(categories);

        } // End GetCategories()

        // api/category/id
        public IHttpActionResult GetCategory(int id)
        {
            CategoryViewModel category = db.Categories.Where(c => c.CategoryId == id).Select(c => new CategoryViewModel()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            }).FirstOrDefault();

            if (category == null)
                return NotFound();

            return Ok(category);

        } // End GetCategory()

        // POST - Create functionality
        // api/category (HttpPost)
        public IHttpActionResult PostCategory(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            Category newCategory = new Category()
            {
                Name = category.Name,
                Description = category.Description
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();
            return Ok(newCategory);
        } // End PostCategory()

        // PUT
        // api/category (HttpPut)
        public IHttpActionResult PutCategory(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Category existingCategory = db.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();

            if (existingCategory != null)
            {
                existingCategory.CategoryId = category.CategoryId;
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        } // End PutCategory()
    
        // api/category/id
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Where(c =>
            c.CategoryId == id).FirstOrDefault();

            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        } // End Delete

        // Dispose of any connections to db after done
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
