DROP TABLE SALE;	
DROP TABLE ITEM;
DROP TABLE RENTAL;
DROP TABLE TENANT;
DROP TABLE SHELVING_UNIT;

CREATE TABLE SHELF_UNIT(
	ShelfUnitId int IDENTITY (1,1) PRIMARY KEY
);

CREATE TABLE TENANT(
	TenantId int IDENTITY (1,1) PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	PhoneNo nvarchar(15) NOT NULL,
	Email nvarchar(100) NOT NULL,
	AccountNo int NOT NULL,
	AccountBalance DECIMAL(10, 2) NOT NULL DEFAULT 0
);

CREATE TABLE ITEM (
	ItemId        int IDENTITY (1,1) PRIMARY KEY,
    Name          nvarchar(100) NOT NULL,
    Price         decimal(10,2) NOT NULL, 
    BarcodeNo     nvarchar(64) NOT NULL UNIQUE, 
    IsSold        bit NOT NULL DEFAULT 0,
    ShelfUnitId   int NOT NULL FOREIGN KEY REFERENCES SHELF_UNIT(ShelfUnitId)
);

CREATE TABLE SALE(
	SaleId int IDENTITY (1,1) PRIMARY KEY,
	Date datetime NOT NULL,
	Price decimal NOT NULL,
	IsSetteled bit NOT NULL DEFAULT 0,
	ItemId int FOREIGN KEY REFERENCES ITEM(ItemId)
);

CREATE TABLE RENTAL(
	RentalId int IDENTITY (1,1) PRIMARY KEY,
	StartDate datetime2 NOT NULL,
	EndDate datetime2 NOT NULL,
	IsSettled bit NOT NULL, DEFAULT 0,
	SettledDate datetime2 NULL,
	RentalConfig int NOT NULL, DEFAULT 0,
	PriceAgreement decimal (10,2) NOT NULL,
	TenantId int FOREIGN KEY REFERENCES TENANT(TenantId),
	ShelfUnitId int FOREIGN KEY REFERENCES SHELF_UNIT(ShelfUnitId)
);


