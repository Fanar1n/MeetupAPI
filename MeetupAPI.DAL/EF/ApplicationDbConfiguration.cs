using MeetupAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.DAL.EF
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Description)
                .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Plan)
                .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Place)
                .IsRequired()
            .HasMaxLength(50);

            builder.Property(u => u.Speaker)
                .IsRequired()
            .HasMaxLength(50);

            builder.Property(u => u.Organizer)
                .IsRequired()
            .HasMaxLength(50);

            builder.Property(u => u.DateTimeOfThe)
                .HasColumnType("date");
        }
    }
}
