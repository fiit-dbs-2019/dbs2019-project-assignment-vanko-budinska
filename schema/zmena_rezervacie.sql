BEGIN;
UPDATE public.rezervacia 
SET id_stav = sq.id
FROM (SELECT s.id
	  FROM public.stav_rezervacie s
	  WHERE s.stav = 'zaplatena') 
AS sqs
	WHERE public.rezervacia.id = 8;
END TRANSACTION;