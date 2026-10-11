CREATE DATABASE IF NOT EXISTS obstacledb;
USE obstacledb;

CREATE TABLE Reports (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ObstacleName VARCHAR(255),
    ObstacleHeight DECIMAL(10,2),
    ObstacleDescription TEXT,
    ObstacleLocation VARCHAR(255)
);
