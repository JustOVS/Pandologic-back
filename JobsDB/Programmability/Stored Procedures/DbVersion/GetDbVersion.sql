create procedure [dbo].[GetDbVersion]
  as
    select
    Id,
    DbVersion as [Version]
    from dbo.DbVersion
