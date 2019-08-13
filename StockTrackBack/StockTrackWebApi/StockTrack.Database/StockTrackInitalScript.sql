
CREATE TABLE [dbo].[WebCompanies] (
    [WebCompanyId] BIGINT IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (100) Not NULL,
	[UserName] NVARCHAR (20) NOT NULL,
	[TheHash] NVARCHAR (20) NOT NULL,
	[Description]  NVARCHAR (250) NULL,
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_WebCompanies] PRIMARY KEY CLUSTERED ([WebCompanyId] ASC)
);

CREATE TABLE [dbo].[Lookups] (
    [LookupId] BIGINT IDENTITY (1, 1) NOT NULL,
    [Key] NVARCHAR (100) NULL,
    [Value]  NVARCHAR (200) NULL,
	[Description]  NVARCHAR (250) NULL,
	[WebCompanyId] BIGINT NOT NULL,
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Lookups] PRIMARY KEY CLUSTERED ([LookupId] ASC),
	CONSTRAINT [FK_Lookups_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Suppliers] (
    [SupplierId] BIGINT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
    [SupplierCode]  NVARCHAR (50) NULL,
	[Description]  NVARCHAR (250) NULL,
	[Telephone]  NVARCHAR (15) NULL,
	[Address1]  NVARCHAR (100) NULL,
	[Address2]  NVARCHAR (100) NULL,
	[City]  NVARCHAR (100) NULL,
	[AddressCode]  NVARCHAR (20) NULL,
	[TaxCode]  NVARCHAR (40) NULL,
	[WebCompanyId] BIGINT NOT NULL,
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([SupplierId] ASC),
	CONSTRAINT [FK_suppliers_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Brands] (
    [BrandId] BIGINT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
	[Description]  NVARCHAR (250) NULL,	
	[WebCompanyId] BIGINT NOT NULL,
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_brands] PRIMARY KEY CLUSTERED ([BrandId] ASC),	
	CONSTRAINT [FK_brands_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Products] (
    [ProductId] BIGINT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
	[Description]  NVARCHAR (250) NULL,
	[PackSize]  NVARCHAR (20) NULL,
	[ProductCode]  NVARCHAR (40) NULL,
	[ProductCodeOther]  NVARCHAR (40) NULL,
	[Barcode]  NVARCHAR (40) NULL,
	[WebCompanyId] BIGINT NOT NULL,	
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
	CONSTRAINT [FK_products_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);

GO
CREATE INDEX idx_product_productcode ON Products(ProductCode);
CREATE INDEX idx_product_productcodeOther ON Products(ProductCodeOther);

CREATE TABLE [dbo].[SupplierProducts] (
    [SupplierProductId] BIGINT IDENTITY (1, 1) NOT NULL,
	[WebCompanyId] BIGINT NOT NULL,
	[ProductId] BIGINT NOT NULL,
	[SupplierId] BIGINT NOT NULL,
	[Description]  NVARCHAR (250) NULL,
	DateAdded [SMALLDATETIME]  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_SupplierProducts] PRIMARY KEY CLUSTERED ([SupplierProductId] ASC),
	CONSTRAINT [FK_supplierproducts_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE,
	CONSTRAINT [FK_supplierproducts_products] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION,
	CONSTRAINT [FK_supplierproducts_supplier] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([SupplierId]) ON DELETE NO ACTION
);

--drop table WebCompanies
--drop table Lookups
--drop table Suppliers
--drop table Brands
--drop table Products
--drop table SupplierProducts

--insert into WebCompanies (CompanyName, UserName, TheHash, Description) values ('My Company', 'ASM', '', 'Test company')

--select * from WebCompanies

--insert into Products (Name, Description, PackSize, ProductCode,ProductCodeOther, Barcode, WebCompanyId ) values ('Twix', '250g 2 finger Twix', '250g', 'CADTWX', '', '0169365478', 1)
--select * from Products