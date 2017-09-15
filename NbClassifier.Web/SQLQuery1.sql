ALTER DATABASE [NbClassifierDatabase]
    MODIFY FILE
    (
        NAME = [NbClassifierDatabase],
        MAXSIZE = 30MB
    )


/*
select 'English', Review from dbo.NegativeReviewsFullTrainSet;


insert into NbClassifierDatabase.dbo.Reviews
select Review, 1 from dbo.NegativeReviewsFullTrainSet*/