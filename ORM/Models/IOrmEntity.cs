﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public interface IOrmEntity
    {
        int Id { get; set; }
    }
}
