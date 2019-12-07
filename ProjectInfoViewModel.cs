namespace CoordinatorSmikServer.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CoordinatorSmikServer.Models.Enums;

    public class ProjectInfoViewModel
    {
        [Display(Name="Ин")]
        public Guid Id { get; set; }

        [Display(Name="Название")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Начало эксплуатации")]

        [DataType(DataType.Date)]
        public DateTime? StartedDate { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Статус системы")]
        public SystemState SystemState { get; set; }

        [Display(Name = "Статус конструкции")]
        public ConstructionState ConstructionState { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата обновления")]
        public DateTime? UpdateDate { get; set; }

        public IEnumerable<GroupViewModel> Groups { get; set; }

        public ImageViewModel Image { get; set; }

        [Display(Name = "Режим работы Web API")]
        public ProjectApiState ApiState { get; set; }
    }
}
