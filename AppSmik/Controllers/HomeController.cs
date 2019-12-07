namespace CoordinatorSmikServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using CoordinatorSmikServer.Converters;
    using CoordinatorSmikServer.Models.ViewModels;
    using LibRepo.Contract;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
       private readonly IUnitOfWork context;

       public HomeController(IUnitOfWork context)
        {
            this.context = context;
        }

       [Authorize]
       public async Task<IActionResult> Index()
       {
            List<ProjectInfoViewModel> projects = new List<ProjectInfoViewModel>();
            var items = await this.context.ProjectRepository.GetAllProjectAsync();
            if (items.Any())
            {
                foreach (var item in items)
                {
                    ProjectInfoViewModel project = new ProjectInfoViewModel
                    {
                        Id = item.Id,
                        Name = this.GetCulture(item.NameRu, item.NameEn),
                    };

                    project.Image = new ImageViewModel();

                    var image = await this.context.ImageRepository.GetTitleImgAsync(item.Id);

                    if (image != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(image.Data);
                        string imageDataURL = string.Format("data:{0};base64,{1}", image.ContentType, imageBase64Data);
                        project.Image.TitleImage = imageDataURL;
                    }

                    project.ConstructionState = Converter.ToConstructionState(item.ConstructionState);
                    project.SystemState = Converter.ToSystemState(item.SystemState);
                    project.UpdateDate = item.UpdateDate;

                    projects.Add(project);
                }
            }

            return this.View(projects);
        }

       [HttpGet]
       public IActionResult SetLanguage(string lang, string returnUrl)
        {
            if (lang == "ru")
            {
                lang = "en";
            }
            else
            {
                lang = "ru";
            }

            this.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return this.LocalRedirect(returnUrl);
        }

       public IActionResult Privacy()
        {
            return this.View();
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

       private string GetCulture(string ru, string en)
        {
            string result = string.Empty;
            
            string nameculture = this.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            
            if (nameculture == "ru")
            {
               result = ru;
            }
            else
            {
               result = en;
            }
            
            return result;
        }
    }
}
