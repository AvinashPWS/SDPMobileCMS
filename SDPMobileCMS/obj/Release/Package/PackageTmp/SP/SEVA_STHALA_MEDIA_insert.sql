USE [saidattapeetham]
GO

SET IDENTITY_INSERT [saidattapeetham].[dbo].[SEVA_STHALA_MEDIA] ON
GO

INSERT INTO [saidattapeetham].[dbo].[SEVA_STHALA_MEDIA]([ID],[MEDIA_HEADER],[MEDIA_TITLE],[MEDIA_TYPE],[MEDIA_ATTACHMENT],[DATETIME]) VALUES(2002,N'Sthala Seva',N'Shirdi In America- Sri Raghu Sharma',N'VIDEO',N'2akCvZEY5EI',N'2016-02-10 09:32:35 AM')
INSERT INTO [saidattapeetham].[dbo].[SEVA_STHALA_MEDIA]([ID],[MEDIA_HEADER],[MEDIA_TITLE],[MEDIA_TYPE],[MEDIA_ATTACHMENT],[DATETIME]) VALUES(2003,N'Sthala Seva',N'Shirdi In America-Mr Chivukula',N'VIDEO',N'AOVwH0FfYHM',N'2016-02-10 09:33:19 AM')
GO
print 'Inserted 2 records'

SET IDENTITY_INSERT [saidattapeetham].[dbo].[SEVA_STHALA_MEDIA] OFF
GO

