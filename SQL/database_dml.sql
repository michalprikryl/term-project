/*USE TermProject
go*/

USE pri0115;
go

INSERT INTO [Language] ([ISO639-1Code], [ISO639-3Code], [Name]) VALUES ('en', 'eng', 'English')
INSERT INTO [Language] ([ISO639-1Code], [ISO639-3Code], [Name]) VALUES ('cs', 'cze', 'Czech')

INSERT INTO [PatternType] ([Name]) VALUES ('Marketing')
INSERT INTO [PatternType] ([Name]) VALUES ('IT')

INSERT INTO [DiagramType] ([Name], [Description]) VALUES ('Activity diagram', 'UML activity diagram')

INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Initial', 'initial node of activity diagram', 1, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Final', 'final node of activity diagram', 0, 1, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Activity', 'activity node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Fork', 'fork node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Join', 'join node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Condition', 'condition node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Composite', 'composite activity node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Precondition', 'precondition node of activity diagram', 0, 0, 1)
INSERT INTO [NodeType] ([Name],	[Description], Initial, [End], DiagramTypeID) VALUES ('Postcondition', 'postconditioin node of activity diagram', 0, 0, 1)

INSERT INTO [User] ([Name], LastName, Email, LanguageID) VALUES ('Franta', 'Novak', 'franta.novak@gmail.com', 1)

INSERT INTO [WorkSpace] ([Name], [Description], DataFile, DataFormat, CreationDate, UserID) VALUES ('default', 'default type of workspace', '', 'XML', GETDATE(), 1)