﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorksAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SalesLT");

            migrationBuilder.CreateSequence<int>(
                name: "SalesOrderNumber");

            migrationBuilder.CreateTable(
                name: "BuildVersion",
                columns: table => new
                {
                    SystemInformationID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatabaseVersion = table.Column<string>(name: "Database Version", maxLength: 25, nullable: false),
                    VersionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildVersion", x => x.SystemInformationID);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ErrorTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ErrorNumber = table.Column<int>(nullable: false),
                    ErrorSeverity = table.Column<int>(nullable: true),
                    ErrorState = table.Column<int>(nullable: true),
                    ErrorProcedure = table.Column<string>(maxLength: 126, nullable: true),
                    ErrorLine = table.Column<int>(nullable: true),
                    ErrorMessage = table.Column<string>(maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorLogID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "SalesLT",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 60, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    StateProvince = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    CountryRegion = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "SalesLT",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameStyle = table.Column<bool>(type: "NameStyle", nullable: false),
                    title = table.Column<string>(maxLength: 8, nullable: true),
                    firstName = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    middleName = table.Column<string>(type: "Name", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    suffix = table.Column<string>(maxLength: 10, nullable: true),
                    companyName = table.Column<string>(maxLength: 128, nullable: true),
                    salesPerson = table.Column<string>(maxLength: 256, nullable: true),
                    emailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "Phone", maxLength: 25, nullable: true),
                    passwordHash = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    passwordSalt = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    modifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "SalesLT",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentProductCategoryID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID",
                        column: x => x.ParentProductCategoryID,
                        principalSchema: "SalesLT",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "SalesLT",
                columns: table => new
                {
                    ProductDescriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionID);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                schema: "SalesLT",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    CatalogDescription = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductModelID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                schema: "SalesLT",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    AddressType = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => new { x.CustomerID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Address_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "SalesLT",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "SalesLT",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "SalesLT",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false, defaultValueSql: "(NEXT VALUE FOR [SalesLT].[SalesOrderNumber])"),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(type: "Flag", nullable: false, defaultValueSql: "((1))"),
                    SalesOrderNumber = table.Column<string>(maxLength: 25, nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))"),
                    PurchaseOrderNumber = table.Column<string>(type: "OrderNumber", maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(type: "AccountNumber", maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    ShipToAddressID = table.Column<int>(nullable: true),
                    BillToAddressID = table.Column<int>(nullable: true),
                    ShipMethod = table.Column<string>(maxLength: 50, nullable: false),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))"),
                    Comment = table.Column<string>(nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader", x => x.SalesOrderID);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_BillTo_AddressID",
                        column: x => x.BillToAddressID,
                        principalSchema: "SalesLT",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "SalesLT",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_ShipTo_AddressID",
                        column: x => x.ShipToAddressID,
                        principalSchema: "SalesLT",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "SalesLT",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "Name", maxLength: 50, nullable: false),
                    ProductNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Color = table.Column<string>(maxLength: 15, nullable: true),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(maxLength: 5, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    ProductCategoryID = table.Column<int>(nullable: true),
                    ProductModelID = table.Column<int>(nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThumbNailPhoto = table.Column<byte[]>(nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(maxLength: 50, nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalSchema: "SalesLT",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "SalesLT",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescription",
                schema: "SalesLT",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false),
                    ProductDescriptionID = table.Column<int>(nullable: false),
                    Culture = table.Column<string>(maxLength: 6, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescription", x => new { x.ProductModelID, x.ProductDescriptionID, x.Culture });
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
                        column: x => x.ProductDescriptionID,
                        principalSchema: "SalesLT",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "SalesLT",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "SalesLT",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesOrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric(38, 6)", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "SalesLT",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "SalesLT",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "AK_Address_rowguid",
                schema: "SalesLT",
                table: "Address",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvince",
                schema: "SalesLT",
                table: "Address",
                column: "StateProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion",
                schema: "SalesLT",
                table: "Address",
                columns: new[] { "AddressLine1", "AddressLine2", "City", "StateProvince", "PostalCode", "CountryRegion" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_emailAddress",
                schema: "SalesLT",
                table: "Customer",
                column: "emailAddress");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_rowguid",
                schema: "SalesLT",
                table: "Customer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "AK_CustomerAddress_rowguid",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_Name",
                schema: "SalesLT",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryID",
                schema: "SalesLT",
                table: "Product",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelID",
                schema: "SalesLT",
                table: "Product",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "AK_Product_ProductNumber",
                schema: "SalesLT",
                table: "Product",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_rowguid",
                schema: "SalesLT",
                table: "Product",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "SalesLT",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ParentProductCategoryID",
                schema: "SalesLT",
                table: "ProductCategory",
                column: "ParentProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_rowguid",
                schema: "SalesLT",
                table: "ProductCategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductDescription_rowguid",
                schema: "SalesLT",
                table: "ProductDescription",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_Name",
                schema: "SalesLT",
                table: "ProductModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_rowguid",
                schema: "SalesLT",
                table: "ProductModel",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescription_ProductDescriptionID",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "ProductDescriptionID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductModelProductDescription_rowguid",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductID",
                schema: "SalesLT",
                table: "SalesOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderDetail_rowguid",
                schema: "SalesLT",
                table: "SalesOrderDetail",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_BillToAddressID",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "BillToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CustomerID",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_rowguid",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "SalesOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipToAddressID",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "ShipToAddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildVersion");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "CustomerAddress",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescription",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "SalesLT");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "SalesLT");

            migrationBuilder.DropSequence(
                name: "SalesOrderNumber");
        }
    }
}
