/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
print N'Begin post deployment process.'
declare @curver varchar(max)
select @curver = [Id] from [dbo].[DbVersion]

declare @dbVer nvarchar(8)
declare @dbType nvarchar(max)
select @dbVer = [DbVersion] from [dbo].[DbVersion]
select @dbType = [Type] from [dbo].[DbVersion]

if @curver is null
  set @curver = ''

-- Block for default settings

--if @curver <= ''
--begin
--end

-- Example How to add new versions of Db

--if @dbVer < N'20220323'
--begin
--  :r ./Upgrade_postdeploy_20220323.sql
--end

  set @dbVer = N'20220322'

if @curver <= '' and upper(N'$(DbType)') = 'MOCK'
begin
  print N'Mocking data...';
  exec [dbo].[Mock_TestData];
end

print N'Setting up version...'
exec [dbo].[SetDbVersion] N'$(DbVer)', N'$(DbType)', @dbVer;