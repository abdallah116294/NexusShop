using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Nexus.DataAccess.Data;
using Nexus.DataAccess.Repository.IRepository;
using Nexus.Models;
using Nexus.Models.Models;
namespace NexusShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //Add DbContext objct and Inject it using th constructor
       // removeiy and access the ICategoryRepositor  //private readonly ApplicationDbContext _applicationDbContext;
       private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //Get the list of categories from the database using the DbContext
            //Get all categories from Db using  the repository
            var categories = _unitOfWork.CategoryRepository.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View("CreateCategory");
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplatOrder.ToString()) 
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match the Name");
            }
            if (category.Name is not null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError(string.Empty, "Test is invalid value ");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["Message"] = "Add Succesfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorAdd"] = "Data not vaild";
                return View("CreateCategory",category);
            }
        }
        public IActionResult Edit(int?id) {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CategoryRepository.Get(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }     
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplatOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match the Name");
            }
            if (category.Name is not null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError(string.Empty, "Test is invalid value ");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.update(category);
                _unitOfWork.Save();
                TempData["Message"] = "Update Succesfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorAdd"] = "Data not vaild";
                return View("CreateCategory", category);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            } 
            var category = _unitOfWork.CategoryRepository.Get(ui=>ui.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
          
            if (category==null)
            {
                return NotFound();  
            }

            else
            {
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.Save();
                TempData["Message"] = "Remove Succesfully";
                return RedirectToAction(nameof(Index));
            }
          
        }

    }
}
