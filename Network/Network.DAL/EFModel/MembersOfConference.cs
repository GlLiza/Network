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
    
    public partial class MembersOfConference
    {
        public System.Guid Id { get; set; }
        public System.Guid ConferenceId { get; set; }
        public System.Guid UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
