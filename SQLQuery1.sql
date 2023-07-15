create table Employee (
	emp_id int identity(1,1) primary key,
	emp_name nvarchar(255) default '',
	emp_email varchar(500) default '' not null,
	emp_password varchar(500) default '' not null,
	emp_status bit default 1
)

create table Customer (
	cus_id int identity(1,1) primary key,
	cus_name nvarchar(255) default '',
	cus_address nvarchar(500) default '',
	cus_contact varchar(15) default '',
	cus_email varchar(500) default '' not null,
	cus_status bit default 1
)

create table Author (
	auth_id int identity(1,1) primary key,
	auth_name nvarchar(255) default '' not null,
	auth_information nvarchar(500) default '',
	auth_status bit default 1
)

create table Publisher (
	pub_id int identity(1,1) primary key,
	pub_name nvarchar(255) default '' not null,
	pub_information nvarchar(500) default '',
	pub_status bit default 1
)

create table Category (
	cate_id int identity(1,1) primary key,
	cate_name nvarchar(500) default '' not null,
	cate_status bit default 1
)

create table Book (
	book_id int identity(1,1) primary key,
	book_name nvarchar(500) default '' not null,
	book_amount int default 0 not null,
	book_price decimal default 0,
	book_sale_price decimal default 0,
	book_cover varchar(4000) default '',
	book_description nvarchar(500) default '',
	auth_id int foreign key references Author(auth_id),
	pub_id int foreign key references Publisher(pub_id),
	cate_id int foreign key references Category(cate_id),
	book_status bit default 1
)

create table BillStatus (
	bs_id int identity(1,1) primary key,
	bs_name varchar(255) default '' not null,
	bs_status bit default 1
)

create table Bill (
	bill_id int identity(1,1) primary key,
	created_time varchar(500) default '' not null,
	bill_total decimal default 0 not null,
	cus_id int foreign key references Customer(cus_id),
	emp_id int foreign key references Employee(emp_id), 
	bill_status int foreign key references BillStatus(bs_id)
)

create table BillDetail (
	bid_id int identity(1,1),
	book_id int foreign key references Book(book_id),
	bid_amount int default 0 not null,
	bid_payment decimal default 0 not null,
	bill_id int foreign key references Bill(bill_id),
	constraint pk_bill_detail primary key(bid_id, book_id, bill_id)
)
