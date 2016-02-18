USE [saidattapeetham]
GO

SET IDENTITY_INSERT [saidattapeetham].[dbo].[EVENT_REGULAR] ON
GO

INSERT INTO [saidattapeetham].[dbo].[EVENT_REGULAR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(7,N'Siva Abhisekam(Every Monday)',N'7.00 pm',N'',N'',N'2016-01-24 03:54:01 PM')
INSERT INTO [saidattapeetham].[dbo].[EVENT_REGULAR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(8,N'Ganesh Abhisekam(Every sankatahara chaturdhi)',N'7.00 pm',N'',N'',N'2016-01-24 03:54:43 PM')
INSERT INTO [saidattapeetham].[dbo].[EVENT_REGULAR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(9,N'Samuhika Satyanarayana Vratham(Every Pournami)',N'6.30 pm',N'',N'',N'2016-01-24 03:56:05 PM')
INSERT INTO [saidattapeetham].[dbo].[EVENT_REGULAR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(10,N'Ayyappa swamy Puja & Bhajans(Every month first saturday)',N'6.30 pm',N'',N'',N'2016-01-24 03:56:43 PM')
INSERT INTO [saidattapeetham].[dbo].[EVENT_REGULAR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(11,N'Subhramanya swamy(Murugan) Abhisekam * Pre registration is required for arrangements.',N'(Every Sudda Srasthi)',N'',N'',N'2016-01-24 03:58:45 PM')
GO
print 'Inserted 5 records'

SET IDENTITY_INSERT [saidattapeetham].[dbo].[EVENT_REGULAR] OFF
GO

