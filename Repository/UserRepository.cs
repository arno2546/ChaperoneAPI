﻿using Chaperone_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chaperone_API.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
    }
}