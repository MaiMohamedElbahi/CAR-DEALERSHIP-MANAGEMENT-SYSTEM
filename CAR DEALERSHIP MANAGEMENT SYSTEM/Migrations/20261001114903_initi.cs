using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Available"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.CustomerProfileId);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Comfortable passenger cars", "Sedan" },
                    { 2, "Sport utility vehicles", "SUV" },
                    { 3, "Compact practical cars", "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DriverLicenseNumber", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "DL100001", "ahmed.hassan@example.com", "Ahmed Hassen", "01010000001" },
                    { 2, "DL100002", "mona.adel@example.com", "Mona Adel", "01010000002" },
                    { 3, "DL100003", "omar.khaled@example.com", "Omar Khaled", "01010000003" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FullName", "HireDate", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "mostafa.nabil@autodrive.com", "Mostafa Nabil", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000001", "Sales Manager" },
                    { 2, "aya.emad@autodrive.com", "Aya Emad", new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000002", "Sales Consultant" },
                    { 3, "hassen.ali@autodrive.com", "Hassan Ali", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01020000003", "Sales Consultant" }
                });

            migrationBuilder.InsertData(
                table: "CustomerProfiles",
                columns: new[] { "CustomerProfileId", "Address", "City", "CustomerId", "DateOfBirth", "Nationality" },
                values: new object[,]
                {
                    { 1, "12 Nile St.", "Cairo", 1, new DateTime(1992, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian" },
                    { 2, "25 Tahrir St.", "Giza", 2, new DateTime(1995, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian" },
                    { 3, "18 El Nasr St.", "Cairo", 3, new DateTime(1988, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egyptian" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CategoryId", "Color", "FuelType", "Make", "Mileage", "Model", "Price", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 1, "White", "Petrol", "Toyota", 12000, "Corolla", 650000m, "Available", "Automatic", "VIN0000000000000", 2024 },
                    { 2, 1, "Black", "Petrol", "Hyundai", 18000, "Elantra", 590000m, "Available", "Automatic", "VIN0000000000001", 2023 },
                    { 3, 2, "Gray", "Petrol", "Kia", 9000, "Sportage", 980000m, "Available", "Automatic", "VIN0000000000002", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "EmployeeId", "Notes", "PaymentMethod", "SaleDate", "SalePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Completed sale.", "Bank Transfer", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1750000m, 1 },
                    { 2, 2, 2, "Completed sale.", "Bank Transfer", new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1850000m, 2 },
                    { 3, 3, 3, "Completed sale.", "Cash", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 510000m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_CustomerId",
                table: "CustomerProfiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DriverLicenseNumber",
                table: "Customers",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VehicleId",
                table: "Sales",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
