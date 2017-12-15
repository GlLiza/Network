using Network.Enums;
using System;
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

        //public string TypeAducation { get; set; }
        //public string FormAducation { get; set; }
        //public string Institution { get; set; }
        //public string Specialization { get; set; }
        //public int YearBegin { get; set; }
        //public int YearGraduation { get; set; }

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
        public Roles TypeUser { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

    }
}
