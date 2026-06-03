CREATE DATABASE KafkaTest;
GO

USE KafkaTest;
GO

IF OBJECT_ID('KafkaMessageSample', 'U') IS NOT NULL
BEGIN
DROP TABLE KafkaMessageSample;
END
GO

CREATE TABLE KafkaMessageSample
(
Id INT IDENTITY(1,1) PRIMARY KEY,

UserId NVARCHAR(50) NOT NULL,

Title NVARCHAR(200) NOT NULL,

MessageBody NVARCHAR(MAX) NOT NULL,

KafkaTopic NVARCHAR(100) NOT NULL,

SendDateTime DATETIME NOT NULL,

ReceivedAt DATETIME NOT NULL
    DEFAULT GETDATE()

);
GO

CREATE INDEX IX_KafkaMessageSample_UserId
ON KafkaMessageSample(UserId);

CREATE INDEX IX_KafkaMessageSample_ReceivedAt
ON KafkaMessageSample(ReceivedAt);
GO
