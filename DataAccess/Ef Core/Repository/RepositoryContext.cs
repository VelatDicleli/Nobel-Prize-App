using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Ef_Core.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Award> Award { get; set; }
        public DbSet<Committee> Committee { get; set; }
        public DbSet<Expert> Expert { get; set; }
        public DbSet<Candidate_Organization> Candidate_Organization { get; set; }
        public DbSet<Candidate_Committee> Candidate_Committee { get; set; }
        public DbSet<Candidate_Award> Candidate_Award { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var organizations = new[]
    {
        new Organization { OrganizationId = 2, Name = "Stockholm Nobel Committee", Location = "Sweden", ContactInformation = "Info@nobellprize.se" },
        new Organization { OrganizationId = 3, Name = "Nobel Assembly at Karolinska Institutet", Location = "Sweden", ContactInformation = "nobelassembly@ki.se" },
        new Organization { OrganizationId = 4, Name = "Royal Swedish Academy of Sciences", Location = "Sweden", ContactInformation = "info@kva.se" },
        new Organization { OrganizationId = 5, Name = "Nobel Peace Center", Location = "Norway", ContactInformation = "post@nobelpeacecenter.org" },
        new Organization { OrganizationId = 6, Name = "The Nobel Foundation", Location = "Sweden", ContactInformation = "info@nobelprize.org" }

    };

            var candidates = new[]
                {
        new Candidate { CandidateId = 2, FirstName = "Marie", LastName = "Curie", CandidacyDate = new DateTime(1950, 5, 12), CandidacyNumber = 78586646, DateOfBirth = new DateTime(1867, 11, 7), Nationality = "Polish", FieldOfScience = "Chemistry" },
        new Candidate { CandidateId = 3, FirstName = "John", LastName = "Doe", CandidacyDate = new DateTime(1975, 9, 20), CandidacyNumber = 9864753, DateOfBirth = new DateTime(1950, 6, 15), Nationality = "American", FieldOfScience = "Medicine" },
        new Candidate { CandidateId = 4, FirstName = "Ada", LastName = "Lovelace", CandidacyDate = new DateTime(1988, 12, 5), CandidacyNumber = 3548468, DateOfBirth = new DateTime(1815, 12, 10), Nationality = "British", FieldOfScience = "Computer Science" },
        new Candidate { CandidateId = 5, FirstName = "Alan", LastName = "Turing", CandidacyDate = new DateTime(1954, 8, 25), CandidacyNumber = 235456, DateOfBirth = new DateTime(1912, 6, 23), Nationality = "British", FieldOfScience = "Mathematics" },
        new Candidate { CandidateId = 6, FirstName = "Marie", LastName = "Skłodowska", CandidacyDate = new DateTime(1921, 2, 18), CandidacyNumber = 9848546, DateOfBirth = new DateTime(1867, 11, 7), Nationality = "Polish", FieldOfScience = "Physics" },
        new Candidate { CandidateId = 7, FirstName = "Nikola", LastName = "Tesla", CandidacyDate = new DateTime(1910, 4, 30), CandidacyNumber = 78594546, DateOfBirth = new DateTime(1856, 7, 10), Nationality = "Serbian", FieldOfScience = "Engineering" },
        new Candidate { CandidateId = 8, FirstName = "Marie", LastName = "Curie", CandidacyDate = new DateTime(1903, 11, 9), CandidacyNumber = 65654478, DateOfBirth = new DateTime(1867, 11, 7), Nationality = "Polish", FieldOfScience = "Physics" },
        new Candidate { CandidateId = 9, FirstName = "Richard", LastName = "Feynman", CandidacyDate = new DateTime(1965, 7, 18), CandidacyNumber = 87546, DateOfBirth = new DateTime(1918, 5, 11), Nationality = "American", FieldOfScience = "Physics" },
        new Candidate { CandidateId = 10, FirstName = "Ada", LastName = "Yonath", CandidacyDate = new DateTime(2009, 12, 10), CandidacyNumber = 3546568, DateOfBirth = new DateTime(1939, 6, 22), Nationality = "Israeli", FieldOfScience = "Chemistry" },
        new Candidate { CandidateId = 11, FirstName = "Albert", LastName = "Einstein", CandidacyDate = new DateTime(1922, 2, 20), CandidacyNumber = 5654564, DateOfBirth = new DateTime(1879, 3, 14), Nationality = "Swiss", FieldOfScience = "Physics" },
        new Candidate { CandidateId = 12, FirstName = "Marie", LastName = "Curie", CandidacyDate = new DateTime(1905, 12, 6), CandidacyNumber = 78485546, DateOfBirth = new DateTime(1867, 11, 7), Nationality = "Polish", FieldOfScience = "Physics" }
                };


            var awards = new[]
            {
            new Award { AwardId = 1, DescriptorName = "Nobel Prize in Physics", Category = "Physics" },
            new Award { AwardId = 2, DescriptorName = "Nobel Prize in Chemistry", Category = "Chemistry" },
            new Award { AwardId = 3, DescriptorName = "Nobel Prize in Physiology or Medicine", Category = "Physiology or Medicine" },
            new Award { AwardId = 4, DescriptorName = "Fields Medal in Mathematics", Category = "Mathematics" },
            new Award { AwardId = 5, DescriptorName = "Turing Award in Computer Science", Category = "Computer Science" },
          

    };

            
            var committees = new[]
            {
            new Committee { CommitteeId = 1, CommitteeCategory = "Physics Committee" },
            new Committee { CommitteeId = 2, CommitteeCategory = "Chemistry Committee" },
            new Committee { CommitteeId = 3, CommitteeCategory = "Physiology and Medicine Committee" },
            new Committee { CommitteeId = 4, CommitteeCategory = "Mathematics Committee" },
            new Committee { CommitteeId = 5, CommitteeCategory = "Computer Science Committee" },
            new Committee { CommitteeId = 9, CommitteeCategory = "Physiology and Medicine Committee" },
            new Committee { CommitteeId = 8, CommitteeCategory = "Mathematics Committee" },
            new Committee { CommitteeId = 7, CommitteeCategory = "Computer Science Committee" },


    };

            
            var experts = new[]
            {
            new Expert { ExpertId = 1, ExpertFirstName = "John", ExpertLastName = "Smith", ExpertField = "Physics", CommitteeId = 1 },
            new Expert { ExpertId = 2, ExpertFirstName = "Emily", ExpertLastName = "Brown", ExpertField = "Chemistry", CommitteeId = 2 },
            new Expert { ExpertId = 3, ExpertFirstName = "Michael", ExpertLastName = "Johnson", ExpertField = "Physiology and Medicine", CommitteeId = 3 },
            new Expert { ExpertId = 4, ExpertFirstName = "David", ExpertLastName = "Williams", ExpertField = "Mathematics", CommitteeId = 4 },
            new Expert { ExpertId = 5, ExpertFirstName = "Sophia", ExpertLastName = "Davis", ExpertField = "Computer Science", CommitteeId = 5 },
            new Expert { ExpertId = 6, ExpertFirstName = "James", ExpertLastName = "Martinez", ExpertField = "Physics", CommitteeId =1 },
            new Expert { ExpertId = 7, ExpertFirstName = "Emma", ExpertLastName = "Wilson", ExpertField = "Chemistry", CommitteeId =2 },
            new Expert { ExpertId = 8, ExpertFirstName = "Alexander", ExpertLastName = "Anderson", ExpertField = "Physiology and Medicine", CommitteeId = 3 },
            new Expert { ExpertId = 9, ExpertFirstName = "Olivia", ExpertLastName = "Thomas", ExpertField = "Mathematics", CommitteeId =4 },
            new Expert { ExpertId = 10, ExpertFirstName = "Daniel", ExpertLastName = "Taylor", ExpertField = "Computer Science", CommitteeId = 5 },
            new Expert { ExpertId = 11, ExpertFirstName = "William", ExpertLastName = "Lee", ExpertField = "Physics", CommitteeId = 1 },
            new Expert { ExpertId = 12, ExpertFirstName = "Lily", ExpertLastName = "Garcia", ExpertField = "Chemistry", CommitteeId = 2 },
            new Expert { ExpertId = 13, ExpertFirstName = "Matthew", ExpertLastName = "Rodriguez", ExpertField = "Physiology and Medicine", CommitteeId = 3 },
            new Expert { ExpertId = 14, ExpertFirstName = "Sophie", ExpertLastName = "Hernandez", ExpertField = "Mathematics", CommitteeId = 4 },
            new Expert { ExpertId = 15, ExpertFirstName = "Ethan", ExpertLastName = "Young", ExpertField = "Computer Science", CommitteeId = 5 },
            new Expert { ExpertId = 16, ExpertFirstName = "Isabella", ExpertLastName = "Moore", ExpertField = "Physics", CommitteeId = 1 }

    };


            var candidateAwards = new[]
            {
            
            new Candidate_Award { CandidateId = 2, AwardId = 1 },
            new Candidate_Award { CandidateId = 3, AwardId = 2 },
            new Candidate_Award { CandidateId = 4, AwardId = 4 },
            new Candidate_Award { CandidateId = 5, AwardId = 2 },
            new Candidate_Award { CandidateId = 6, AwardId = 3 },
            new Candidate_Award { CandidateId = 7, AwardId = 5 },
            new Candidate_Award { CandidateId = 8, AwardId =3 },
            new Candidate_Award { CandidateId = 8, AwardId = 1 } };

            var candidateOrganizations = new[]
            {
                
                new Candidate_Organization { CandidateId = 2, OrganizationId = 2 },
                new Candidate_Organization { CandidateId = 3, OrganizationId = 3 },
                new Candidate_Organization { CandidateId =4, OrganizationId = 4 },
                new Candidate_Organization { CandidateId = 5, OrganizationId = 5 },
                new Candidate_Organization { CandidateId = 6, OrganizationId = 6 }
                
            };

            var candidateCommittees = new[]
            {
               
                new Candidate_Committee { CandidateId = 2, CommitteeId = 2, EvaluationDate = new DateTime(2023, 4, 16), Result = false },
                new Candidate_Committee { CandidateId = 3, CommitteeId = 3, EvaluationDate = new DateTime(2023, 4, 17), Result = true },
                new Candidate_Committee { CandidateId = 4, CommitteeId = 4, EvaluationDate = new DateTime(2023, 4, 18), Result = false },
                new Candidate_Committee { CandidateId = 5, CommitteeId = 5, EvaluationDate = new DateTime(2023, 4, 19), Result = true },
                new Candidate_Committee { CandidateId = 6, CommitteeId = 1, EvaluationDate = new DateTime(2023, 4, 20), Result = false },
                new Candidate_Committee { CandidateId = 7, CommitteeId = 5, EvaluationDate = new DateTime(2023, 4, 21), Result = true },
                new Candidate_Committee { CandidateId = 8, CommitteeId = 1, EvaluationDate = new DateTime(2023, 4, 22), Result = false },
                new Candidate_Committee { CandidateId = 9, CommitteeId = 5, EvaluationDate = new DateTime(2023, 4, 23), Result = true }
                
            };

            modelBuilder.Entity<Candidate>().HasData(candidates);
            modelBuilder.Entity<Candidate>().HasIndex(c => c.CandidacyNumber).IsUnique();

            modelBuilder.Entity<Candidate_Committee>().HasData(candidateCommittees);
            modelBuilder.Entity<Candidate_Organization>().HasData(candidateOrganizations);
            modelBuilder.Entity<Candidate_Award>().HasData(candidateAwards);
            modelBuilder.Entity<Organization>().HasData(organizations);
            modelBuilder.Entity<Organization>().HasIndex(o => o.ContactInformation).IsUnique();

            modelBuilder.Entity<Award>().HasData(awards);
            modelBuilder.Entity<Award>().HasIndex(a => a.DescriptorName).IsUnique();
            
            modelBuilder.Entity<Committee>().HasData(committees);
            
            modelBuilder.Entity<Expert>().HasData(experts);
            

            
            

            modelBuilder.Entity<Candidate_Organization>()
                .HasKey(co => new { co.CandidateId, co.OrganizationId });
            modelBuilder.Entity<Candidate_Organization>()
                .HasOne(ca => ca.Candidate)
                .WithMany(or => or.CandidateOrganizations)
                .HasForeignKey(ca => ca.CandidateId);
            modelBuilder.Entity<Candidate_Organization>()
                .HasOne(or=>or.Organization)
                .WithMany(ca=>ca.OrganizationCandidates)
                .HasForeignKey(or=> or.OrganizationId); 
                

            modelBuilder.Entity<Candidate_Committee>()
                .HasKey(cc => new { cc.CandidateId, cc.CommitteeId });
            modelBuilder.Entity<Candidate_Committee>()
                .HasOne(cc => cc.Candidate)
                .WithMany(co=>co.CandidateCommittees)
                .HasForeignKey(cc=> cc.CandidateId);
            modelBuilder.Entity<Candidate_Committee>()
                .HasOne(co=> co.Committee)
                .WithMany(cc=>cc.CommitteeCandidates)
                .HasForeignKey(co=> co.CommitteeId);

            
            modelBuilder.Entity<Candidate_Award>()
                .HasKey(ca => new { ca.CandidateId, ca.AwardId });
            modelBuilder.Entity<Candidate_Award>()
                .HasOne(ca=>ca.Candidate)
                .WithMany(aw=>aw.CandidateAwards)
                .HasForeignKey(ca=>ca.CandidateId);

            modelBuilder.Entity<Candidate_Award>()
                .HasOne(aw => aw.Award)
                .WithMany(ca => ca.CandidateAwards)
                .HasForeignKey(aw => aw.AwardId);

            

        }
    }

    
}
