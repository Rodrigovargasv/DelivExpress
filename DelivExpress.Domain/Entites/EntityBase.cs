using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Domain.Entites
{
    // Id compartilhado entre class com relacionamento
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
