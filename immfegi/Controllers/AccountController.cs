using immfegi.Data;
using immfegi.Models;
using immfegi.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace immfegi.Controllers;

public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			var response = new LoginViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
				return View(loginViewModel);

			var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

			if (user != null)
			{
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
				if (passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Home");
					}
				}
				TempData["Error"] = "Неверные данные. Попробуйте еще раз";
				return View(loginViewModel);
			}
			TempData["Error"] = "Неверные данные";
			return View(loginViewModel);
		}

		public IActionResult Register()
		{
			var response = new RegisterViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid) 
				return View(registerViewModel);

			var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);

			if (user != null)
			{
				TempData["Error"] = "Этот адрес электронной почты уже используется";
				return View(registerViewModel);
			}

			var newApplicationUser = new ApplicationUser()
			{
				Email = registerViewModel.EmailAddress,
				UserName = registerViewModel.EmailAddress
			};

			if(registerViewModel.Password.Length < 5)
			{
				TempData["Error"] = "Минимальная длина пароля - 6 символов";
				return View(registerViewModel);
			}
			var newUserResponse = await _userManager.CreateAsync(newApplicationUser, registerViewModel.Password);

			if (newUserResponse.Succeeded)
			{
				await _userManager.AddToRoleAsync(newApplicationUser, ApplicationUserRoles.Student);
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}