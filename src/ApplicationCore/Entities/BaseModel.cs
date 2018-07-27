using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class BaseModel : IEntity<int>
    {
        public int Id { get; set; }
    }
}
