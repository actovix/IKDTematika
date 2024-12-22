using System;
using System.Collections.Generic;
using IKDTematika.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace IKDTematika.Contexts;

public partial class MaxmokmailIkd2Context : DbContext
{
    public MaxmokmailIkd2Context()
    {
    }

    public MaxmokmailIkd2Context(DbContextOptions<MaxmokmailIkd2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BlockPlan> BlockPlans { get; set; }

    public virtual DbSet<ControlType> ControlTypes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseSubject> CourseSubjects { get; set; }

    public virtual DbSet<Dep> Deps { get; set; }

    public virtual DbSet<Head> Heads { get; set; }

    public virtual DbSet<IkdStatus> IkdStatuses { get; set; }

    public virtual DbSet<Napravlenie> Napravlenies { get; set; }

    public virtual DbSet<Oop> Oops { get; set; }

    public virtual DbSet<PartPlan> PartPlans { get; set; }

    public virtual DbSet<Podr> Podrs { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Razdel> Razdels { get; set; }

    public virtual DbSet<Semestr> Semestrs { get; set; }

    public virtual DbSet<SemestrControl> SemestrControls { get; set; }

    public virtual DbSet<StudyForm> StudyForms { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<VCourceSubjectAll> VCourceSubjectAlls { get; set; }

    public virtual DbSet<VCourseAll> VCourseAlls { get; set; }

    public virtual DbSet<VCourseAll2> VCourseAll2s { get; set; }

    public virtual DbSet<VRazdelAll> VRazdelAlls { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=pg3.sweb.ru;Port=5432;Database=maxmokmail_ikd2;Username=maxmokmail_ikd2;Password=FGKhT3967V#FHBF8");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("ru_RU.utf8")
            .HasPostgresEnum("work_type", new[] { "лекция", "лабораторная работа", "практическое занятие" });

        modelBuilder.Entity<BlockPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("block_plan_pkey");

            entity.ToTable("block_plan", tb => tb.HasComment("Блок плана"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<ControlType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("control_type_pkey");

            entity.ToTable("control_type", tb => tb.HasComment("формы контроля"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Sokr)
                .HasColumnType("character varying")
                .HasColumnName("sokr");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("course_pkey");

            entity.ToTable("course", tb => tb.HasComment("дисциплина"));

            entity.HasIndex(e => e.IdBlock, "course_id_block_idx");

            entity.HasIndex(e => e.IdPart, "course_id_part_idx");

            entity.HasIndex(e => e.Name, "course_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.IdBlock).HasColumnName("id_block");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");
            entity.Property(e => e.IdOop).HasColumnName("id_oop");
            entity.Property(e => e.IdPart).HasColumnName("id_part");
            entity.Property(e => e.IsRequired).HasColumnName("is_required");
            entity.Property(e => e.Module)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("module");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UrlIstuAnnot)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_annot");
            entity.Property(e => e.UrlIstuRpd)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_rpd");

            entity.HasOne(d => d.IdBlockNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdBlock)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_id_block_fkey");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_id_dep_fkey");

            entity.HasOne(d => d.IdOopNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdOop)
                .HasConstraintName("course_id_oop_fkey");

            entity.HasOne(d => d.IdPartNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_id_part_fkey");
        });

        modelBuilder.Entity<CourseSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("course_subject_pkey");

            entity.ToTable("course_subject", tb => tb.HasComment("связь тематики и дисцилпины"));

            entity.HasIndex(e => new { e.IdCourse, e.IdSubject }, "course_subject_id_course_id_subject_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCourse).HasColumnName("id_course");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");
            entity.Property(e => e.Rank).HasColumnName("rank");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseSubjects)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_subject_id_course_fkey");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.CourseSubjects)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_subject_id_subject_fkey");
        });

        modelBuilder.Entity<Dep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dep_pkey");

            entity.ToTable("dep", tb => tb.HasComment("кафедра"));

            entity.HasIndex(e => e.IdHead, "dep_id_head_idx");

            entity.HasIndex(e => e.IdPodr, "dep_id_podr_idx");

            entity.HasIndex(e => e.Name, "dep_name_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdHead).HasColumnName("id_head");
            entity.Property(e => e.IdPodr).HasColumnName("id_podr");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");

            entity.HasOne(d => d.IdHeadNavigation).WithMany(p => p.Deps)
                .HasForeignKey(d => d.IdHead)
                .HasConstraintName("dep_id_head_fkey");

            entity.HasOne(d => d.IdPodrNavigation).WithMany(p => p.Deps)
                .HasForeignKey(d => d.IdPodr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dep_id_podr_fkey");
        });

        modelBuilder.Entity<Head>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("head_pkey");

            entity.ToTable("head", tb => tb.HasComment("руководитель кафедры или ООП"));

            entity.HasIndex(e => e.Fio, "head_fio_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.FullFio)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("full_fio");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");
        });

        modelBuilder.Entity<IkdStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ikd_status_pkey");

            entity.ToTable("ikd_status", tb => tb.HasComment("статусы создания ИКД"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Desription)
                .HasColumnType("character varying")
                .HasColumnName("desription");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Napravlenie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("napravlenie_pkey");

            entity.ToTable("napravlenie", tb => tb.HasComment("направление подготовки"));

            entity.HasIndex(e => new { e.Code, e.Name }, "napravlenie_code_name_idx");

            entity.HasIndex(e => e.IdQualification, "napravlenie_id_qualification_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.IdQualification).HasColumnName("id_qualification");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.IdQualificationNavigation).WithMany(p => p.Napravlenies)
                .HasForeignKey(d => d.IdQualification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("napravlenie_id_qualification_fkey");
        });

        modelBuilder.Entity<Oop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("oop_pkey");

            entity.ToTable("oop", tb => tb.HasComment("основная образовательная программа"));

            entity.HasIndex(e => e.IdDep, "oop_id_dep_idx");

            entity.HasIndex(e => e.IdHead, "oop_id_head_idx");

            entity.HasIndex(e => e.IdNap, "oop_id_nap_idx");

            entity.HasIndex(e => e.IdStudyForm, "oop_id_study_form_idx");

            entity.HasIndex(e => e.Name, "oop_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.FirstYear).HasColumnName("first_year");
            entity.Property(e => e.IdDep).HasColumnName("id_dep");
            entity.Property(e => e.IdHead).HasColumnName("id_head");
            entity.Property(e => e.IdNap).HasColumnName("id_nap");
            entity.Property(e => e.IdStatus)
                .HasDefaultValue(1)
                .HasColumnName("id_status");
            entity.Property(e => e.IdStudyForm).HasColumnName("id_study_form");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PreviousOopId).HasColumnName("previous_oop_id");
            entity.Property(e => e.UrlFile)
                .HasColumnType("character varying")
                .HasColumnName("url_file");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Oops)
                .HasForeignKey(d => d.IdDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oop_id_dep_fkey");

            entity.HasOne(d => d.IdHeadNavigation).WithMany(p => p.Oops)
                .HasForeignKey(d => d.IdHead)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oop_id_head_fkey");

            entity.HasOne(d => d.IdNapNavigation).WithMany(p => p.Oops)
                .HasForeignKey(d => d.IdNap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oop_id_nap_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Oops)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oop_id_status_fkey");

            entity.HasOne(d => d.IdStudyFormNavigation).WithMany(p => p.Oops)
                .HasForeignKey(d => d.IdStudyForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oop_id_study_form_fkey");

            entity.HasOne(d => d.PreviousOop).WithMany(p => p.InversePreviousOop)
                .HasForeignKey(d => d.PreviousOopId)
                .HasConstraintName("oop_previous_oop_id_fkey");
        });

        modelBuilder.Entity<PartPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("part_plan_pkey");

            entity.ToTable("part_plan", tb => tb.HasComment("Часть плана (внутри блока)"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Podr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("podr_pkey");

            entity.ToTable("podr", tb => tb.HasComment("подразделение: факультет или институт"));

            entity.HasIndex(e => e.IdHead, "podr_id_head_idx");

            entity.HasIndex(e => e.Name, "podr_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdHead).HasColumnName("id_head");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Sokr)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("sokr");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");

            entity.HasOne(d => d.IdHeadNavigation).WithMany(p => p.Podrs)
                .HasForeignKey(d => d.IdHead)
                .HasConstraintName("podr_id_head_fkey");
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("qualification_pkey");

            entity.ToTable("qualification", tb => tb.HasComment("квалиифкация"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Razdel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("razdel_pkey");

            entity.ToTable("razdel", tb => tb.HasComment("раздел дисцплины (для 4 команды)"));

            entity.HasIndex(e => e.IdCourse, "razdel_id_course_idx");

            entity.HasIndex(e => e.Name, "razdel_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCourse).HasColumnName("id_course");
            entity.Property(e => e.Lab)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("lab");
            entity.Property(e => e.Lec)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("lec");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Num)
                .HasDefaultValue(1)
                .HasColumnName("num");
            entity.Property(e => e.Prac)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("prac");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Razdels)
                .HasForeignKey(d => d.IdCourse)
                .HasConstraintName("razdel_id_course_fkey");
        });

        modelBuilder.Entity<Semestr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("semestr_pkey");

            entity.ToTable("semestr", tb => tb.HasComment("конкретный семестр в к конкретной дисциплине с часами и з.е."));

            entity.HasIndex(e => e.IdCourse, "semestr_id_course_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCourse).HasColumnName("id_course");
            entity.Property(e => e.Lab).HasColumnName("lab");
            entity.Property(e => e.Lec).HasColumnName("lec");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Pract).HasColumnName("pract");
            entity.Property(e => e.Srs).HasColumnName("srs");
            entity.Property(e => e.Ze).HasColumnName("ze");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Semestrs)
                .HasForeignKey(d => d.IdCourse)
                .HasConstraintName("semestr_id_course_fkey");
        });

        modelBuilder.Entity<SemestrControl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("semestr_control_pkey");

            entity.ToTable("semestr_control", tb => tb.HasComment("форма контроля"));

            entity.HasIndex(e => e.IdSemestr, "semestr_control_id_semestr_idx");

            entity.HasIndex(e => e.IdControlType, "semestr_control_id_сontrol_type_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdControlType).HasColumnName("id_control_type");
            entity.Property(e => e.IdSemestr).HasColumnName("id_semestr");

            entity.HasOne(d => d.IdControlTypeNavigation).WithMany(p => p.SemestrControls)
                .HasForeignKey(d => d.IdControlType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("semestr_control_id_сontrol_type_fkey");

            entity.HasOne(d => d.IdSemestrNavigation).WithMany(p => p.SemestrControls)
                .HasForeignKey(d => d.IdSemestr)
                .HasConstraintName("semestr_control_id_semestr_fkey");
        });

        modelBuilder.Entity<StudyForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("study_form_pkey");

            entity.ToTable("study_form", tb => tb.HasComment("форма обучения"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Sokr)
                .HasColumnType("character varying")
                .HasColumnName("sokr");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subject_pkey");

            entity.ToTable("subject", tb => tb.HasComment("справочник тематик дисциплин (для 2 команды)"));

            entity.HasIndex(e => e.Name, "subject_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasDefaultValue(16777215)
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VCourceSubjectAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCourceSubjectAll");

            entity.Property(e => e.CourseName)
                .HasColumnType("character varying")
                .HasColumnName("course_name");
            entity.Property(e => e.FirstYear).HasColumnName("first_year");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NapCode)
                .HasColumnType("character varying")
                .HasColumnName("nap_code");
            entity.Property(e => e.Napravlenie)
                .HasColumnType("character varying")
                .HasColumnName("napravlenie");
            entity.Property(e => e.OopName).HasColumnName("oop_name");
            entity.Property(e => e.OopType).HasColumnName("oop_type");
            entity.Property(e => e.SubjectName).HasColumnName("subject_name");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");
            entity.Property(e => e.UrlIstuRpd)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_rpd");
        });

        modelBuilder.Entity<VCourseAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCourseAll");

            entity.Property(e => e.BlockName)
                .HasColumnType("character varying")
                .HasColumnName("block_name");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseName)
                .HasColumnType("character varying")
                .HasColumnName("course_name");
            entity.Property(e => e.FirstYear).HasColumnName("first_year");
            entity.Property(e => e.GradeForm)
                .HasColumnType("character varying")
                .HasColumnName("grade_form");
            entity.Property(e => e.IsRequired).HasColumnName("is_required");
            entity.Property(e => e.LabHours).HasColumnName("lab_hours");
            entity.Property(e => e.LecHours).HasColumnName("lec_hours");
            entity.Property(e => e.Module)
                .HasColumnType("character varying")
                .HasColumnName("module");
            entity.Property(e => e.Napravlenie)
                .HasColumnType("character varying")
                .HasColumnName("napravlenie");
            entity.Property(e => e.NapravlenieCode)
                .HasColumnType("character varying")
                .HasColumnName("napravlenie_code");
            entity.Property(e => e.NapravlenieId).HasColumnName("napravlenie_id");
            entity.Property(e => e.OopId).HasColumnName("oop_id");
            entity.Property(e => e.OopName).HasColumnName("oop_name");
            entity.Property(e => e.OopType).HasColumnName("oop_type");
            entity.Property(e => e.PartName)
                .HasColumnType("character varying")
                .HasColumnName("part_name");
            entity.Property(e => e.PractHours).HasColumnName("pract_hours");
            entity.Property(e => e.Semestr).HasColumnName("semestr");
            entity.Property(e => e.SemestrControlId).HasColumnName("semestr_control_id");
            entity.Property(e => e.SemestrControlSemestrId).HasColumnName("semestr_control_semestr_id");
            entity.Property(e => e.SemestrControlTypeId).HasColumnName("semestr_control_type_id");
            entity.Property(e => e.SemestrId).HasColumnName("semestr_id");
            entity.Property(e => e.SourceCode)
                .HasColumnType("character varying")
                .HasColumnName("source_code");
            entity.Property(e => e.StudyForm)
                .HasColumnType("character varying")
                .HasColumnName("study_form");
            entity.Property(e => e.StudyFormSokr)
                .HasColumnType("character varying")
                .HasColumnName("study_form_sokr");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasColumnType("character varying")
                .HasColumnName("subject_name");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");
            entity.Property(e => e.UrlIstuAnnot)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_annot");
            entity.Property(e => e.UrlIstuRpd)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_rpd");
            entity.Property(e => e.Ze).HasColumnName("ze");
        });

        modelBuilder.Entity<VCourseAll2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCourseAll2");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseName)
                .HasColumnType("character varying")
                .HasColumnName("course_name");
            entity.Property(e => e.FirstYear).HasColumnName("first_year");
            entity.Property(e => e.GradeForm)
                .HasColumnType("character varying")
                .HasColumnName("grade_form");
            entity.Property(e => e.LabHours).HasColumnName("lab_hours");
            entity.Property(e => e.LecHours).HasColumnName("lec_hours");
            entity.Property(e => e.NapCode)
                .HasColumnType("character varying")
                .HasColumnName("nap_code");
            entity.Property(e => e.Napravlenie)
                .HasColumnType("character varying")
                .HasColumnName("napravlenie");
            entity.Property(e => e.NapravlenieId).HasColumnName("napravlenie_id");
            entity.Property(e => e.OopId).HasColumnName("oop_id");
            entity.Property(e => e.OopName).HasColumnName("oop_name");
            entity.Property(e => e.OopType).HasColumnName("oop_type");
            entity.Property(e => e.PractHours).HasColumnName("pract_hours");
            entity.Property(e => e.Semestr).HasColumnName("semestr");
            entity.Property(e => e.SemestrId).HasColumnName("semestr_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasColumnType("character varying")
                .HasColumnName("subject_name");
            entity.Property(e => e.UrlIstu)
                .HasColumnType("character varying")
                .HasColumnName("url_istu");
            entity.Property(e => e.UrlIstuRpd)
                .HasColumnType("character varying")
                .HasColumnName("url_istu_rpd");
            entity.Property(e => e.Ze).HasColumnName("ze");
        });

        modelBuilder.Entity<VRazdelAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vRazdelAll");

            entity.Property(e => e.CourseName)
                .HasColumnType("character varying")
                .HasColumnName("course_name");
            entity.Property(e => e.FirstYear).HasColumnName("first_year");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lab)
                .HasColumnType("character varying")
                .HasColumnName("lab");
            entity.Property(e => e.Lec)
                .HasColumnType("character varying")
                .HasColumnName("lec");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.NapCode)
                .HasColumnType("character varying")
                .HasColumnName("nap_code");
            entity.Property(e => e.Napravlenie)
                .HasColumnType("character varying")
                .HasColumnName("napravlenie");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.OopName).HasColumnName("oop_name");
            entity.Property(e => e.Prac)
                .HasColumnType("character varying")
                .HasColumnName("prac");
            entity.Property(e => e.Razdel)
                .HasColumnType("character varying")
                .HasColumnName("razdel");
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_pkey");

            entity.ToTable("work", tb => tb.HasComment("вид работы и её содержание в разделе (для 4 команды). Не используется! Денормализована. "));

            entity.HasIndex(e => e.IdRazdel, "work_id_razdel_idx");

            entity.HasIndex(e => e.Text, "work_text_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRazdel).HasColumnName("id_razdel");
            entity.Property(e => e.Text)
                .HasColumnType("character varying")
                .HasColumnName("text");
            entity.Property(e => e.WorkNumber).HasColumnName("work_number");

            entity.HasOne(d => d.IdRazdelNavigation).WithMany(p => p.Works)
                .HasForeignKey(d => d.IdRazdel)
                .HasConstraintName("work_id_razdel_fkey");
        });
        modelBuilder.HasSequence("podr_id_seq").HasMax(2147483647L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
