IF OBJECT_ID('dbo.SALE', 'U') IS NOT NULL
    DROP TABLE dbo.SALE;

IF OBJECT_ID('dbo.ITEM', 'U') IS NOT NULL
    DROP TABLE dbo.ITEM;

IF OBJECT_ID('dbo.RENTAL', 'U') IS NOT NULL
    DROP TABLE dbo.RENTAL;

IF OBJECT_ID('dbo.TENANT', 'U') IS NOT NULL
    DROP TABLE dbo.TENANT;

IF OBJECT_ID('dbo.SHELF_UNIT', 'U') IS NOT NULL
    DROP TABLE dbo.SHELF_UNIT;


CREATE TABLE SHELF_UNIT (
    ShelfUnitId int IDENTITY(1,1) PRIMARY KEY
);

CREATE TABLE TENANT (
    TenantId int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(50),
    PhoneNo nvarchar(15),
    Email nvarchar(100),
    AccountNo int,
    AccountBalance decimal(10,2) NOT NULL DEFAULT 0
);

CREATE TABLE RENTAL (
    RentalId int IDENTITY(1,1) PRIMARY KEY,
    StartDate date NOT NULL,
    EndDate date,
    SettledDate date,
    RentalConfig int NOT NULL DEFAULT 0,
    PriceAgreement decimal(10,2),
    TenantId int NOT NULL,
    ShelfUnitId int NOT NULL,
    CONSTRAINT FK_Rental_Tenant FOREIGN KEY (TenantId) REFERENCES TENANT(TenantId),
    CONSTRAINT FK_Rental_ShelfUnit FOREIGN KEY (ShelfUnitId) REFERENCES SHELF_UNIT(ShelfUnitId)
);

CREATE TABLE ITEM (
    ItemId int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(100) NOT NULL,
    Price decimal(10,2) NOT NULL,
    BarcodeNo nvarchar(64) NOT NULL UNIQUE,
    IsSold bit NOT NULL DEFAULT 0,
    ShelfUnitId int NOT NULL,
    CONSTRAINT FK_Item_ShelfUnit FOREIGN KEY (ShelfUnitId) REFERENCES SHELF_UNIT(ShelfUnitId)
);

CREATE TABLE SALE (
    SaleId int IDENTITY(1,1) PRIMARY KEY,
    SalesDate date NOT NULL,
    Price decimal(10,2) NOT NULL,
    IsSetteled bit NOT NULL DEFAULT 0,
    ItemId int NOT NULL,
    CONSTRAINT FK_Sale_Item FOREIGN KEY (ItemId) REFERENCES ITEM(ItemId)
);















