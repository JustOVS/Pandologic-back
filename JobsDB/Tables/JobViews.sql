create table [dbo].[JobViews]
(
	[Id] bigint not null identity(1,1) primary key,
	[JobId] bigint not null references [dbo].[Jobs] (Id),
	[UserId] bigint null, 
	[ViewedTime] datetime2 not null constraint DF_JobViews_Viewed default getutcdate()
)
