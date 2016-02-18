USE [saidattapeetham]
GO

SET IDENTITY_INSERT [saidattapeetham].[dbo].[EVENT_SPONSOR] ON
GO

INSERT INTO [saidattapeetham].[dbo].[EVENT_SPONSOR]([ID],[EVENT_NAME],[EVENT_DATETIME],[EVENT_INFO],[EVENT_ATTACHMENT],[DATETIME]) VALUES(3,N'Akshith has sponsored for today'' s Annadanam Seva',N'',N'',N'',N'2016-02-03 12:30:42 AM')
GO
print 'Inserted 1 records'

SET IDENTITY_INSERT [saidattapeetham].[dbo].[EVENT_SPONSOR] OFF
GO

