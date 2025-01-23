//using GreenHost.Models;
//using GreenHost.ViewModels.AccountVMs;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//public IActionResult Login()
//{
//    return View();
//}
//[HttpPost]
//public async Task<IActionResult> Login(LoginVm vm, string? returnUrl = null)
//{
//    if (IsAuthenticated) RedirectToAction("Index", "Home");
//    if (!ModelState.IsValid) return View();
//    AppUser? user = null;
//    if (vm.UsernameOrEmail.Contains("@"))
//    {
//        user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
//    }
//    else
//    {
//        user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
//    }

//    if (user is null)
//    {
//        ModelState.AddModelError("", "Username Or Password is wrong!!!");
//        return View();
//    }
//    var password = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
//    if (!password.Succeeded)
//    {
//        if (password.IsLockedOut)
//        {
//            ModelState.AddModelError("", "Wait untill" + user.LockoutEnd!.Value.ToString("yyyy-MM-dd HH:mm:ss"));
//        }
//        if (password.IsNotAllowed)
//        {
//            ModelState.AddModelError("", "Username or password is wrong");
//        }
//    }
//    if (string.IsNullOrWhiteSpace(returnUrl))
//    {
//        if (await _userManager.IsInRoleAsync(user, "Admin"))
//        {
//            return RedirectToAction("Index", new { Controller = "Dashbard", Area = "Admin" });
//        }
//        return RedirectToAction("Index", "Home");
//    }
//    return RedirectToAction("Index", "Home");
//}
//[Authorize]
//public async Task<IActionResult> Logout()
//{
//    await _signInManager.SignOutAsync();
//    return RedirectToAction(nameof(Login));
//}