SELECT z.id, z.pocet, r.od_dat, r.do_dat, u.nazov, u.adresa, d.nazov, s.nazov, st.stav FROM public.zostava_rezervacie z 
INNER JOIN public.rezervacia r ON z.id_rezervacia = r.id
INNER JOIN public.ubytovanie u ON z.id_ubytovanie = u.id
INNER JOIN public.destinacia d ON u.id_destinacia = d.id
INNER JOIN public.stat s ON d.id_stat = s.id
INNER JOIN public.stav_rezervacie st ON r.id_stav = st.id
WHERE z.id_pouzivatel = 2