--
-- PostgreSQL database dump
--

-- Dumped from database version 12.5 (Ubuntu 12.5-0ubuntu0.20.04.1)
-- Dumped by pg_dump version 13.0

-- Started on 2020-12-21 18:29:48

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2958 (class 0 OID 57354)
-- Dependencies: 204
-- Data for Name: game; Type: TABLE DATA; Schema: public; Owner: hlib
--

COPY public.game (id, team1_id, team2_id) FROM stdin;
1	1	2
2	2	3
3	3	4
4	4	5
5	5	1
\.


--
-- TOC entry 2960 (class 0 OID 57384)
-- Dependencies: 206
-- Data for Name: game_date; Type: TABLE DATA; Schema: public; Owner: hlib
--

COPY public.game_date (id, game_id, date_id) FROM stdin;
1	1	1
2	1	2
3	2	2
4	2	3
5	3	1
6	4	3
7	5	3
\.


--
-- TOC entry 2959 (class 0 OID 57379)
-- Dependencies: 205
-- Data for Name: schedule; Type: TABLE DATA; Schema: public; Owner: hlib
--

COPY public.schedule (id, date, working_day) FROM stdin;
1	2020-12-12	f
2	2020-12-14	t
3	2020-12-16	t
\.


--
-- TOC entry 2957 (class 0 OID 40998)
-- Dependencies: 203
-- Data for Name: score; Type: TABLE DATA; Schema: public; Owner: hlib
--

COPY public.score (id, game_id, score1, score2) FROM stdin;
1	1	0	1
2	2	2	1
3	3	0	0
4	4	1	1
5	5	3	0
\.


--
-- TOC entry 2956 (class 0 OID 40962)
-- Dependencies: 202
-- Data for Name: team; Type: TABLE DATA; Schema: public; Owner: hlib
--

COPY public.team (id, name) FROM stdin;
1	Lokomotiv Club FC
2	Sparta Rotterdam
3	Schalke 04
4	Slavia Praha
5	Cadiz FC
\.


-- Completed on 2020-12-21 18:29:48

--
-- PostgreSQL database dump complete
--

