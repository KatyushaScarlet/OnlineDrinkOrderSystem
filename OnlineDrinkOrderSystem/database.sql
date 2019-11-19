-- 创建数据库

CREATE DATABASE shop;
USE shop;

-- 商品类型

CREATE TABLE Category(
Category_ID INT NOT NULL AUTO_INCREMENT,-- 类型id
Category_Name VARCHAR(255) NOT NULL,-- 类型名称
primary key(Category_ID)-- 主键 类型id
);

-- 商品

CREATE TABLE Item(
Item_ID INT NOT NULL AUTO_INCREMENT,-- 商品id
Item_Name VARCHAR(255) NOT NULL,-- 商品名称
Image_Url VARCHAR(255),-- 商品图片链接
Description VARCHAR(255) NOT NULL,-- 商品描述
Item_Price DOUBLE NOT NULL,-- 价格
Category_ID INT NOT NULL,-- 类型id
Click_Counts INT NOT NULL,-- 点击次数
Stock INT NOT NULL,-- 库存
Date_added DATETIME NOT NULL,-- 上架时间
Cost DOUBLE NOT NULL,-- 进价/成本
Sold INT NOT NULL,-- 已售出
Discount INT NOT NULL,-- 商品折扣（10 -> -10%）
primary key(Item_ID),-- 主键 商品id
foreign key(Category_ID) REFERENCES Category(Category_ID)-- 外键 类型id
);

-- 用户

CREATE TABLE User(
User_ID INT NOT NULL AUTO_INCREMENT,-- 用户id
Google_ID VARCHAR(255) NOT NULL,-- 关联的google id
User_Name VARCHAR(255) NOT NULL,-- 姓名
User_Avater VARCHAR(255) NOT NULL,-- 头像（URL）
Given_Name VARCHAR(255) NOT NULL,-- 名
Family_Name VARCHAR(255) NOT NULL,-- 姓
Address VARCHAR(255),-- 用户地址
Admin BOOLEAN,-- 用户是否为管理员
UNIQUE(Google_ID),-- Google ID 唯一
Primary key(User_ID)-- 主键 用户id
);

-- 评论

CREATE TABLE Review(
Review_ID INT NOT NULL AUTO_INCREMENT,-- 评论id
User_ID INT ,-- 用户id
Item_ID INT ,-- 商品id
Content VARCHAR(255) NOT NULL,-- 评论内容
Recommend BOOLEAN NOT NULL,-- 推荐/不推荐
Date DATETIME NOT NULL,-- 评价日期
PRIMARY key(Review_ID),-- 主键 评论id
foreign key(User_ID) REFERENCES User(User_ID),-- 外键 用户id
foreign key(Item_ID) REFERENCES Item(Item_ID)-- 外键 商品id
);

-- 购物车

CREATE TABLE Cart(
Cart_ID INT NOT NULL AUTO_INCREMENT,-- 购物车id
User_ID INT ,-- 用户id
Item_ID INT ,-- 商品id
Quantity INT NOT NULL,-- 商品数量
primary key(Cart_ID),-- 主键 购物车id
foreign key(User_ID) references User(User_ID),-- 外键 用户id
foreign key(Item_ID) references Item(Item_ID)-- 外键 商品id
);

-- 订单详情

CREATE TABLE Order_Detail(
Order_ID INT NOT NULL AUTO_INCREMENT,-- 订单id
User_ID INT ,-- 用户id
Order_Sum DOUBLE NOT NULL,-- 订单总价
Payment INT NOT NULL,-- 支付方式（1、货到付款，2、在线支付）
Delivery INT NOT NULL,-- 运送状态（1、未发货，2、已发货）
Address VARCHAR(255) NOT NULL,-- 寄送地址
Order_Date DATETIME NOT NULL,-- 下单时间
primary key(Order_ID),-- 主键 订单id
foreign key(User_ID) references User(User_ID)-- 外键 用户id
);

-- 订单中商品列表

CREATE TABLE Order_List(
Order_ID INT ,-- 订单id
Item_ID INT,-- 商品id
Order_Price DOUBLE NOT NULL,-- 商品价格（下单时价格）
Quantity INT NOT NULL,-- 商品数量
foreign key(Order_ID) references Order_Detail(Order_ID),-- 外键 订单id
foreign key(Item_ID) references Item(Item_ID) --  外键 商品id
);

-- 追踪列表

CREATE TABLE Trace_List(
User_ID INT ,-- 用户id
Item_ID INT ,-- 商品id
Trace_Price DOUBLE NOT NULL,-- 商品价格（追踪时的价格）
foreign key(User_ID) references User(User_ID),-- 外键 用户id
foreign key(Item_ID) references Item(Item_ID)--  外键 商品id
);