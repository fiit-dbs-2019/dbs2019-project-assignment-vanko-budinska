WITH sq AS (
        UPDATE public.rezervacia
        SET do_dat = '2019-05-16', od_dat = '2019-05-10'
        WHERE id = 11 
        RETURNING id
        ) 
UPDATE public.zostava_rezervacie z
SET pocet = 2
FROM sq
WHERE sq.id = z.id_rezervacia