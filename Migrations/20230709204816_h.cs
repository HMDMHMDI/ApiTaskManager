using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTaskManager.Migrations
{
    /// <inheritdoc />
    public partial class h : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminClient_Admins_AdminsId",
                table: "AdminClient");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminClient_Clients_ClientId",
                table: "AdminClient");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTask_Admins_AdminsId",
                table: "AdminTask");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTask_Tasks_TasksId",
                table: "AdminTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTask_Clients_ClientsId",
                table: "ClientTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTask_Tasks_TasksId",
                table: "ClientTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTask",
                table: "ClientTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminTask",
                table: "AdminTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminClient",
                table: "AdminClient");

            migrationBuilder.RenameTable(
                name: "ClientTask",
                newName: "ClientTasks");

            migrationBuilder.RenameTable(
                name: "AdminTask",
                newName: "AdminTasks");

            migrationBuilder.RenameTable(
                name: "AdminClient",
                newName: "AdminClients");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTask_TasksId",
                table: "ClientTasks",
                newName: "IX_ClientTasks_TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminTask_TasksId",
                table: "AdminTasks",
                newName: "IX_AdminTasks_TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminClient_ClientId",
                table: "AdminClients",
                newName: "IX_AdminClients_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTasks",
                table: "ClientTasks",
                columns: new[] { "ClientsId", "TasksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminTasks",
                table: "AdminTasks",
                columns: new[] { "AdminsId", "TasksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminClients",
                table: "AdminClients",
                columns: new[] { "AdminsId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClients_Admins_AdminsId",
                table: "AdminClients",
                column: "AdminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClients_Clients_ClientId",
                table: "AdminClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTasks_Admins_AdminsId",
                table: "AdminTasks",
                column: "AdminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTasks_Tasks_TasksId",
                table: "AdminTasks",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTasks_Clients_ClientsId",
                table: "ClientTasks",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTasks_Tasks_TasksId",
                table: "ClientTasks",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminClients_Admins_AdminsId",
                table: "AdminClients");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminClients_Clients_ClientId",
                table: "AdminClients");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTasks_Admins_AdminsId",
                table: "AdminTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTasks_Tasks_TasksId",
                table: "AdminTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTasks_Clients_ClientsId",
                table: "ClientTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTasks_Tasks_TasksId",
                table: "ClientTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTasks",
                table: "ClientTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminTasks",
                table: "AdminTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminClients",
                table: "AdminClients");

            migrationBuilder.RenameTable(
                name: "ClientTasks",
                newName: "ClientTask");

            migrationBuilder.RenameTable(
                name: "AdminTasks",
                newName: "AdminTask");

            migrationBuilder.RenameTable(
                name: "AdminClients",
                newName: "AdminClient");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTasks_TasksId",
                table: "ClientTask",
                newName: "IX_ClientTask_TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminTasks_TasksId",
                table: "AdminTask",
                newName: "IX_AdminTask_TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminClients_ClientId",
                table: "AdminClient",
                newName: "IX_AdminClient_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTask",
                table: "ClientTask",
                columns: new[] { "ClientsId", "TasksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminTask",
                table: "AdminTask",
                columns: new[] { "AdminsId", "TasksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminClient",
                table: "AdminClient",
                columns: new[] { "AdminsId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClient_Admins_AdminsId",
                table: "AdminClient",
                column: "AdminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClient_Clients_ClientId",
                table: "AdminClient",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTask_Admins_AdminsId",
                table: "AdminTask",
                column: "AdminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTask_Tasks_TasksId",
                table: "AdminTask",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTask_Clients_ClientsId",
                table: "ClientTask",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTask_Tasks_TasksId",
                table: "ClientTask",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
