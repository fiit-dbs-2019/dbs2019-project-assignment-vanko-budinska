CREATE TABLE public.stat
(
	id SERIAL NOT NULL PRIMARY KEY,
	nazov text NOT NULL DEFAULT 'name',
	code text NOT NULL DEFAULT 'code'
);

CREATE TABLE public.typ_ubytovania
(
	id SERIAL NOT NULL PRIMARY KEY,
	nazov text
);

CREATE TABLE public.typ_izby
(
	id SERIAL NOT NULL PRIMARY KEY,
	nazov text
);

CREATE TABLE public.pouzivatel
(
	id SERIAL NOT NULL PRIMARY KEY,
	meno text NOT NULL DEFAULT 'name',
	priezvisko text NOT NULL DEFAULT 'priezvisko',
	email text NOT NULL DEFAULT 'email',
	heslo text NOT NULL DEFAULT 'heslo'
);

CREATE TABLE public.rezervacia
(
	id SERIAL NOT NULL PRIMARY KEY,
	od_dat DATE,
	do_dat DATE
);

CREATE TABLE public.destinacia
(
	id SERIAL NOT NULL PRIMARY KEY,
	nazov text,
	id_stat integer,
	FOREIGN KEY (id_stat) REFERENCES public.stat(id)
);

CREATE TABLE public.ubytovanie
(
	id SERIAL NOT NULL PRIMARY KEY,
	nazov text,
	pocet_hviezdiciek integer,
	hodnotenie float,
	adresa text,
	popis text,
	obr_urls text[],
	wifi boolean,
	tv boolean,
	parkovisko boolean,
	ranajky boolean,
	bazen boolean,
	id_destinacia integer,	
	FOREIGN KEY (id_destinacia) REFERENCES public.destinacia(id),
	id_typ_ubytovania integer,
	FOREIGN KEY (id_typ_ubytovania) REFERENCES public.typ_ubytovania(id)
);

CREATE TABLE public.cena
(
	id SERIAL NOT NULL PRIMARY KEY,
	od_dat DATE,
	do_dat DATE,
	cena float NOT NULL DEFAULT 100,
	id_ubytovanie integer,
	FOREIGN KEY (id_ubytovanie) REFERENCES public.ubytovanie(id)
);

CREATE TABLE public.izba
(
	id SERIAL NOT NULL PRIMARY KEY,
	rozloha int,
	typ_lozka text,
	kapacita int,
	id_typ_izby integer,
	FOREIGN KEY (id_typ_izby) REFERENCES public.typ_izby(id),
	id_ubytovanie integer,
	FOREIGN KEY (id_ubytovanie) REFERENCES public.ubytovanie(id)
);


CREATE TABLE public.zostava_rezervacie
(
	id SERIAL NOT NULL PRIMARY KEY,
	pocet int,
	id_rezervacia integer,
	FOREIGN KEY (id_rezervacia) REFERENCES public.rezervacia(id),
	id_ubytovanie integer,
	FOREIGN KEY (id_ubytovanie) REFERENCES public.ubytovanie(id),
	id_pouzivatel integer,
	FOREIGN KEY (id_pouzivatel) REFERENCES public.pouzivatel(id)
);