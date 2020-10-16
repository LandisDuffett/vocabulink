-- USE YOUR-DB-HERE;

CREATE TABLE IF NOT EXISTS sentences (
   id int NOT NULL AUTO_INCREMENT,
   text VARCHAR(255) NOT NULL,
   userId VARCHAR(255),
   INDEX userId (userId),  
   PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS words (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    definition VARCHAR(255) NOT NULL,
    userId VARCHAR(255),
    img VARCHAR(255),
    INDEX userId (userId),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS sentencewords (
    id int NOT NULL AUTO_INCREMENT,
    sentenceId int NOT NULL,
    wordId int NOT NULL,
    userId VARCHAR(255) NOT NULL,

    PRIMARY KEY (id),
    INDEX (sentenceId, wordId),
    INDEX (userId),

    FOREIGN KEY (sentenceId)
        REFERENCES sentences(id)
        ON DELETE CASCADE,

    FOREIGN KEY (wordId)
        REFERENCES words(id)
        ON DELETE CASCADE
);


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;
