-- 创建数据库
CREATE DATABASE shop;
USE shop;

-- 商品类型

CREATE TABLE Type(
Type_ID INT NOT NULL,-- 类型id
Type_Name TEXT NOT NULL,-- 类型名称
primary key(Type_ID)-- 主键 类型id
);

-- 商品

CREATE TABLE Item (
Item_ID INT NOT NULL,-- 商品id
Name TEXT NOT NULL,-- 商品名称
Photo mediumblob,-- 商品图片
Price DOUBLE NOT NULL,-- 价格
Type_ID INT NOT NULL,-- 类型id
Click_Counts INT NOT NULL,-- 点击次数
Stock INT NOT NULL,-- 库存
Date_added DATETIME NOT NULL,-- 上架时间
Cost DOUBLE NOT NULL,-- 进价
Sold INT NOT NULL,-- 已售出
primary key(Item_ID),-- 主键 商品id
foreign key(Type_ID) REFERENCES Type(Type_ID)-- 外键 类型id
);

-- 用户

CREATE TABLE User(
User_ID INT NOT NULL,-- 用户id
Google_ID TEXT NOT NULL,-- 关联的google id
Name TEXT NOT NULL,-- 姓名
Avater TEXT NOT NULL,-- 头像（URL）
Given_Name TEXT NOT NULL,-- 名
Family_Name TEXT NOT NULL,-- 姓
Address TEXT,-- 用户地址
Admin BOOLEAN,-- 用户是否为管理员
Primary key(User_ID)-- 主键 用户id
);

-- 评论

CREATE TABLE Review(
Review_ID INT NOT NULL,-- 评论id
User_ID INT NOT NULL,-- 用户id
Item_ID INT NOT NULL,-- 商品id
Content TEXT NOT NULL,-- 评论内容
Star DOUBLE NOT NULL,-- 评星
Date DATETIME NOT NULL,-- 日期
PRIMARY key(Review_ID),-- 主键 评论id
foreign key(User_ID) REFERENCES User(User_ID),-- 外键 用户id
foreign key(Item_ID) REFERENCES Item(Item_ID)-- 外键 商品id
);

-- 购物车

CREATE TABLE Cart(
Cart_ID INT NOT NULL,-- 购物车id
User_ID INT NOT NULL,-- 用户id
Item_ID INT NOT NULL,-- 商品id
Quantity INT NOT NULL,-- 商品数量
primary key(Cart_ID),-- 主键 购物车id
foreign key(User_ID) references User(User_ID),-- 外键 用户id
foreign key(Item_ID) references Item(Item_ID)-- 外键 商品id
);

-- 订单

CREATE TABLE Order_List(
Order_ID INT NOT NULL,-- 订单id
User_ID INT NOT NULL,-- 用户id
Sum DOUBLE NOT NULL,-- 订单总价
Paied BOOLEAN NOT NULL,-- 是否已支付
Date DATETIME NOT NULL,-- 下单时间
primary key(Order_ID),-- 主键 订单id
foreign key(User_ID) references User(User_ID)-- 外键 用户id
);

-- 订单详情

CREATE TABLE Order_Detail(
Order_ID INT NOT NULL,-- 订单id
Item_ID INT NOT NULL,-- 商品id
Price DOUBLE NOT NULL,-- 商品价格（下单时价格）
Quantity INT NOT NULL,-- 商品数量
foreign key(Order_ID) references Order_List(Order_ID),-- 外键 订单id
foreign key(Item_ID) references Item(Item_ID)--  外键 商品id
);

-- 跟踪列表（收藏）

CREATE TABLE Trace_List(
User_ID INT NOT NULL,-- 用户id
Item_ID INT NOT NULL,-- 商品id
Price DOUBLE NOT NULL,-- 商品价格（收藏时价格）
foreign key(User_ID) references User(User_ID),-- 外键 用户id
foreign key(Item_ID) references Item(Item_ID)--  外键 商品id
);

-- 折扣

CREATE TABLE Discount(
Item_ID INT NOT NULL,-- 商品id
Discount INT NOT NULL,-- 商品折扣（10:-10%）
Expire_Date DATETIME NOT NULL,-- 截止时间
foreign key(Item_ID) references Item(Item_ID)--  外键 商品id
);