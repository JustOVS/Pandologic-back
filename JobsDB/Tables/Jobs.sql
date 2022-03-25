create table [dbo].[Jobs]
(
	[Id] bigint not null identity(1,1) primary key, 
    [Name] nvarchar(255) not null, 
    [Description] nvarchar(max) null,
    [Opened] datetime2 not null constraint DF_Jobs_Opened default getutcdate(),
    [Closed] datetime2 null
)
