CREATE TABLE "polzovatel" (
	"polzovateli" serial NOT NULL PRIMARY KEY,
	"familia" VARCHAR(255) NOT NULL,
	"ima" VARCHAR(255) NOT NULL,
	"login" VARCHAR(255) NOT NULL,
	"pass" VARCHAR(255) NOT NULL	
);

CREATE TABLE "tovar" (
	"tovars" serial NOT NULL PRIMARY KEY,
	"nazvania" VARCHAR(255) NOT NULL,
	"opisanie" VARCHAR(255) NOT NULL
);



CREATE TABLE "zakaz" (
	"zakaz" serial NOT NULL PRIMARY KEY,
	"nomer_zakaza" integer NOT NULL,
	"id_familia" integer NOT NULL,
	"id_zakaz" integer NOT NULL
);


CREATE TABLE "zakaz_tovar" (
	
	
);





