using Network.Enums;
using System;
using System.ComponentModel;
using System.Web;

namespace Network.Views.ViewModels
{
    public class UserViewModel
    {
    }

    public class AddUserViewModel
    {
        public Guid Id { get; set; }
        public string AspUserId { get; set; }
        public Roles TypeUser { get; set; }

        public string Name { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
    }

    public class UserListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }

    public class UserIndexViewModel
    {
        public Guid Id { get; set; }
        public string AspUserId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }

        [DisplayName("Образование")]
        public string Type { get; set; }

        [DisplayName("Учреждение")]
        public string Institution { get; set; }

        [DisplayName("Специальность")]
        public string Specialization { get; set; }

        [DisplayName("Год начала")]
        public Nullable<System.DateTime> StartYear { get; set; }
        [DisplayName("Год окончания")]
        public Nullable<System.DateTime> GradYear { get; set; }

    }
}
