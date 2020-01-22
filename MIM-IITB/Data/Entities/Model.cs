using System;

namespace MIM_IITB.Data.Entities
{
    public class Model
    {
        public Guid Id { get; set; } = new Guid();
        public bool IsDeleted { get; set; } = false;
    }
}