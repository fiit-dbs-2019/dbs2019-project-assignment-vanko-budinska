CREATE TABLE public.izby
(
    	id integer NOT NULL DEFAULT nextval('izby_id_seq'::regclass),
    	CONSTRAINT izby_pkey PRIMARY KEY (id),
	nazov character varying(30) COLLATE pg_catalog."default",
	pocet_lozok integer NOT NULL,
	pocet_hviezdiciek integer,
    	rozloha integer NOT NULL,
    	wifi boolean NOT NULL,
    	tv boolean NOT NULL,
    	parkovisko boolean NOT NULL,
    	destinacia_id integer,
    	obr_url character varying(250) COLLATE pg_catalog."default" NOT NULL,
    	CONSTRAINT izby_destinacia_id_fkey FOREIGN KEY (destinacia_id)
        REFERENCES public.destinacie (id) MATCH SIMPLE
        	ON UPDATE NO ACTION
        	ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.izby
    OWNER to martin;