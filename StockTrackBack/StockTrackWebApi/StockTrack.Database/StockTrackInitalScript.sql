
CREATE TABLE [dbo].[WebCompanies] (
    [WebCompanyId] INT IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (100) Not NULL,
	[UserName] NVARCHAR (20) NOT NULL,
	[TheHash] NVARCHAR (20) NOT NULL,
	[Description]  NVARCHAR (250) NULL,
    CONSTRAINT [PK_WebCompanies] PRIMARY KEY CLUSTERED ([WebCompanyId] ASC)
);
--drop table WebCompanies

CREATE TABLE [dbo].[Lookups] (
    [LookupId] INT IDENTITY (1, 1) NOT NULL,
    [Key] NVARCHAR (100) NULL,
    [Value]  NVARCHAR (200) NULL,
	[Description]  NVARCHAR (250) NULL,
	[WebCompanyId] INT NOT NULL,
    CONSTRAINT [PK_Lookups] PRIMARY KEY CLUSTERED ([LookupId] ASC),
	CONSTRAINT [FK_Lookups_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);
--drop table Lookups

CREATE TABLE [dbo].[Suppliers] (
    [SupplierId] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
    [SupplierCode]  NVARCHAR (50) NULL,
	[Description]  NVARCHAR (250) NULL,
	[Telephone]  NVARCHAR (15) NULL,
	[Address1]  NVARCHAR (100) NULL,
	[Address2]  NVARCHAR (100) NULL,
	[City]  NVARCHAR (100) NULL,
	[AddressCode]  NVARCHAR (20) NULL,
	[TaxCode]  NVARCHAR (40) NULL,
	[WebCompanyId] INT NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([SupplierId] ASC),
	CONSTRAINT [FK_suppliers_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);
--drop table Suppliers

CREATE TABLE [dbo].[Brands] (
    [BrandId] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
	[Description]  NVARCHAR (250) NULL,	
	[WebCompanyId] INT NOT NULL,
    CONSTRAINT [PK_brands] PRIMARY KEY CLUSTERED ([BrandId] ASC),
	CONSTRAINT [FK_brands_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);
--drop table Brands

CREATE TABLE [dbo].[Products] (
    [ProductId] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) Not NULL,
	[Description]  NVARCHAR (250) NULL,
	[Telephone]  NVARCHAR (15) NULL,
	[Address1]  NVARCHAR (100) NULL,
	[Address2]  NVARCHAR (100) NULL,
	[City]  NVARCHAR (100) NULL,
	[AddressCode]  NVARCHAR (20) NULL,
	[TaxCode]  NVARCHAR (40) NULL,
	[WebCompanyId] INT NOT NULL,	
    CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
	CONSTRAINT [FK_products_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE
);
--drop table Products

CREATE TABLE [dbo].[SupplierProducts] (
    [SupplierProductId] INT IDENTITY (1, 1) NOT NULL,
	[WebCompanyId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[SupplierId] INT NOT NULL,
	[Description]  NVARCHAR (250) NULL,	
    CONSTRAINT [PK_SupplierProducts] PRIMARY KEY CLUSTERED ([SupplierProductId] ASC),
	CONSTRAINT [FK_supplierproducts_webcompanies] FOREIGN KEY ([WebCompanyId]) REFERENCES [WebCompanies] ([WebCompanyId]) ON DELETE CASCADE,
	CONSTRAINT [FK_supplierproducts_products] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION,
	CONSTRAINT [FK_supplierproducts_supplier] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([SupplierId]) ON DELETE NO ACTION
);

--drop table SupplierProducts