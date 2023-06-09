﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211213150029_MigEntrepriseId")]
    partial class MigEntrepriseId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Cagnotte", b =>
                {
                    b.Property<int>("CagnotteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateLimite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SommeDemandée")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CagnotteId");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Cagnotte");
                });

            modelBuilder.Entity("Domain.Entreprise", b =>
                {
                    b.Property<int>("EntrepriseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresseEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEntreprise")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntrepriseId");

                    b.ToTable("Entreprise");
                });

            modelBuilder.Entity("Domain.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MailParticipant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Domain.Participation", b =>
                {
                    b.Property<int>("CagnotteFk")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantFk")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.HasKey("CagnotteFk", "ParticipantFk");

                    b.HasIndex("ParticipantFk");

                    b.ToTable("Participation");
                });

            modelBuilder.Entity("Domain.Cagnotte", b =>
                {
                    b.HasOne("Domain.Entreprise", "Entreprise")
                        .WithMany("Cagnottes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("Domain.Participation", b =>
                {
                    b.HasOne("Domain.Cagnotte", "Cagnotte")
                        .WithMany("Participantions")
                        .HasForeignKey("CagnotteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Participant", "Participant")
                        .WithMany("Participations")
                        .HasForeignKey("ParticipantFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cagnotte");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Domain.Cagnotte", b =>
                {
                    b.Navigation("Participantions");
                });

            modelBuilder.Entity("Domain.Entreprise", b =>
                {
                    b.Navigation("Cagnottes");
                });

            modelBuilder.Entity("Domain.Participant", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}
