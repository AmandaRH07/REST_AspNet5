CREATE TABLE dbo.books (
  [id] bigint NOT NULL IDENTITY,
  [author] varchar(max),
  [launch_date] datetime2(6) NOT NULL,
  [price] decimal(38,2) NOT NULL,
  [title] varchar(max),
  PRIMARY KEY ([id])
)