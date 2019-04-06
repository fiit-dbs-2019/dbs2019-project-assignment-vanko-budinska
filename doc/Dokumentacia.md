# Zadanie
Vo vami zvolenom prostredí vytvorte databázovú aplikáciu, ktorá komplexne rieši pä vami zadefinovanıch scenárov (prípadov pouitia) vo vami zvolenej doméne tak, aby ste demonštrovali vyuitie relaènej databázy pod¾a pokynov uvedenıch nišie. Presnı rozsah a konkretizáciu scenárov si dohodnete s Vašim cvièiacim na cvièení. Projekt sa rieši vo dvojiciach, prièom sa oèakáva, e na synchronizáciu práce so spoluiakom / spoluiaèkou pouijete git. 
# Aplikácia - Bookme
Je aplikácia na preh¾adné, jednoduché a pohodlné rezervovanie a zakúpenie ubytovania pre ¾udí èo cestujú, èi u za prácou, dobrodrústvom alebo
dovolenkou a relaxom. Pouívate¾ si môe prezera ponuky ubytovania v hoteloch, penziónoch a apartmánoch z celého sveta na jednom mieste.
Ponuky si vie odfiltrova pod¾a svojich potrieb a preferencii. Samozrejmosou je vıber typu ubytovania, cenovej hranice, poètu nocí, polohy ubytovania
a vzdialenosti od centra, ale vie si vybra aj pod¾a poètu hviezdièiek, ponúkanıch sluieb (reštaurácia, jedlo v cene ubytovania, wellness, telocvièòa,
free Wi-Fi, recepcia 24/7) ale aj pod¾a odporúèaní zákazníkov, ktorı tam u ubytovanı boli. Keï si pouívate¾ vyberie ubytovanie ktoré mu vyhovuje,
tak si ho môe cez aplikáciu, po zadaní platobnej karty a svojich údajov ktoré si vie aj uloi do budúcna, po registrácií alebo prihlásení rezervova alebo rovno zakúpi.
V oboch prípadoch bude informovanı poskytovate¾ ubytovania a pouívate¾ovi sa v aplikácii pridá do zoznamu jeho ubytovaní, kde si môe sledova aktuálny
stav svojich rezervácii alebo platieb. V tomto zozname ubytovaní nájde pouívate¾, keï si otvorí poadovanú poloku, všetko èo potrebuje. Môe v òom zruši  
rezerváciu (pokia¾ nezmeškal monı termín na zrušenie rezervácie), komunikova s poskytovate¾om ubytovania alebo sa preukáza rezervaènım èíslom pre
jednoduché a rıchle ubytovanie.
## Dátovı model 
![model](diagram-3.png "Aktualny datovy model")
### Opis modelu:
#### Ubytovanie
Ubytovanie by sme mohli oznaèi ako hlavnú entitu. Za ubytovanie povaujeme miesto, na ktorom je moné prespa a v reálnom svete ho mono povaova èi u za samostatnú izbu v súkromí, alebo "izbu" (s kúpe¾òou alebo viacerími miestnosami) v hoteli èi apartmán.
Pozostáva z názvu ubytovania, poètu hviezdièiek daného ubytovania, hodnotenia, adresy, popisu, po¾a url vykreslovanıch obrázkov, poètu izieb a moností pre filtrovanie.
Kadé ubytovanie sa nachádza v destnácií, prislúcha mu typ ubytovania - èi sa jedná o hotel, apartmán, izbu v súkromí, chatu atï.
Kadé ubytovanie musí ma aspoò jednu izbu, v tomto prípade sa jedná o miestnos v ktorej sa nachádza lôko.
Kadému ubytovaniu prislúcha v èase práve jedna cena.
#### Zostava rezervácie
Jedná sa o väzobnú entitu. Cez túto entitu priraïujeme k práve jednej rezervácií 1...n ubytovaní pre práve jedného pouívate¾a.
## Scenáre

### Scenár 1 - hlavná obrazovka
Wireframe pre scenár è. 1 - wireframe-1.png
#### Opis scenára 1
Po spustení aplikácie sa otvorí hlavné okno s ponukami ubytovaní ktoré sa nachádzajú v databáze. 
Informácie ktoré sa získavajú z databázy:
Názov hotela
Poèet hviezdièiek ktoré má danı hotel
Obrázok hotela (cez URL)
Filter, dátumy od a do, názov destinácie/hotela a poèet ¾udí / lôok zatia¾ nie sú funkèné. Implementované budú v druhom scenári.
#### Podscenár 1.1 - Stránkovanie
Tlaèidlami < a > v spodnej èasti hlavného okna je moné posúva sa po stránkach - predvolene 10 ponúk.

### Scenár 2 - detail hotela
Wireframe pre scenár è. 2 - wireframe-2.png
#### Opis scenára 2
Náh¾ad na detail hotela v ktorom sa vypíše viacero detailov ktoré neboli vidite¾né v scenári 1.
Stlaèením tlaèidla spä sa dostane nazad medzi prezerané hotely v predchádzajúcom kroku.
#### Podscenár 2.1 - Základné vyh¾adávanie
Pri základnom vyh¾adávaní sa oèakáva zadanie destinácie, dátumov zaèiatku a konca rezervácie, poètu osôb a poètu izieb.
Po stlaèení tlaèidla h¾ada systém naplní ponuku s vyhovujúcimi ubytovaniami.
#### Podscenár 2.2 - Filter
Po stlaèení tlaèidla filtruj sa filter aplikuje na práve vypísané ponuky, teda pri základnom scenári na predvolenú ponuku, po podscenári 2.1 na vyh¾adané ponuky.
#### Podscenár 2.3 - Usporiadanie
Po vybratí z ponuky pre usporiadanie (Zoradit pod¾a) sa usporiadajú práve zobrazované ponuky.

### Scenár 3 - rezervácia
#### Opis scenára è.3
V detaile hotela po kliknutí na tlaèidlo Rezervova sa zobrazí okno s detailami o rezervacií (dátum, poèet osôb, celková cena). Po potvrdení rezervácie sa daná izba pre zvolenı dátum vyradí z ponuky a pridá medzi rezervácie pouívate¾a.
#### Podscenár 3.1 Registrácia
Pre rezerváciu je potrebné by zaregistrovanı a prihlásenı. Po kliknutí na tlaèidlo Registruj sa, sa otvorí okno pre vyplnenie údajov potrebnıch pre registráciu.
Po dokonèení rezervácie systém automaticky prihlási pouívate¾a. Systém vytiahne z db meno pouívate¾a a v hlavnom okne je "Vitaj meno_pouívate¾a".
#### Podscenár 3.2 Prihlásenie
Po správnom vyplnení emailu a hesla pre prihlásenie a stlaèení tlaèidla prihlási sa, systém vytiahne z db meno pouívate¾a a v hlavnom okne je "Vitaj meno_pouívate¾a".
Ak nie je správny email (nebol zaregistrovanı èi je zle vyplnenı) alebo heslo je nesprávne, ale email správny, tak systém vypíše chybovú hlášku.
Tieto údaje sa nachádzajú v tabu¾ke Pouívate¾.
## Opis návrhu a implementácie
### Programové prostredie
Aplikácia je desktopová urèená pre OS Windows, implementovaná v programovacom jazyku C#, v prostredí Visual Studio. Vyuíva postgres DB.
### Návrhové rozhodnutia
K DB sa pristupuje pomocou Npgsql, pripojenie k DB prebieha cez NpgsqlConnection vdy keï je poiadavka na vıber z DB. Do NpgsqlConnection vstupuje adresa servera, port, userID, heslo a názov DB.
Na poiadavky na vıber z DB je implementovaná vlastná trieda PostGreSQL, kde do jej konštruktora vstupujú údaje na pripojenie do DB. Táto trieda ma vlastnú metódu Query do ktorej vstupuje string pre poiadavku, vracia List<string> kde string má formát "stlpec1,stlpec2,stlpec3...stlpecN". 
### Opis implementácie 
Z grafického h¾adiska pouité prvky poskytovná cez Toolbox.
#### Scenár 1
Hlavné okno - vyuíva User Control HotelPolozka. Jednotlivé poloky sú dynamicky generované pod¾a poètu v DB pri spustení aplikácie v metóde napln_ponuku do ktorej vstupuje List<string> s odpoveïou z DB. Zatia¾ v DB nie sú ve¾ké generované poèty záznamov take zatia¾ neriešim poèet poèet prvkov ktoré sa súèasne zobrazia, teda prechádzanie po stránkach. Implementovaná je iba tabu¾ka izby z dátového modelu v diag-2.png

