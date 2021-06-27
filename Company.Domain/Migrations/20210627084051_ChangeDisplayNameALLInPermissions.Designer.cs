﻿// <auto-generated />
using System;
using Company.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.Domain.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20210627084051_ChangeDisplayNameALLInPermissions")]
    partial class ChangeDisplayNameALLInPermissions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Company.Domain.NewsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("News", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f1e5227-b380-4df1-bdd6-fd30c9ef6649"),
                            Description = "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años",
                            Title = "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("eac51bda-51f6-4bd7-8cbd-33d75729c881"),
                            Description = "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones",
                            Title = "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7647ea63-46b0-4c71-b9db-29f1c972eac7"),
                            Description = "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma",
                            Title = "Google y Facebook firman asociación con empresa de pago en línea",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("78451362-86fc-4662-9fd6-711b9565628e"),
                            Description = "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros",
                            Title = "Bitcóin: hackers tienen nuevo método para robar criptomonedas",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c2c9f618-53a0-49ce-8e0f-b1366e659937"),
                            Description = "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC",
                            Title = "'Startup' Habi recauda 100 millones de dólares en ronda de inversión",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fc634a41-70da-4d63-ad07-eea34b883fe8"),
                            Description = "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados",
                            Title = "E3: los mejores anuncios que dejó el evento en su edición virtual",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Company.Domain.PermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Type", "Name")
                        .IsUnique();

                    b.ToTable("Permission", "dbo");

                    b.HasDiscriminator<string>("Type").IsComplete(true).HasValue("PermissionEntity");
                });

            modelBuilder.Entity("Company.Domain.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
                            DisplayName = "Administrador",
                            Name = "AdminUser"
                        },
                        new
                        {
                            Id = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                            DisplayName = "Visitante",
                            Name = "VisitorUser"
                        },
                        new
                        {
                            Id = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            DisplayName = "Asistente",
                            Name = "AssistantUser"
                        },
                        new
                        {
                            Id = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            DisplayName = "Editor",
                            Name = "EditorUser"
                        });
                });

            modelBuilder.Entity("Company.Domain.RolePermissionEntity", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission", "dbo");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
                            PermissionId = new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407")
                        },
                        new
                        {
                            RoleId = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
                            PermissionId = new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363")
                        },
                        new
                        {
                            RoleId = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
                            PermissionId = new Guid("4f39c31e-ca99-4782-b585-ae847185a292")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("942d6f21-a7f7-43cd-9588-23657911fea2")
                        },
                        new
                        {
                            RoleId = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                            PermissionId = new Guid("4f39c31e-ca99-4782-b585-ae847185a292")
                        },
                        new
                        {
                            RoleId = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            PermissionId = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc")
                        },
                        new
                        {
                            RoleId = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            PermissionId = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18")
                        },
                        new
                        {
                            RoleId = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            PermissionId = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31")
                        },
                        new
                        {
                            RoleId = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            PermissionId = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595")
                        },
                        new
                        {
                            RoleId = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                            PermissionId = new Guid("4f39c31e-ca99-4782-b585-ae847185a292")
                        },
                        new
                        {
                            RoleId = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                            PermissionId = new Guid("4f39c31e-ca99-4782-b585-ae847185a292")
                        });
                });

            modelBuilder.Entity("Company.Domain.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("IdentificationNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("IdentificationNumber", "Username", "Email")
                        .IsUnique();

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Company.Domain.NewsPermission", b =>
                {
                    b.HasBaseType("Company.Domain.PermissionEntity");

                    b.HasDiscriminator().HasValue("CanNews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
                            DisplayName = "Todo",
                            Name = "ALL",
                            Order = 1
                        },
                        new
                        {
                            Id = new Guid("f79b85e6-0911-43e1-b68f-49fa74a52518"),
                            DisplayName = "Listar Noticias",
                            Name = "GetNews",
                            Order = 2
                        },
                        new
                        {
                            Id = new Guid("6d05ba82-9e0c-46ea-9e90-b268bca31885"),
                            DisplayName = "Detalle de Noticias",
                            Name = "GetNewsById",
                            Order = 3
                        });
                });

            modelBuilder.Entity("Company.Domain.RolesPermission", b =>
                {
                    b.HasBaseType("Company.Domain.PermissionEntity");

                    b.HasDiscriminator().HasValue("CanRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
                            DisplayName = "Todo",
                            Name = "ALL",
                            Order = 1
                        },
                        new
                        {
                            Id = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"),
                            DisplayName = "Listar Roles",
                            Name = "GetRoles",
                            Order = 2
                        },
                        new
                        {
                            Id = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"),
                            DisplayName = "Detalle del Rol",
                            Name = "GetRoleById",
                            Order = 3
                        },
                        new
                        {
                            Id = new Guid("6a2493a7-27f7-414f-9e8c-47077feafa82"),
                            DisplayName = "Listar Permisos",
                            Name = "GetPermissions",
                            Order = 4
                        },
                        new
                        {
                            Id = new Guid("71fea3d3-2d23-4971-97c1-23cec13242ba"),
                            DisplayName = "Listar Permisos por Rol",
                            Name = "GetPermissionsByRole",
                            Order = 5
                        });
                });

            modelBuilder.Entity("Company.Domain.UsersPermission", b =>
                {
                    b.HasBaseType("Company.Domain.PermissionEntity");

                    b.HasDiscriminator().HasValue("CanUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
                            DisplayName = "Todo",
                            Name = "ALL",
                            Order = 1
                        },
                        new
                        {
                            Id = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"),
                            DisplayName = "Listar Usuarios",
                            Name = "GetUsers",
                            Order = 2
                        },
                        new
                        {
                            Id = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"),
                            DisplayName = "Detalle del Usuario",
                            Name = "GetUserById",
                            Order = 3
                        },
                        new
                        {
                            Id = new Guid("73eadeb6-bc84-4d98-ab6e-04f85e057db7"),
                            DisplayName = "Crear Usuario",
                            Name = "AddUser",
                            Order = 4
                        },
                        new
                        {
                            Id = new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"),
                            DisplayName = "Editar Usuario",
                            Name = "EditUser",
                            Order = 5
                        },
                        new
                        {
                            Id = new Guid("a984910b-6ecc-43e0-82d5-e9c9b0c78d03"),
                            DisplayName = "Eliminar Usuario",
                            Name = "RemoveUser",
                            Order = 6
                        });
                });

            modelBuilder.Entity("Company.Domain.RolePermissionEntity", b =>
                {
                    b.HasOne("Company.Domain.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Domain.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Company.Domain.UserEntity", b =>
                {
                    b.HasOne("Company.Domain.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
