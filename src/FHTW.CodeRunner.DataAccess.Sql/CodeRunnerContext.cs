// <copyright file="CodeRunnerContext.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using FHTW.CodeRunner.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The database context.
    /// </summary>
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
        /// <param name="options">Contextoptions.</param>
        public CodeRunnerContext(DbContextOptions<CodeRunnerContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or Sets users.
        /// </summary>
        public virtual DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or Sets collections.
        /// A collection is a collection of exercises.
        /// </summary>
        public virtual DbSet<Collection> Collection { get; set; }

        /// <summary>
        /// Gets or Sets collection exercises.
        /// A collection exercise is a wrapper around a exercise in which a prefered version, written language and programming language can be set.
        /// </summary>
        public virtual DbSet<CollectionExercise> CollectionExercise { get; set; }

        /// <summary>
        /// Gets or Sets the collection language.
        /// A collection language holds written lanugage specific data about a collection, like the introduction and description.
        /// </summary>
        public virtual DbSet<CollectionLanguage> CollectionLanguage { get; set; }

        /// <summary>
        /// Gets or Sets collection tag.
        /// A table for the m to n relationship of tags and collections.
        /// </summary>
        public virtual DbSet<CollectionTag> CollectionTag { get; set; }

        /// <summary>
        /// Gets or Sets comments.
        /// A comment is a user comment on an exercise for example.
        /// </summary>
        public virtual DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or Sets difficulty.
        /// The difficulty refers to the exercise difficulty assessment by a user.
        /// </summary>
        public virtual DbSet<Difficulty> Difficulty { get; set; }

        /// <summary>
        /// Gets or Sets exercises.
        /// A exercise can be in different versions, written languages and programming languages.
        /// </summary>
        public virtual DbSet<Exercise> Exercise { get; set; }

        /// <summary>
        /// Gets or Sets the exercise body.
        /// </summary>
        public virtual DbSet<ExerciseBody> ExerciseBody { get; set; }

        /// <summary>
        /// Gets or Sets the exercise header.
        /// </summary>
        public virtual DbSet<ExerciseHeader> ExerciseHeader { get; set; }

        /// <summary>
        /// Gets or Sets the exercise language entity.
        /// It is not equivalent to the written language.
        /// </summary>
        public virtual DbSet<ExerciseLanguage> ExerciseLanguage { get; set; }

        /// <summary>
        /// Gets or Sets the exercise tag.
        /// A table for the m to n relationship of tags and exercises.
        /// </summary>
        public virtual DbSet<ExerciseTag> ExerciseTag { get; set; }

        /// <summary>
        /// Gets or Sets exercise version.
        /// </summary>
        public virtual DbSet<ExerciseVersion> ExerciseVersion { get; set; }

        /// <summary>
        /// Gets or Sets programming language.
        /// </summary>
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or Sets rating.
        /// </summary>
        public virtual DbSet<Rating> Rating { get; set; }

        /// <summary>
        /// Gets or Sets tags.
        /// </summary>
        public virtual DbSet<Tag> Tag { get; set; }

        /// <summary>
        /// Gets or Sets testcases.
        /// </summary>
        public virtual DbSet<TestCase> TestCase { get; set; }

        /// <summary>
        /// Gets or Sets testsuites.
        /// </summary>
        public virtual DbSet<TestSuite> TestSuite { get; set; }

        /// <summary>
        /// Gets or Sets written language.
        /// </summary>
        public virtual DbSet<WrittenLanguage> WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or Sets written language.
        /// </summary>
        public virtual DbSet<QuestionType> QuestionType { get; set; }

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Collection)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_fk_user_id_fkey");
            });

            modelBuilder.Entity<CollectionExercise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkCollection)
                    .WithMany(p => p.CollectionExercise)
                    .HasForeignKey(d => d.FkCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_exercise_fk_collection_id_fkey");

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkCollection)
                    .WithMany(p => p.CollectionLanguage)
                    .HasForeignKey(d => d.FkCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_language_fk_collection_id_fkey");
            });

            modelBuilder.Entity<CollectionTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_fk_user_id_fkey");
            });

            modelBuilder.Entity<ExerciseBody>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ExerciseLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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

                entity.HasIndex(d => new { d.FkExerciseId, d.VersionNumber })
                    .IsUnique();
            });

            modelBuilder.Entity<ProgrammingLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<TestCase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkTestSuite)
                    .WithMany(p => p.TestCase)
                    .HasForeignKey(d => d.FkTestSuiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("test_case_fk_test_suite_id_fkey");
            });

            modelBuilder.Entity<TestSuite>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WrittenLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
