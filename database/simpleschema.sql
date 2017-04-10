DROP TABLE users;
DROP TABLE tournaments;
DROP TABLE tournament_competitors;
DROP TABLE matches;




CREATE TABLE users (
	user_id int identity not null,
	username varchar(15) not null,
	email varchar(50) not null,
	password varchar(30) not null,
	role varchar(10) not null,
	salt varchar(3) not null,

	CONSTRAINT pk_user_id primary key (user_id),
);

CREATE TABLE tournaments (
	tournament_id int identity not null,
	tournament_name varchar(50) not null,
	organizer_id int not null,
	start_date datetime not null,
	end_date datetime,
	competitor_limit int not null,
	

	CONSTRAINT pk_tournament_id primary key (tournament_id),
	CONSTRAINT fk_tournaments_game_id FOREIGN KEY (game_id) REFERENCES game_types(game_id),
	CONSTRAINT fk_tournaments_organizer_id FOREIGN KEY (organizer_id) REFERENCES users(user_id)
	
);

CREATE TABLE tournament_competitors(
	tournament_id int not null,
	competitor_id int not null,
	
	CONSTRAINT fk_tournament_competitors_tournament_id FOREIGN KEY (tournament_id) REFERENCES tournaments(tournament_id),
	CONSTRAINT fk_tournament_competitors_competitor_id FOREIGN KEY (competitor_id) REFERENCES users(user_id),
);

CREATE TABLE matches (
	match_id int identity not null,
	user1_id int not null,
	user2_id int not null,
	tournament_id int not null,

	
	CONSTRAINT pk_match_id primary key (match_id),
	CONSTRAINT fk_matches_tournament_id FOREIGN KEY (tournament_id) REFERENCES tournaments(tournament_id)
	CONSTRAINT fk_match_users_user2_id FOREIGN KEY (user2_id) REFERENCES users(user_id),
	CONSTRAINT fk_match_users_user1_id FOREIGN KEY (user1_id) REFERENCES users(user_id),

);
