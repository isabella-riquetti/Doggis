﻿using Doggis.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public interface IPetRepository : IRepositoryBase<Doggis.Data.Models.Pet>
    {
    }
}
