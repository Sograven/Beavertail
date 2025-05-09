using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storge.Core.Data.Contexts;

#nullable disable

namespace Storge.Core.Migrations
{
    [DbContext(typeof(AllUsersContext))]
    partial class AllUsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");
#pragma warning restore 612, 618
        }
    }
}
