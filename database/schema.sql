-- *************************************************************************************************
-- This script creates all of the database objects (tables, constraints, etc) for the database
-- *************************************************************************************************


-- CREATE statements go here


DROP TABLE users;
DROP TABLE salt;
DROP TABLE game_types;
DROP TABLE tournaments;
DROP TABLE tournament_competitors;
DROP TABLE matches;
DROP TABLE match_users;
DROP TABLE teams;
DROP TABLE team_competitors;
DROP TABLE match_teams;


CREATE TABLE users (
	user_id int identity not null,
	username varchar(15) not null,
	email varchar(50) not null,
	password varchar(30) not null,
	role varchar(10) not null,
	first_name varchar(30),
	last_name varchar(30),
	bio varchar(300),

	CONSTRAINT pk_user_id primary key (user_id),
);

CREATE TABLE salt (
	salt varchar(3) not null,
	user_id int not null,

	CONSTRAINT fk_salt_user_id FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE game_types (
	game_id int identity not null,
	game_type varchar(20) not null,

	CONSTRAINT pk_game_id primary key (game_id),
);

CREATE TABLE tournaments (
	tournament_id int identity not null,
	tournament_name varchar(50) not null,
	organizer_id int not null,
	start_date datetime not null,
	end_date datetime,
	game_id int,
	competitor_limit int not null,
	

	CONSTRAINT pk_tournament_id primary key (tournament_id),
	CONSTRAINT fk_tournaments_game_id FOREIGN KEY (game_id) REFERENCES game_types(game_id),
	CONSTRAINT fk_tournaments_organizer_id FOREIGN KEY (organizer_id) REFERENCES users(user_id)
	
);

CREATE TABLE tournament_competitors(
	tournament_id int not null,
	competitor_id int not null,
	wins int not null,
	losses int not null,
	
	CONSTRAINT fk_tournament_competitors_tournament_id FOREIGN KEY (tournament_id) REFERENCES tournaments(tournament_id),
	CONSTRAINT fk_tournament_competitors_competitor_id FOREIGN KEY (competitor_id) REFERENCES users(user_id),
);

CREATE TABLE matches (
	match_id int identity not null,
	tournament_id int not null,
	bracket_tier int not null,

	
	CONSTRAINT pk_match_id primary key (match_id),
	CONSTRAINT fk_matches_tournament_id FOREIGN KEY (tournament_id) REFERENCES tournaments(tournament_id)

);

CREATE TABLE match_users (
	match_id int not null,
	user1_id int not null,
	user2_id int not null,
	
	CONSTRAINT fk_match_users_match_id FOREIGN KEY (match_id) REFERENCES matches(match_id),
	CONSTRAINT fk_match_users_user2_id FOREIGN KEY (user2_id) REFERENCES users(user_id),
	CONSTRAINT fk_match_users_user1_id FOREIGN KEY (user1_id) REFERENCES users(user_id),
);

CREATE TABLE teams (

	team_id int identity not null,
	team_name varchar(30) not null

	CONSTRAINT pk_team_id primary key (team_id),
);

CREATE TABLE team_competitors (

	team_id int not null,
	user_id int not null,

	CONSTRAINT fk_team_competitors_team_id FOREIGN KEY (team_id) REFERENCES teams(team_id),
	CONSTRAINT fk_team_competitors_user_id FOREIGN KEY (user_id) REFERENCES users(user_id),
);

CREATE TABLE match_teams (
	match_id int not null,
	team1_id int not null,
	team2_id int not null,

	CONSTRAINT fk_match_teams_match_id FOREIGN KEY (match_id) REFERENCES matches(match_id),
	CONSTRAINT fk_match_teams_team2_id FOREIGN KEY (team2_id) REFERENCES teams(team_id),
	CONSTRAINT fk_match_teams_team1_id FOREIGN KEY (team1_id) REFERENCES teams(team_id),
);

