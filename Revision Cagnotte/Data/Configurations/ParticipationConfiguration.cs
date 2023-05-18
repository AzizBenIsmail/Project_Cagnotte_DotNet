using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ParticipationConfiguration : IEntityTypeConfiguration<Participation>
    {
        public void Configure(EntityTypeBuilder<Participation> builder)
        {
            builder.HasKey(f => new
            {

                f.CagnotteFk,
                f.ParticipantFk
            });

            builder.HasOne(f => f.Cagnotte)
            .WithMany(c => c.Participantions)
            .HasForeignKey(f => f.CagnotteFk);

            builder.HasOne(f => f.Participant)
           .WithMany(p => p.Participations)
           .HasForeignKey(f => f.ParticipantFk);
        }
    }
}