using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TesteProgramacao.Data.Context
{
    public class CatalagoDbContext : IdentityDbContext
    {
        public CatalagoDbContext(DbContextOptions<CatalagoDbContext> options) : base(options)
        {
        }        
    }

    
}

