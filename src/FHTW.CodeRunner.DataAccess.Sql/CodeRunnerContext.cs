// <copyright file="CodeRunnerContext.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using FHTW.CodeRunner.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    public partial class CodeRunnerContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeRunnerContext"/> class.
        /// </summary>
        public CodeRunnerContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeRunnerContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public CodeRunnerContext(DbContextOptions<CodeRunnerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Collection> Collection { get; set; }

        public virtual DbSet<CollectionExercise> CollectionExercise { get; set; }

        public virtual DbSet<CollectionLanguage> CollectionLanguage { get; set; }

        public virtual DbSet<CollectionTag> CollectionTag { get; set; }

        public virtual DbSet<Comment> Comment { get; set; }

        public virtual DbSet<Difficulty> Difficulty { get; set; }

        public virtual DbSet<Exercise> Exercise { get; set; }

        public virtual DbSet<ExerciseBody> ExerciseBody { get; set; }

        public virtual DbSet<ExerciseHeader> ExerciseHeader { get; set; }

        public virtual DbSet<ExerciseLanguage> ExerciseLanguage { get; set; }

        public virtual DbSet<ExerciseTag> ExerciseTag { get; set; }

        public virtual DbSet<ExerciseVersion> ExerciseVersion { get; set; }

        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }

        public virtual DbSet<Rating> Rating { get; set; }

        public virtual DbSet<Tag> Tag { get; set; }

        public virtual DbSet<TestCase> TestCase { get; set; }

        public virtual DbSet<TestSuite> TestSuite { get; set; }

        public virtual DbSet<WrittenLanguage> WrittenLanguage { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Collection)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_fk_user_id_fkey");
            });

            modelBuilder.Entity<CollectionExercise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkCollectionLanguage)
                    .WithMany(p => p.CollectionExercise)
                    .HasForeignKey(d => d.FkCollectionLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_exercise_fk_collection_language_id_fkey");

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.CollectionExercise)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_exercise_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkProgrammingLanguage)
                    .WithMany(p => p.CollectionExercise)
                    .HasForeignKey(d => d.FkProgrammingLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_exercise_fk_programming_language_id_fkey");

                entity.HasOne(d => d.FkWrittenLanguage)
                    .WithMany(p => p.CollectionExercise)
                    .HasForeignKey(d => d.FkWrittenLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_exercise_fk_written_language_id_fkey");
            });

            modelBuilder.Entity<CollectionLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkCollection)
                    .WithMany(p => p.CollectionLanguage)
                    .HasForeignKey(d => d.FkCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_language_fk_collection_id_fkey");
            });

            modelBuilder.Entity<CollectionTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkCollection)
                    .WithMany(p => p.CollectionTag)
                    .HasForeignKey(d => d.FkCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_tag_fk_collection_id_fkey");

                entity.HasOne(d => d.FkTag)
                    .WithMany(p => p.CollectionTag)
                    .HasForeignKey(d => d.FkTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_tag_fk_tag_id_fkey");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_fk_user_id_fkey");
            });

            modelBuilder.Entity<Difficulty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.Difficulty)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("difficulty_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Difficulty)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("difficulty_fk_user_id_fkey");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_fk_user_id_fkey");
            });

            modelBuilder.Entity<ExerciseBody>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExerciseLanguage)
                    .WithMany(p => p.ExerciseBody)
                    .HasForeignKey(d => d.FkExerciseLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_body_fk_exercise_language_id_fkey");

                entity.HasOne(d => d.FkProgrammingLanguage)
                    .WithMany(p => p.ExerciseBody)
                    .HasForeignKey(d => d.FkProgrammingLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_body_fk_programming_language_id_fkey");

                entity.HasOne(d => d.FkTestSuite)
                    .WithMany(p => p.ExerciseBody)
                    .HasForeignKey(d => d.FkTestSuiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_body_fk_test_suite_id_fkey");

                entity.HasCheckConstraint(
                    "value_constraint_exercise_allow_files",
                    $"allow_files >= {Entities.ExerciseBody.MinAllowedFilesVal} AND allow_files <= {Entities.ExerciseBody.MaxAllowedFilesVal}");

                entity.HasCheckConstraint(
                    "value_constraint_exercise_files_required",
                    $"files_required >= {Entities.ExerciseBody.MinRequiredFilesVal} AND files_required <= {Entities.ExerciseBody.MaxRequiredFilesVal}");
            });

            modelBuilder.Entity<ExerciseHeader>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ExerciseLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExerciseHeader)
                    .WithMany(p => p.ExerciseLanguage)
                    .HasForeignKey(d => d.FkExerciseHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_language_fk_exercise_header_id_fkey");

                entity.HasOne(d => d.FkExerciseVersion)
                    .WithMany(p => p.ExerciseLanguage)
                    .HasForeignKey(d => d.FkExerciseVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_language_fk_exercise_version_id_fkey");

                entity.HasOne(d => d.FkWrittenLanguage)
                    .WithMany(p => p.ExerciseLanguage)
                    .HasForeignKey(d => d.FkWrittenLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_language_fk_written_language_id_fkey");
            });

            modelBuilder.Entity<ExerciseTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.ExerciseTag)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_tag_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkTag)
                    .WithMany(p => p.ExerciseTag)
                    .HasForeignKey(d => d.FkTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_tag_fk_tag_id_fkey");
            });

            modelBuilder.Entity<ExerciseVersion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.ExerciseVersion)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_version_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.ExerciseVersion)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_version_fk_user_id_fkey");
            });

            modelBuilder.Entity<ProgrammingLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkExercise)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.FkExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_fk_exercise_id_fkey");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_fk_user_id_fkey");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TestCase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkTestSuite)
                    .WithMany(p => p.TestCase)
                    .HasForeignKey(d => d.FkTestSuiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("test_case_fk_test_suite_id_fkey");
            });

            modelBuilder.Entity<TestSuite>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<WrittenLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
