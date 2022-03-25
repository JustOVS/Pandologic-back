create table [dbo].[JobViewPredictions]
(
	[Id] bigint not null identity(1,1) primary key,
	[JobId] bigint not null references [dbo].[Jobs] (Id),
	[Quantity] bigint not null,
	[Date] date not null
)
