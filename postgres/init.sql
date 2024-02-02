CREATE TABLE if not exists Survey
(
    Id   SERIAL PRIMARY KEY,
    Name VARCHAR(200) NOT NULL
);

CREATE TABLE if not exists Questions
(
    Id       SERIAL PRIMARY KEY,
    Name     VARCHAR(200) NOT NULL,
    SurveyId INT,

    FOREIGN KEY (SurveyId) REFERENCES Survey (Id) ON DELETE CASCADE
);

CREATE TABLE if not exists Answers
(
    Id         SERIAL PRIMARY KEY,
    Name       VARCHAR(200) NOT NULL,
    QuestionId INT,

    FOREIGN KEY (QuestionId) REFERENCES Questions (Id) ON DELETE CASCADE
);

CREATE TABLE if not exists Results
(
    Id          SERIAL PRIMARY KEY,
    SurveyId    INT,
    QuestionId  INT,
    AnswerId    INT,
    InterviewSession VARCHAR(50),


    FOREIGN KEY (SurveyId) REFERENCES Survey (Id) ON DELETE CASCADE,
    FOREIGN KEY (QuestionId) REFERENCES Questions (Id) ON DELETE CASCADE,
    FOREIGN KEY (AnswerId) REFERENCES Answers (Id) ON DELETE CASCADE
);

INSERT INTO Survey(Id, Name) VALUES (1, 'Тест1');

INSERT INTO Questions(Id, Name, SurveyId) VALUES (1, 'В каком городе вы проживаете?', 1);
INSERT INTO Questions(Id, Name, SurveyId) VALUES (2, 'Ваша зарабатная плата в месяц?', 1);
INSERT INTO Questions(Id, Name, SurveyId) VALUES (3, 'Довольны ли вы своей зарплатой?', 1);

INSERT INTO Answers(Id, Name, QuestionId) VALUES (1, 'МСК', 1);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (2, 'СПБ', 1);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (3, 'НСК', 1);

INSERT INTO Answers(Id, Name, QuestionId) VALUES (4, 'от 50 т.р. до 100 т.р.', 2);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (5, 'от 100 т.р. до 200 т.р.', 2);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (6, 'от 200 т.р.', 2);

INSERT INTO Answers(Id, Name, QuestionId) VALUES (7, 'Да', 3);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (8, 'Нет', 3);
INSERT INTO Answers(Id, Name, QuestionId) VALUES (9, 'Затрудняюсь ответить', 3);
