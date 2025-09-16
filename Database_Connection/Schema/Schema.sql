DROP TABLE SALE;	


CREATE TABLE SALE(
	SaleId int IDENTITY (1,1) PRIMARY KEY,
	Date datetime NOT NULL,
	Price decimal NOT NULL,
	IsSetteled bit NOT NULL DEFAULT 0,
	ItemId int FOREIGN KEY REFERENCES ITEM(ItemId)
);


DROP TABLE SHELVING_UNIT;

CREATE TABLE SHELF_UNIT(
	ShelfUnitId int IDENTITY (1,1) PRIMARY KEY
);

DROP TABLE TENANT;

CREATE TABLE TENANT(
	TenantId int IDENTITY (1,1) PRIMARY KEY,
	Name nvarchar(100) NOT NULL,
	PhoneNo nvarchar(15) NOT NULL,
	Email nvarchar(100) NOT NULL,
	AccountNo int NOT NULL,
	AccountBalance float NOT NULL DEFAULT 0
);

CREATE TABLE ITEM (
	ItemId        int IDENTITY (1,1) PRIMARY KEY,
    Name          nvarchar(100) NOT NULL,
    Price         decimal(10,2) NOT NULL, 
    BarcodeNo     nvarchar(64) NOT NULL UNIQUE, 
    IsSold        bit NOT NULL DEFAULT 0,
    ShelfUnitId   int NOT NULL
);