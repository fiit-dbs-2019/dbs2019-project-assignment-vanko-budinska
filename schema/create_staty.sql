CREATE TABLE public.staty
(
    id integer NOT NULL DEFAULT nextval('staty_id_seq'::regclass),
    stat character varying(50) COLLATE pg_catalog."default",
    CONSTRAINT staty_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.staty
    OWNER to martin;