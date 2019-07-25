
select StudentName from Students
 where StudentId in (select StudentId from ScoreList where SQLServerDB>80)

 