using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using ToDoList.Data;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyDatabaseContext _databaseContext;
        public List<ToDoModel> TodoModelList { get; set; }
        public List<DoneModel> DoneModelList { get; set; }


        public IndexModel(ILogger<IndexModel> logger, MyDatabaseContext context)
        {
            TodoModelList = new List<ToDoModel>();
            DoneModelList = new List<DoneModel>();
            _databaseContext = context;
            _logger = logger;
        }

        /// <summary>
        /// Get action - load ToDo and Done Models and sort them by date
        /// </summary>
        public void OnGet()
        {
            try
            {
                TodoModelList = _databaseContext.ToDoModelCollection.OrderBy(a => a.ToDoDate).ToList();
                DoneModelList = _databaseContext.DoneModelCollection.OrderBy(a => a.ToDoDate).ToList();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a new task - new instance of ToDoModel and save it to database
        /// </summary>
        /// <param name="description"> title of task </param>
        /// <param name="content">details of task</param>
        /// <param name="toDoDate">time when to complete task</param>
        /// <returns>redirect to OnGet action</returns>
        public async Task<IActionResult> OnPostCreateAsync(string description, string content, DateTime toDoDate)
        {
            try {
                var toDoModel = new ToDoModel()
                {
                    Description = description ?? "",
                    Content = content ?? "",
                    ToDoDate = toDoDate,
                };

                toDoModel.IP = HttpContext.Connection.RemoteIpAddress.ToString() ?? "unknown";

                _databaseContext.Add(toDoModel);
                await _databaseContext.SaveChangesAsync();

                return RedirectToAction("OnGet");

            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// delete selected ToDoModel from database
        /// </summary>
        /// <param name="id">primary id of ToDoModel</param>
        /// <returns>redirect to OnGet action</returns>
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var toDoModel = await _databaseContext.ToDoModelCollection.FindAsync(id);

            if (toDoModel is not null)
            {
                _databaseContext.ToDoModelCollection.Remove(toDoModel);
                await _databaseContext.SaveChangesAsync();
            }

            return RedirectToAction("OnGet");
        }

        /// <summary>
        /// transfer Task from ToDo to Done
        /// </summary>
        /// <param name="id">primary id of ToDoModel</param>
        /// <returns>redirect to OnGet action</returns>
        public async Task<IActionResult> OnPostDoneAsync(int id)
        {
            var toDoModel = await _databaseContext.ToDoModelCollection.FindAsync(id);

            if (toDoModel is not null)
            {
                _databaseContext.ToDoModelCollection.Remove(toDoModel);

                var doneModel = new DoneModel()
                {
                    Description = toDoModel.Description,
                    Content = toDoModel.Content,
                    ToDoDate = toDoModel.ToDoDate,
                    DoneTime = DateTime.Now,
                    IP = toDoModel.IP

                };
                await _databaseContext.DoneModelCollection.AddAsync(doneModel);
            }

            await _databaseContext.SaveChangesAsync();
            return RedirectToAction("OnGet");

        }

        /// <summary>
        /// transfer Task from Done back to Todo
        /// </summary>
        /// <param name="id">primary id of DoneModel</param>
        /// <returns>redirect to OnGet action</returns>
        public async Task<IActionResult> OnPostUndoneAsync(int id)
        {
            var unDoneModel = await _databaseContext.DoneModelCollection.FindAsync(id);

            if (unDoneModel is not null)
            {
                _databaseContext.DoneModelCollection.Remove(unDoneModel);
                await _databaseContext.SaveChangesAsync();


                var doneModel = new ToDoModel()
                {
                    Description = unDoneModel.Content,
                    Content = unDoneModel.Content,
                    ToDoDate = unDoneModel.ToDoDate,
                    IP = unDoneModel.IP
                };

                await _databaseContext.ToDoModelCollection.AddAsync(doneModel);
                await _databaseContext.SaveChangesAsync();
            }

            return RedirectToAction("OnGet");
        }

        /// <summary>
        /// delete selected DoneModel from database
        /// </summary>
        /// <param name="id">primary id of DoneModel</param>
        /// <returns>redirect to OnGet action</returns>
        public async Task<IActionResult> OnPostDelete2Async(int id) 
        {
            var doneModel = await _databaseContext.DoneModelCollection.FindAsync(id);

            if (doneModel is not null)
            {
                _databaseContext.Remove(doneModel);
                await _databaseContext.SaveChangesAsync();
            }

            return RedirectToAction("OnGet");
        }
    }
}