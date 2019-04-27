WITH tb AS ( 
SELECT u.id, u.obr_urls, ROW_NUMBER() OVER(ORDER BY u.id ASC) as n 
FROM public.ubytovanie AS u 
INNER JOIN public.destinacia d ON u.id_destinacia = d.id 
INNER JOIN public.stat s ON d.id_stat = s.id 
WHERE ((s.nazov LIKE '%Italy%' OR d.nazov LIKE '%Italy%' OR u.adresa LIKE '%Italy%')
	AND parkovisko = 'true' AND ranajky = 'true' AND bazen = 'true' AND wifi = 'true' AND tv = 'true' AND klimatizacia = 'true')
) SELECT * FROM tb WHERE n > 20
LIMIT 10;