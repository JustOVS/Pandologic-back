create procedure [dbo].[GetJobViewsStatistics]
@dates [dbo].[ListOfDates] readonly
as
begin
  select  distinct jvp.[Date], sum(jvp.[Quantity]) over(order by jvp.[Date]) as [PredictionsQuantity], jvg.[ViewsQuantity], jg.[JobsQuantity]
  from [dbo].[JobViewPredictions] jvp
  join  (select distinct d.[Day], Count(jv.[Id]) over(order by d.[Day]) as [ViewsQuantity]
         from [dbo].[JobViews] jv
         join @dates d on datediff(Day,  jv.[ViewedTime], d.[Day]) = 0) as jvg 
  on jvg.[Day] = jvp.[Date]
  join (select d.[Day], Count(j.[Id]) as [JobsQuantity]
        from [dbo].[Jobs] j
        join @dates d on d.[Day] between j.[Opened] and j.[Closed]
        group by d.[Day]) as jg
  on jvp.[Date] = jg.[Day]
  where jvp.[Date] in (select [Day] from @dates)
end
