﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
