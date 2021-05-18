-- USE finaldatabase2;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   rating INT,
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE questions (
--   id int AUTO_INCREMENT NOT NULL,
--   title VARCHAR(1000) NOT NULL,
--   body VARCHAR(1000) NOT NULL,
--   posted VARCHAR(255) NOT NULL,
--   rating int NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE

-- );

-- CREATE TABLE answers (
--   id int AUTO_INCREMENT NOT NULL,
--   body VARCHAR(1000) NOT NULL,
--   posted VARCHAR(255) NOT NULL,
--   rating int NOT NULL,
--   questionId int NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY(questionId)
--     REFERENCES questions(id)
--     ON DELETE CASCADE
-- );

-- CREATE TABLE ratings (
--   id int AUTO_INCREMENT NOT NULL,
--   profileId VARCHAR(255),
--   ratedId int NOT NULL,
--   rating BOOLEAN NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(profileId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY(ratedId)
--     REFERENCES questions(id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE answerratings (
--   id int AUTO_INCREMENT NOT NULL,
--   profileId VARCHAR(255),
--   answerId int NOT NULL,
--   rating BOOLEAN NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(profileId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY(answerId)
--     REFERENCES answers(id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE following (
--   id int AUTO_INCREMENT NOT NULL,
--   followerId VARCHAR(255) NOT NULL,
--   followingId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(followingId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY(followerId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )