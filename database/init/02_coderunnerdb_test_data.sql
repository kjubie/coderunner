INSERT INTO public.benutzer (id, name) VALUES (1, 'Hans');
INSERT INTO public.benutzer (id, name) VALUES (2, 'Michi');
INSERT INTO public.benutzer (id, name) VALUES (3, 'Jacob');
INSERT INTO public.benutzer (id, name) VALUES (4, 'Roman');

INSERT INTO public.exercise (id, title, created, fk_user_id) VALUES (1, 'Test Exercise 1', '2020-11-02 21:36:26.000000', 1);

INSERT INTO public.exercise_version (id, version_number, creator_rating, creator_difficulty, last_modified, fk_user_id, fk_exercise_id) VALUES (1, 1, 3, 4, '2020-11-02 21:41:57.000000', 1, 1);

INSERT INTO public.comment (id, message, created, fk_exercise_id, fk_user_id) VALUES (1, 'echt easy', '2020-11-02 22:19:25.000000', 1, 3);
INSERT INTO public.comment (id, message, created, fk_exercise_id, fk_user_id) VALUES (2, 'zu schwer, ich kenn mich nicht aus', '2020-11-02 22:19:37.000000', 1, 2);

INSERT INTO public.difficulty (id, number, fk_exercise_id, fk_user_id) VALUES (1, 1, 1, 3);
INSERT INTO public.difficulty (id, number, fk_exercise_id, fk_user_id) VALUES (2, 10, 1, 2);

INSERT INTO public.exercise_header (id, full_title, short_title, introduction) VALUES (1, 'Test Exercise 1 Full Title', 'Test1ShortTitle', 'This is the introduction to the test exercise 1. This is the introduction to the test exercise 1. This is the introduction to the test exercise 1.
This is the introduction to the test exercise 1.This is the introduction to the test exercise 1.This is the introduction to the test exercise 1.
This is the introduction to the test exercise 1.This is the introduction to the test exercise 1.This is the introduction to the test exercise 1.');
INSERT INTO public.exercise_header (id, full_title, short_title, introduction) VALUES (2, 'Testbeispiel 1 Voller Titel', 'Test1KurzerTitel', 'Dies ist eine Angabe zum Testbeispiel 1. Dies ist eine Angabe zum Testbeispiel 1. Dies ist eine Angabe zum Testbeispiel 1. 
Dies ist eine Angabe zum Testbeispiel 1. Dies ist eine Angabe zum Testbeispiel 1. ');

INSERT INTO public.tag (id, name) VALUES (1, 'tag1');
INSERT INTO public.tag (id, name) VALUES (2, 'tag2');
INSERT INTO public.tag (id, name) VALUES (3, 'tag3');

INSERT INTO public.exercise_tag (id, fk_tag_id, fk_exercise_id) VALUES (1, 1, 1);
INSERT INTO public.exercise_tag (id, fk_tag_id, fk_exercise_id) VALUES (2, 2, 1);
INSERT INTO public.exercise_tag (id, fk_tag_id, fk_exercise_id) VALUES (3, 3, 1);

INSERT INTO public.written_language (id, name) VALUES (2, 'english');
INSERT INTO public.written_language (id, name) VALUES (1, 'german');

INSERT INTO public.programming_language (id, name) VALUES (1, 'c');
INSERT INTO public.programming_language (id, name) VALUES (2, 'cpp');
INSERT INTO public.programming_language (id, name) VALUES (3, 'java');
INSERT INTO public.programming_language (id, name) VALUES (4, 'csharp');

INSERT INTO public.test_suite (id, question_type, prefill, solution, complexity) VALUES (1, 'question type test exercise 1 cpp', 'prefill cpp', 'solution cpp', 3);
INSERT INTO public.test_suite (id, question_type, prefill, solution, complexity) VALUES (2, 'question type test exercise 1 java', 'prefill java', 'solution java', 2);

INSERT INTO public.test_case (id, order_used, description, standard_input, expected_output, additional_data, points, fk_test_suite_id) VALUES (1, 1, 'test case for cpp', 'standard input for cpp', 'expected output cpp', 'additional_data cpp', 3, 1);
INSERT INTO public.test_case (id, order_used, description, standard_input, expected_output, additional_data, points, fk_test_suite_id) VALUES (2, 1, 'test case for java', 'standard input for java', 'expected output java', 'additional_data java', 3, 2);

INSERT INTO public.exercise_language (id, fk_written_language_id, fk_exercise_version_id, fk_exercise_header_id) VALUES (1, 2, 1, 1);
INSERT INTO public.exercise_language (id, fk_written_language_id, fk_exercise_version_id, fk_exercise_header_id) VALUES (2, 1, 1, 2);

INSERT INTO public.exercise_body (id, fk_programming_language_id, description, example, hint, fk_exercise_language_id, fk_test_suite_id) VALUES (1, 2, 'Test Exercise 1 Body in cpp English', 'cpp example for test exercise 1', 'hint for test exercise 1 cpp', 2, 1);
INSERT INTO public.exercise_body (id, fk_programming_language_id, description, example, hint, fk_exercise_language_id, fk_test_suite_id) VALUES (2, 2, 'Testbeispiel 1 Körper in cpp Deutsch', 'cpp Beispiel für Testbeispiel', 'Hinweis für Testbeispiel 1 cpp', 1, 1);
INSERT INTO public.exercise_body (id, fk_programming_language_id, description, example, hint, fk_exercise_language_id, fk_test_suite_id) VALUES (3, 3, 'Test Exercise 1 Body in java English', 'java example for test exercise 1', 'hint for test exercise 1 java', 2, 2);

