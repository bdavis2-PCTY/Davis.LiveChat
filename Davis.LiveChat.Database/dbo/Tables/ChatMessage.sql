CREATE TABLE [dbo].[ChatMessage] (
    [SentDateTime] DATETIME         NOT NULL,
    [Guid]         UNIQUEIDENTIFIER NOT NULL,
    [SentUserName] VARCHAR (50)     NOT NULL,
    [MessageText]  VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_ChatMessage] PRIMARY KEY NONCLUSTERED ([Guid])
);
GO

CREATE CLUSTERED INDEX ChatMessageIC1 ON [dbo].[ChatMessage] (SentDateTime ASC);
GO