using System;
using System.Collections.Generic;
using System.Text;

namespace TesteProgramacao.ViewModels
{
    public abstract class EntityViewModels
    {
        protected EntityViewModels()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
