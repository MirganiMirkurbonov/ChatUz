using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "locations");

            migrationBuilder.CreateTable(
                name: "auth_roles",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    keyword = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth_usernames",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_usernames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth_users",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    bio = table.Column<string>(type: "text", nullable: false),
                    username_id = table.Column<long>(type: "bigint", nullable: true),
                    email_hash = table.Column<string>(type: "text", nullable: true),
                    phone_hash = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<string>(type: "text", nullable: true),
                    hash = table.Column<string>(type: "text", nullable: true),
                    last_otp = table.Column<string>(type: "text", nullable: true),
                    user_status = table.Column<int>(type: "integer", nullable: false),
                    location_visible_for = table.Column<int>(type: "integer", nullable: false),
                    friends_count = table.Column<long>(type: "bigint", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_users_auth_usernames_username_id",
                        column: x => x.username_id,
                        principalSchema: "auth",
                        principalTable: "auth_usernames",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "auth_friends",
                schema: "auth",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    requested_friend_id = table.Column<long>(type: "bigint", nullable: false),
                    receiver_friend_id = table.Column<long>(type: "bigint", nullable: false),
                    friend_state = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_friends", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_friends_auth_users_receiver_friend_id",
                        column: x => x.receiver_friend_id,
                        principalSchema: "auth",
                        principalTable: "auth_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_auth_friends_auth_users_requested_friend_id",
                        column: x => x.requested_friend_id,
                        principalSchema: "auth",
                        principalTable: "auth_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_location",
                schema: "locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    location_status = table.Column<int>(type: "integer", nullable: false),
                    auth_user_id = table.Column<long>(type: "bigint", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_location", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_location_auth_users_auth_user_id",
                        column: x => x.auth_user_id,
                        principalSchema: "auth",
                        principalTable: "auth_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "location_photo",
                schema: "locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "text", nullable: false),
                    extension = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<double>(type: "double precision", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_location_photo_user_location_location_id",
                        column: x => x.location_id,
                        principalSchema: "locations",
                        principalTable: "user_location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auth_friends_receiver_friend_id",
                schema: "auth",
                table: "auth_friends",
                column: "receiver_friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_friends_requested_friend_id",
                schema: "auth",
                table: "auth_friends",
                column: "requested_friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_usernames_username",
                schema: "auth",
                table: "auth_usernames",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_email_hash",
                schema: "auth",
                table: "auth_users",
                column: "email_hash",
                unique: true,
                filter: "email_hash IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_phone_hash",
                schema: "auth",
                table: "auth_users",
                column: "phone_hash",
                unique: true,
                filter: "phone_hash IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_username_id",
                schema: "auth",
                table: "auth_users",
                column: "username_id");

            migrationBuilder.CreateIndex(
                name: "IX_location_photo_location_id",
                schema: "locations",
                table: "location_photo",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_location_auth_user_id",
                schema: "locations",
                table: "user_location",
                column: "auth_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auth_friends",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "auth_roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "location_photo",
                schema: "locations");

            migrationBuilder.DropTable(
                name: "user_location",
                schema: "locations");

            migrationBuilder.DropTable(
                name: "auth_users",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "auth_usernames",
                schema: "auth");
        }
    }
}
