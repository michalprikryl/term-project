using Database.DBObjects;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public partial class TermProjectContext : DbContext
    {
        public virtual DbSet<DiagramType> DiagramType { get; set; }
        public virtual DbSet<Graph> Graph { get; set; }
        public virtual DbSet<GraphEdge> GraphEdge { get; set; }
        public virtual DbSet<GraphNode> GraphNode { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<NodeType> NodeType { get; set; }
        public virtual DbSet<Pattern> Pattern { get; set; }
        public virtual DbSet<PatternType> PatternType { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WorkSpace> WorkSpace { get; set; }

        public TermProjectContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiagramType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Graph>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.WorkSpaceId).HasColumnName("WorkSpaceID");

                entity.Property(e => e.Xmlrepresentation)
                    .IsRequired()
                    .HasColumnName("XMLRepresentation");

                entity.HasOne(d => d.WorkSpace)
                    .WithMany(p => p.Graph)
                    .HasForeignKey(d => d.WorkSpaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRAPH_WORKSPACE");
            });

            modelBuilder.Entity<GraphEdge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiagramEdgeId).HasColumnName("DiagramEdgeID");

                entity.Property(e => e.FromNodeId).HasColumnName("FromNodeID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ToNodeId).HasColumnName("ToNodeID");

                entity.HasOne(d => d.FromNode)
                    .WithMany(p => p.GraphEdgeFromNode)
                    .HasForeignKey(d => d.FromNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRAPHEDGE_GRAPHNODE_FROM");

                entity.HasOne(d => d.ToNode)
                    .WithMany(p => p.GraphEdgeToNode)
                    .HasForeignKey(d => d.ToNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRAPHEDGE_GRAPHNODE_TO");
            });

            modelBuilder.Entity<GraphNode>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiagramNodeId).HasColumnName("DiagramNodeID");

                entity.Property(e => e.GraphId).HasColumnName("GraphID");

                entity.Property(e => e.NodeTypeId).HasColumnName("NodeTypeID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Graph)
                    .WithMany(p => p.GraphNode)
                    .HasForeignKey(d => d.GraphId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRAPHNODE_GRAPH");

                entity.HasOne(d => d.NodeType)
                    .WithMany(p => p.GraphNode)
                    .HasForeignKey(d => d.NodeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRAPHNODE_NODETYPE");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.GraphNode)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_GRAPHNODE_REGION");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iso6391code)
                    .IsRequired()
                    .HasColumnName("ISO639-1Code")
                    .HasMaxLength(2);

                entity.Property(e => e.Iso6393code)
                    .IsRequired()
                    .HasColumnName("ISO639-3Code")
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NodeType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiagramTypeId).HasColumnName("DiagramTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DiagramType)
                    .WithMany(p => p.NodeType)
                    .HasForeignKey(d => d.DiagramTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NODETYPE_DIAGRAM");
            });

            modelBuilder.Entity<Pattern>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Jsonrepresenation)
                    .IsRequired()
                    .HasColumnName("JSONRepresenation");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PatternTypeId)
                    .HasColumnName("PatternTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Text).HasMaxLength(256);

                entity.HasOne(d => d.PatternType)
                    .WithMany(p => p.Pattern)
                    .HasForeignKey(d => d.PatternTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pattern_PatternType");
            });

            modelBuilder.Entity<PatternType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Text).HasMaxLength(256);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_LANGUAGE");
            });

            modelBuilder.Entity<WorkSpace>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DataFile).IsRequired();

                entity.Property(e => e.DataFormat)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkSpace)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKSPACE_USER");
            });
        }
    }
}
