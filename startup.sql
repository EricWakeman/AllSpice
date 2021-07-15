CREATE TABLE recipes(  
    id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'update time',
    title varchar(255) COMMENT 'Recipe Description',
    body varchar(255) COMMENT 'Recipe Description',
    imgUrl varchar(255) COMMENT 'Recipe Description'
) default charset utf8 COMMENT '';
CREATE TABLE ingredients(  
    id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
    create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    update_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'update time',
    body varchar(255) COMMENT 'Ingredient Description',
    recipeId int NOT  NULL  COMMENT 'FK: recipe',
    FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE 
) default charset utf8 COMMENT '';
INSERT INTO ingredients (body,recipeId) VALUES ("Bread", 2);

INSERT INTO recipes (title,body,imgUrl) VALUES  ("Cheesey Marmite Toast", "Marmite is already repulsive enough, it doesn't need to go and ruin cheddar cheese and mustard, too.", "https://hips.hearstapps.com/del.h-cdn.co/assets/16/35/1472681490-1c78a78d1f5647949265032d642261b2.jpg?crop=1xw:1.0xh;center,top&resize=980:*" );
