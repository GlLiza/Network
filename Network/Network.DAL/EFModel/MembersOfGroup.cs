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
    
    public partial class MembersOfGroup
    {
        public System.Guid Id { get; set; }
        public System.Guid GroupId { get; set; }
        public System.Guid MembersId { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}