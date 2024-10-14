using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group1.WebApp.Models;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDoItem> toDoItems = new List<ToDoItem>();

        public ToDoController()
        { 
            // ha nincs benne elem, akkor rakjunk bele (kamu adatbázis)
            if (!toDoItems.Any())
            {
                toDoItems.Add(new ToDoItem()
                {
                    ID = 1,
                    IsCompleted = false,
                    Title = "Mosni"
                });
                toDoItems.Add(new ToDoItem()
                {
                    ID = 2,
                    IsCompleted = true,
                    Title = "Felkészülni az órára"
                });
                toDoItems.Add(new ToDoItem()
                {
                    ID = 3,
                    IsCompleted = false,
                    Title = "Főzés"
                });
            }
        }

        /// <summary>
        /// Ez a végpont a /ToDo url-en lesz elérhető
        /// </summary>
        /// <returns>A ToDo (View) nézetet</returns>
        public IActionResult Index()
        {
            return View(toDoItems);
        }

        // /ToDo/Create url
        public IActionResult Create()
        {
            return View();
        }

        // /ToDo/Edit
        public IActionResult Edit(int id)
        {
            ToDoItem editedItem = toDoItems.FirstOrDefault(x => x.ID == id);
            return View(editedItem);
        }

        public IActionResult Delete(int id) 
        {
            var deletedItem = toDoItems.FirstOrDefault(x => x.ID == id);
            if (deletedItem != null)
            {
                toDoItems.Remove(deletedItem);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddToDo(ToDoItem item)
        {
            item.ID = toDoItems.Any() ? toDoItems.Last().ID + 1 : 1;
            toDoItems.Add(item);
            return RedirectToAction("Index");
        }

        public IActionResult EditToDo(ToDoItem item)
        {
            ToDoItem editedItem = toDoItems.FirstOrDefault(x => x.ID == item.ID);
            if (editedItem != null)
            {
                editedItem.Title = item.Title;
                editedItem.IsCompleted = item.IsCompleted;
            }

            return RedirectToAction("Index");
        }
    }
}
