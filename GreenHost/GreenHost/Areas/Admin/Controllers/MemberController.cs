using GreenHost.Contexts;
using GreenHost.Models;
using GreenHost.ViewModels.MemberVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenHost.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly GreenHostDbContext _context;

        public MemberController(GreenHostDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Members.Include(m => m.Department).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Department = await _context.Department.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        public async Task<IActionResult> Info(int? id) 
        {
            if (id == null) return BadRequest();
            return View(await _context.Members.Include(m => m.Department).FirstOrDefaultAsync(x => x.Id ==id));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Members.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return NotFound();
            _context.Members.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateVM vm)
        {
            return View();
            //        if (vm.ImageUrl != null)
            //        {
            //            if (!vm.ImageUrl.IsValidType("image"))
            //                ModelState.AddModelError("File", "File must be an image");
            //            if (!vm.ImageUrl.IsValidSize(400))
            //                ModelState.AddModelError("File", "File must be less than 400kb");
            //        }

            //        if (!ModelState.IsValid)
            //        {
            //            ViewBag.Categories = await _context.Department.Where(x => !x.IsDeleted).ToListAsync();
            //            return View(vm);
            //        }

            //        if (!await _context.Department.AnyAsync(x => x.Id == vm.DepartmentId && !x.IsDeleted))
            //        {
            //            ViewBag.Categories = await _context.Department.Where(x => !x.IsDeleted).ToListAsync();
            //            ModelState.AddModelError("DepartmentId", "Department not found or deleted");
            //            return View(vm);
            //        }

            //        var productImagePath = Path.Combine(_env.WebRootPath, "imgs", "agents");
            //        Member memb = new Member
            //        {
            //            Fullname=vm.FullName,
            //            Image=vm.Image,
            //            DepartmentId=vm.DepartmentId

            //        };
            //        if (vm.Image != null)
            //        {
            //            memb.Image = await vm.Image.UploadAsync(productImagePath);
            //        }

            //        await _context.Members.AddAsync(memb);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction("Index");
            //    }
            //    public async Task<IActionResult> Update(int? id)
            //    {
            //        if (id == null) return BadRequest();
            //        var data = await _context.Agents.Where(x => x.Id == id).Select(x => new AgentUpdateVM
            //        {
            //            FullName = x.FullName,
            //            DepartmentID = x.DepartmenId,
            //            ImageUrl = x.ImageUrl,
            //        }).FirstOrDefaultAsync();
            //        if (data == null) return NotFound();
            //        ViewBag.Department = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
            //        return View(data);
            //    }
            //    [HttpPost]
            //    public async Task<IActionResult> Update(int? id, AgentUpdateVM vm)
            //    {
            //        if (id == null) return BadRequest();
            //        var data = await _context.Agents.Where(x => x.Id == id).FirstOrDefaultAsync();
            //        if (data == null) return NotFound();
            //        if (vm.Image is not null)
            //        {
            //            vm.Id = data.Id;
            //            vm.FullName = data.FullName;
            //            vm.DepartmentID = data.DepartmenId;
            //            vm.ImageUrl = data.ImageUrl;
            //            await _context.SaveChangesAsync();
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    public async Task<IActionResult> Delete(int? id)
            //    {
            //        if (id == null) return BadRequest();
            //        var data = await _context.Agents.Where(x => x.Id == id).FirstOrDefaultAsync();
            //        if (data == null) return NotFound();
            //        _context.Agents.Remove(data);
            //        _context.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
        }
    }
}