CREATE TABLE dbo.users (
  [id] bigint NOT NULL IDENTITY,
  [user_name] varchar(50),
  [password] varchar(130),
  [full_name] varchar(120),
  [refresh_token] varchar(500),
  [refresh_token_expiry_time] datetime2(6) NOT NULL,
  PRIMARY KEY ([id])
)