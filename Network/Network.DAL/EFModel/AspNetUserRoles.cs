//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Network.DAL.EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int Id { get; set; }
    
        public virtual AspNetRoles AspNetRoles { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
