CREATE TABLE [dbo].[Vehicle] (
    [Id]             INT           NOT NULL IDENTITY(1, 1),
    [registration]   NCHAR (10)    NULL,
    [mark]           NVARCHAR (50) NOT NULL,
    [acquisitionDay] DATE          NULL,
    [price]          DECIMAL (18)  NULL,
    [resaleValue]    DECIMAL (18)  NULL,
    [active]         BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

