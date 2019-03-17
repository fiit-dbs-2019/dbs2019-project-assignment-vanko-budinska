CREATE TABLE public.destinacie
(
    id integer NOT NULL DEFAULT nextval('destinacie_id_seq'::regclass),
    nazov character varying(50) COLLATE pg_catalog."default",
    stat_id integer,
    CONSTRAINT destinacie_pkey PRIMARY KEY (id),
    CONSTRAINT destinacie_stat_id_fkey FOREIGN KEY (stat_id)
        REFERENCES public.staty (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.destinacie
    OWNER to martin;