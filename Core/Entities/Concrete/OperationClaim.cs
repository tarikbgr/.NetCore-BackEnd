﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        //Kullanıcı Rolleri
        public int Id { get; set; }
        public string Name { get; set; }
    }
}