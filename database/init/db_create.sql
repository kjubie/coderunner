CREATE TABLE benutzer(
    id INT PRIMARY KEY NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE written_language (
    id INT PRIMARY KEY NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE programming_language (
    id INT PRIMARY KEY NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE tag (
    id INT PRIMARY KEY NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE collection (
    id INT PRIMARY KEY NOT NULL,
    title VARCHAR(255) NOT NULL,
    created TIMESTAMP NOT NULL, -- with time zone ?
    fk_user_id INT REFERENCES benutzer(id) NOT NULL -- null ?
);

CREATE TABLE collection_tag (
    id INT PRIMARY KEY NOT NULL,
    fk_tag_id INT REFERENCES tag(id) NOT NULL,
    fk_collection_id INT REFERENCES collection(id) NOT NULL
);

CREATE TABLE collection_language (
    id INT PRIMARY KEY NOT NULL,
    full_title VARCHAR(255) NOT NULL, -- this not null?
    short_title VARCHAR(255) NOT NULL, -- or this ?
    introduction TEXT,
    fk_collection_id INT REFERENCES collection(id) NOT NULL
);

CREATE TABLE test_suite (
    id INT PRIMARY KEY NOT NULL,
    question_type VARCHAR(255) NOT NULL, -- this not null?
    prefill TEXT,
    solution TEXT,
    complexity INT 
);

-- what not null?
CREATE TABLE test_case (
    id INT PRIMARY KEY NOT NULL,
    order_used INT,
    description TEXT,
    standard_input TEXT,
    expected_output TEXT,
    additional_data TEXT,
    points INT,
    fk_test_suite_id INT REFERENCES test_suite(id) NOT NULL 
);

CREATE TABLE exercise (
    id INT PRIMARY KEY NOT NULL,
    title VARCHAR(255) NOT NULL,
    created TIMESTAMP NOT NULL, -- with time zone ?
    fk_user_id INT REFERENCES benutzer(id) NOT NULL -- null ?
);

CREATE TABLE exercise_header (
    id INT PRIMARY KEY NOT NULL,
    full_title VARCHAR(255) NOT NULL, -- this null ?
    short_title VARCHAR(255) NOT NULL, -- or this ?
    introduction TEXT
);

CREATE TABLE exercise_version (
    id INT PRIMARY KEY NOT NULL,
    version_number INT NOT NULL,
    creator_rating INT, -- not null ?
    creator_difficulty INT, -- not null ?
    last_modified TIMESTAMP NOT NULL, -- with time zone ?
    fk_user_id INT REFERENCES benutzer(id) NOT NULL,
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL
);

CREATE TABLE exercise_language (
    id INT PRIMARY KEY NOT NULL,
    fk_written_language_id INT REFERENCES written_language(id) NOT NULL,
    fk_exercise_version_id INT REFERENCES exercise_version(id) NOT NULL,
    fk_exercise_header_id INT REFERENCES exercise_header(id) NOT NULL
);

CREATE TABLE exercise_body (
    id INT PRIMARY KEY NOT NULL,
    fk_programming_language_id INT REFERENCES programming_language(id) NOT NULL,
    description TEXT,
    example TEXT,
    hint TEXT,
    fk_exercise_language_id INT REFERENCES exercise_language(id) NOT NULL,
    fk_test_suite_id INT REFERENCES test_suite(id) NOT NULL -- null ?
);

CREATE TABLE collection_exercise (
    id INT PRIMARY KEY NOT NULL,
    fk_collection_language_id INT REFERENCES collection_language(id) NOT NULL,
    version_number INT NOT NULL,
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL,
    fk_programming_language_id INT REFERENCES programming_language(id) NOT NULL,
    fk_written_language_id INT REFERENCES written_language(id) NOT NULL
);

CREATE TABLE comment (
    id INT PRIMARY KEY NOT NULL,
    message TEXT NOT NULL,
    created TIMESTAMP NOT NULL, --with time zone ?
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL,
    fk_user_id INT REFERENCES benutzer(id) NOT NULL
);

CREATE TABLE rating (
    id INT PRIMARY KEY NOT NULL,
    number INT NOT NULL,
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL,
    fk_user_id INT REFERENCES benutzer(id) NOT NULL
);

CREATE TABLE difficulty (
    id INT PRIMARY KEY NOT NULL,
    number INT NOT NULL,
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL,
    fk_user_id INT REFERENCES benutzer(id) NOT NULL
);

CREATE TABLE exercise_tag (
    id INT PRIMARY KEY NOT NULL,
    fk_tag_id INT REFERENCES tag(id) NOT NULL,
    fk_exercise_id INT REFERENCES exercise(id) NOT NULL
);