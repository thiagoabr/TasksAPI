using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Data.Mappings
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(task => task.Id);

            builder.Property(task => task.Name).HasMaxLength(150).IsRequired();
            builder.Property(task => task.Description).HasMaxLength(250).IsRequired();
            builder.Property(task => task.Date).HasColumnType("date").IsRequired();
            builder.Property(task => task.Time).HasColumnType("time").IsRequired();

            builder.HasOne(task => task.User)
                .WithMany(user => user.Tasks)
                .HasForeignKey(task => task.UserId);
        }
    }
}
