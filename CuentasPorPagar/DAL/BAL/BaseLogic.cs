﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.BAL
{
    public class BaseLogic
    {
        public virtual DataTable GetAll(string command)
        {
            return DbContext.Instance.GetAll(command);
        }
    }
}
