using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarea.Persistence.Database.Models;

namespace Tarea.Persistence.Database.Configuration
{
    public class TareaConfiguration
    {
        public TareaConfiguration(EntityTypeBuilder<TareaModel> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.IdTarea);

        }
    }
}
