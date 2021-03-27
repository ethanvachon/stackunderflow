-- USE finaldatabase2;

-- CREATE TABLE questions (
--   id int AUTO_INCREMENT NOT NULL,
--   title VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
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
--   body VARCHAR(255) NOT NULL,
--   posted VARCHAR(255) NOT NULL,
--   rating int NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE


-- )