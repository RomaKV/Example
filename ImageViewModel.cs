namespace CoordinatorSmikServer.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class ImageViewModel
    {
        public Guid Id { get; set; }

        public string TitleImage { get; set; }

        [Display(Name = "Загрузка фотографии")]
        public IFormFile LoadImage { get; set; }
    }
}
