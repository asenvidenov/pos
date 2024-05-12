USE [pos]
GO
/****** Object:  Table [dbo].[posCashPrice]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posCashPrice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GoodsID] [int] NOT NULL,
	[ObjectID] [int] NOT NULL,
	[CashEnabled] [bit] NOT NULL,
	[PosPrinter] [tinyint] NULL,
	[CashPrice] [real] NOT NULL,
	[DFPrice] [real] NULL,
 CONSTRAINT [PK_posCashPrice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posDiscount]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posDiscount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DName] [nvarchar](50) NOT NULL,
	[DPercent] [tinyint] NOT NULL,
	[DAccount] [nvarchar](50) NOT NULL,
	[DEnabled] [bit] NOT NULL,
	[DOwner] [nvarchar](50) NULL,
	[DStart] [datetime] NULL,
	[Dend] [datetime] NULL,
 CONSTRAINT [PK_posDiscount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posFP]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posFP](
	[FP] [nchar](8) NOT NULL,
	[Prefix] [nchar](1) NULL,
	[Limit] [nchar](7) NULL,
	[PortSpeed] [smallint] NULL,
	[Type] [nvarchar](25) NULL,
	[ZReport] [smalldatetime] NULL,
	[ZBlocked] [bit] NULL,
 CONSTRAINT [PK_posFP] PRIMARY KEY CLUSTERED 
(
	[FP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posGoods]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posGoods](
	[GoodsID] [int] IDENTITY(1,1) NOT NULL,
	[isGroup] [bit] NOT NULL,
	[GParent] [int] NOT NULL,
	[CashName] [nvarchar](50) NULL,
	[CashCode] [nvarchar](50) NULL,
	[DiscountAllowed] [bit] NULL,
 CONSTRAINT [PK_posGoods] PRIMARY KEY CLUSTERED 
(
	[GoodsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posObjects]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posObjects](
	[ObjectID] [int] IDENTITY(1,1) NOT NULL,
	[ObjName] [nvarchar](50) NOT NULL,
	[Parent] [int] NOT NULL,
	[ObjCode] [nvarchar](10) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_posObjects] PRIMARY KEY CLUSTERED 
(
	[ObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOps]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOps](
	[OpID] [int] IDENTITY(1,1) NOT NULL,
	[OpName] [nvarchar](50) NOT NULL,
	[OpPass] [nvarchar](50) NOT NULL,
	[OpRole] [smallint] NULL,
	[OpFName] [nvarchar](255) NOT NULL,
	[OpCode] [nchar](4) NOT NULL,
	[OpApp] [nvarchar](50) NOT NULL,
	[RoleStart] [smalldatetime] NULL,
	[RoleEnd] [smalldatetime] NULL,
 CONSTRAINT [PK_posOps] PRIMARY KEY CLUSTERED 
(
	[OpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOpsLog]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOpsLog](
	[ID] [uniqueidentifier] NOT NULL,
	[opID] [int] NOT NULL,
	[opAction] [nvarchar](25) NOT NULL,
	[opActionTime] [datetime] NOT NULL,
 CONSTRAINT [PK_posOpsLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOpsRolesLog]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOpsRolesLog](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[opID] [int] NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Role] [smallint] NOT NULL,
	[Author] [int] NOT NULL,
	[ActionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_posOpsRolesLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOrderDetails]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOrderDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[OpID] [int] NOT NULL,
	[GoodsID] [int] NOT NULL,
	[Cnt] [int] NOT NULL,
	[Annul] [int] NOT NULL,
	[Modif] [nvarchar](50) NULL,
	[CashPrice] [real] NOT NULL,
 CONSTRAINT [PK_posOrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOrders]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOrders](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[OpID] [int] NOT NULL,
	[DateOpen] [smalldatetime] NOT NULL,
	[DateModified] [smalldatetime] NULL,
	[DateClosed] [smalldatetime] NULL,
	[ObjectID] [int] NOT NULL,
	[CurrentSum] [real] NULL,
	[FinalSum] [real] NULL,
	[RE] [bit] NULL,
	[REOrderID] [bigint] NULL,
 CONSTRAINT [PK_posOrders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posOrdersChrono]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posOrdersChrono](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[OpID] [int] NOT NULL,
	[GoodsID] [int] NOT NULL,
	[Cnt] [int] NOT NULL,
	[Modiff] [nvarchar](50) NULL,
	[Created] [smalldatetime] NOT NULL,
	[OrderNum] [smallint] NOT NULL,
	[Confirmed] [bit] NOT NULL,
	[Accepted] [bit] NOT NULL,
	[Printed] [bit] NOT NULL,
	[OpName] [nvarchar](255) NULL,
	[OpCode] [nchar](4) NULL,
	[OpRole] [smallint] NULL,
 CONSTRAINT [PK_posOrdersChrono] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posRoles]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posRoles](
	[Role] [smallint] NOT NULL,
	[Descr] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_posRoles] PRIMARY KEY CLUSTERED 
(
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSales]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posSales](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[OpID] [int] NOT NULL,
	[OrderSum] [real] NOT NULL,
	[CardSum] [real] NOT NULL,
	[CashSum] [real] NOT NULL,
	[DiscountSum] [real] NULL,
	[DiscountPercent] [smallint] NULL,
	[VAT] [tinyint] NULL,
	[FPN] [nchar](8) NULL,
	[OpCode] [nchar](4) NULL,
	[SellNum] [bigint] NULL,
	[RE] [bit] NULL,
	[opName] [nvarchar](255) NULL,
	[opRole] [smallint] NULL,
	[VATAmount] [real] NULL,
	[FlightNum] [nchar](7) NULL,
	[REOrderID] [bigint] NULL,
	[HasCopy] [bit] NULL,
 CONSTRAINT [PK_posSales] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posSalesPay]    Script Date: 25.3.2020 22:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posSalesPay](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleID] [bigint] NOT NULL,
	[Card] [bit] NULL,
	[Currency] [int] NOT NULL,
	[Amount] [real] NOT NULL,
 CONSTRAINT [PK_posSalesPay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[posCashPrice] ADD  CONSTRAINT [DF_posCashPrice_CashEnabled]  DEFAULT ((0)) FOR [CashEnabled]
GO
ALTER TABLE [dbo].[posDiscount] ADD  CONSTRAINT [DF_posDiscount_DPercent]  DEFAULT ((0)) FOR [DPercent]
GO
ALTER TABLE [dbo].[posDiscount] ADD  CONSTRAINT [DF_posDiscount_DEnabled]  DEFAULT ((0)) FOR [DEnabled]
GO
ALTER TABLE [dbo].[posGoods] ADD  CONSTRAINT [DF_posGoods_isGroup]  DEFAULT ((0)) FOR [isGroup]
GO
ALTER TABLE [dbo].[posGoods] ADD  CONSTRAINT [DF_posGoods_GParent]  DEFAULT ((0)) FOR [GParent]
GO
ALTER TABLE [dbo].[posObjects] ADD  CONSTRAINT [DF_posObjects_Parent]  DEFAULT ((0)) FOR [Parent]
GO
ALTER TABLE [dbo].[posOrderDetails] ADD  CONSTRAINT [DF_posOrderDetails_Storno]  DEFAULT ((0)) FOR [Annul]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_Cnt]  DEFAULT ((0)) FOR [Cnt]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_OrderNum]  DEFAULT ((1)) FOR [OrderNum]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_Confirmed]  DEFAULT ((0)) FOR [Confirmed]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_Accepted]  DEFAULT ((0)) FOR [Accepted]
GO
ALTER TABLE [dbo].[posOrdersChrono] ADD  CONSTRAINT [DF_posOrdersChrono_Printed]  DEFAULT ((0)) FOR [Printed]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_OrderSum]  DEFAULT ((0)) FOR [OrderSum]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_CardSum]  DEFAULT ((0)) FOR [CardSum]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_CashSum]  DEFAULT ((0)) FOR [CashSum]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_DiscountSum]  DEFAULT ((0)) FOR [DiscountSum]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_DiscountPercent]  DEFAULT ((0)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[posSales] ADD  CONSTRAINT [DF_posSales_VAT]  DEFAULT ((0)) FOR [VAT]
GO
ALTER TABLE [dbo].[posCashPrice]  WITH CHECK ADD  CONSTRAINT [FK_posCashPrice_posGoods] FOREIGN KEY([GoodsID])
REFERENCES [dbo].[posGoods] ([GoodsID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posCashPrice] CHECK CONSTRAINT [FK_posCashPrice_posGoods]
GO
ALTER TABLE [dbo].[posCashPrice]  WITH CHECK ADD  CONSTRAINT [FK_posCashPrice_posObjects] FOREIGN KEY([ObjectID])
REFERENCES [dbo].[posObjects] ([ObjectID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posCashPrice] CHECK CONSTRAINT [FK_posCashPrice_posObjects]
GO
ALTER TABLE [dbo].[posOps]  WITH CHECK ADD  CONSTRAINT [FK_posOps_posRoles] FOREIGN KEY([OpRole])
REFERENCES [dbo].[posRoles] ([Role])
GO
ALTER TABLE [dbo].[posOps] CHECK CONSTRAINT [FK_posOps_posRoles]
GO
ALTER TABLE [dbo].[posOpsLog]  WITH CHECK ADD  CONSTRAINT [FK_posOpsLog_posOps] FOREIGN KEY([opID])
REFERENCES [dbo].[posOps] ([OpID])
GO
ALTER TABLE [dbo].[posOpsLog] CHECK CONSTRAINT [FK_posOpsLog_posOps]
GO
ALTER TABLE [dbo].[posOpsRolesLog]  WITH CHECK ADD  CONSTRAINT [FK_posOpsRolesLog_posRoles] FOREIGN KEY([Role])
REFERENCES [dbo].[posRoles] ([Role])
GO
ALTER TABLE [dbo].[posOpsRolesLog] CHECK CONSTRAINT [FK_posOpsRolesLog_posRoles]
GO
ALTER TABLE [dbo].[posOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_posOrderDetails_posGoods] FOREIGN KEY([GoodsID])
REFERENCES [dbo].[posGoods] ([GoodsID])
GO
ALTER TABLE [dbo].[posOrderDetails] CHECK CONSTRAINT [FK_posOrderDetails_posGoods]
GO
ALTER TABLE [dbo].[posOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_posOrderDetails_posOps] FOREIGN KEY([OpID])
REFERENCES [dbo].[posOps] ([OpID])
GO
ALTER TABLE [dbo].[posOrderDetails] CHECK CONSTRAINT [FK_posOrderDetails_posOps]
GO
ALTER TABLE [dbo].[posOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_posOrderDetails_posOrderDetails] FOREIGN KEY([ID])
REFERENCES [dbo].[posOrderDetails] ([ID])
GO
ALTER TABLE [dbo].[posOrderDetails] CHECK CONSTRAINT [FK_posOrderDetails_posOrderDetails]
GO
ALTER TABLE [dbo].[posOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_posOrderDetails_posOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[posOrders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posOrderDetails] CHECK CONSTRAINT [FK_posOrderDetails_posOrders]
GO
ALTER TABLE [dbo].[posOrders]  WITH CHECK ADD  CONSTRAINT [FK_posOrders_posObjects] FOREIGN KEY([ObjectID])
REFERENCES [dbo].[posObjects] ([ObjectID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posOrders] CHECK CONSTRAINT [FK_posOrders_posObjects]
GO
ALTER TABLE [dbo].[posOrders]  WITH CHECK ADD  CONSTRAINT [FK_posOrders_posOrders] FOREIGN KEY([REOrderID])
REFERENCES [dbo].[posOrders] ([OrderID])
GO
ALTER TABLE [dbo].[posOrders] CHECK CONSTRAINT [FK_posOrders_posOrders]
GO
ALTER TABLE [dbo].[posOrdersChrono]  WITH CHECK ADD  CONSTRAINT [FK_posOrdersChrono_posGoods] FOREIGN KEY([GoodsID])
REFERENCES [dbo].[posGoods] ([GoodsID])
GO
ALTER TABLE [dbo].[posOrdersChrono] CHECK CONSTRAINT [FK_posOrdersChrono_posGoods]
GO
ALTER TABLE [dbo].[posOrdersChrono]  WITH CHECK ADD  CONSTRAINT [FK_posOrdersChrono_posOps] FOREIGN KEY([OpID])
REFERENCES [dbo].[posOps] ([OpID])
GO
ALTER TABLE [dbo].[posOrdersChrono] CHECK CONSTRAINT [FK_posOrdersChrono_posOps]
GO
ALTER TABLE [dbo].[posOrdersChrono]  WITH CHECK ADD  CONSTRAINT [FK_posOrdersChrono_posOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[posOrders] ([OrderID])
GO
ALTER TABLE [dbo].[posOrdersChrono] CHECK CONSTRAINT [FK_posOrdersChrono_posOrders]
GO
ALTER TABLE [dbo].[posOrdersChrono]  WITH CHECK ADD  CONSTRAINT [FK_posOrdersChrono_posRoles] FOREIGN KEY([OpRole])
REFERENCES [dbo].[posRoles] ([Role])
GO
ALTER TABLE [dbo].[posOrdersChrono] CHECK CONSTRAINT [FK_posOrdersChrono_posRoles]
GO
ALTER TABLE [dbo].[posSales]  WITH CHECK ADD  CONSTRAINT [FK_posSales_posOps] FOREIGN KEY([OpID])
REFERENCES [dbo].[posOps] ([OpID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posSales] CHECK CONSTRAINT [FK_posSales_posOps]
GO
ALTER TABLE [dbo].[posSales]  WITH CHECK ADD  CONSTRAINT [FK_posSales_posOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[posOrders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posSales] CHECK CONSTRAINT [FK_posSales_posOrders]
GO
ALTER TABLE [dbo].[posSales]  WITH CHECK ADD  CONSTRAINT [FK_posSales_posOrders1] FOREIGN KEY([REOrderID])
REFERENCES [dbo].[posOrders] ([OrderID])
GO
ALTER TABLE [dbo].[posSales] CHECK CONSTRAINT [FK_posSales_posOrders1]
GO
ALTER TABLE [dbo].[posSalesPay]  WITH CHECK ADD  CONSTRAINT [FK_posSalesPay_posSales] FOREIGN KEY([SaleID])
REFERENCES [dbo].[posSales] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posSalesPay] CHECK CONSTRAINT [FK_posSalesPay_posSales]
GO
