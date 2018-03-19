SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE function [dbo].[ExplodeDate](@StartDate Date)returns table as
return
(
	with AllDate(CalcDate) as
	(
		select cast(DATEADD(D,DATEDIFF(D,0,SYSDATETIME())-DATEDIFF(D,@StartDate,sysdatetime()),0) as date)
		union all
		select DATEADD(D,1,CalcDate)
		from AllDate
		where DATEADD(D,1,CalcDate)<= SYSDATETIME()
	)
	select CalcDate from AllDate
)
GO
