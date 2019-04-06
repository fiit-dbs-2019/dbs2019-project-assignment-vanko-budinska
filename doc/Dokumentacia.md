# Zadanie
Vo vami zvolenom prostred� vytvorte datab�zov� aplik�ciu, ktor� komplexne rie�i p� vami zadefinovan�ch scen�rov (pr�padov pou�itia) vo vami zvolenej dom�ne tak, aby ste demon�trovali vyu�itie rela�nej datab�zy pod�a pokynov uveden�ch ni��ie. Presn� rozsah a konkretiz�ciu scen�rov si dohodnete s Va�im cvi�iacim na cvi�en�. Projekt sa rie�i vo dvojiciach, pri�om sa o�ak�va, �e na synchroniz�ciu pr�ce so spolu�iakom / spolu�ia�kou pou�ijete git. 
# Aplik�cia - Bookme
Je aplik�cia na preh�adn�, jednoduch� a pohodln� rezervovanie a zak�penie ubytovania pre �ud� �o cestuj�, �i u� za pr�cou, dobrodr��stvom alebo
dovolenkou a relaxom. Pou��vate� si m��e prezera� ponuky ubytovania v hoteloch, penzi�noch a apartm�noch z cel�ho sveta na jednom mieste.
Ponuky si vie odfiltrova� pod�a svojich potrieb a preferencii. Samozrejmos�ou je v�ber typu ubytovania, cenovej hranice, po�tu noc�, polohy ubytovania
a vzdialenosti od centra, ale vie si vybra� aj pod�a po�tu hviezdi�iek, pon�kan�ch slu�ieb (re�taur�cia, jedlo v cene ubytovania, wellness, telocvi��a,
free Wi-Fi, recepcia 24/7) ale aj pod�a odpor��an� z�kazn�kov, ktor� tam u� ubytovan� boli. Ke� si pou��vate� vyberie ubytovanie ktor� mu vyhovuje,
tak si ho m��e cez aplik�ciu, po zadan� platobnej karty a svojich �dajov ktor� si vie aj ulo�i� do bud�cna, po registr�ci� alebo prihl�sen� rezervova� alebo rovno zak�pi�.
V oboch pr�padoch bude informovan� poskytovate� ubytovania a pou��vate�ovi sa v aplik�cii prid� do zoznamu jeho ubytovan�, kde si m��e sledova� aktu�lny
stav svojich rezerv�cii alebo platieb. V tomto zozname ubytovan� n�jde pou��vate�, ke� si otvor� po�adovan� polo�ku, v�etko �o potrebuje. M��e v �om zru�i�  
rezerv�ciu (pokia� nezme�kal mo�n� term�n na zru�enie rezerv�cie), komunikova� s poskytovate�om ubytovania alebo sa preuk�za� rezerva�n�m ��slom pre
jednoduch� a r�chle ubytovanie.
## D�tov� model 
![model](diagram-3.png "Aktualny datovy model")
### Opis modelu:
#### Ubytovanie
Ubytovanie by sme mohli ozna�i� ako hlavn� entitu. Za ubytovanie pova�ujeme miesto, na ktorom je mo�n� prespa� a v re�lnom svete ho mo�no pova�ova� �i u� za samostatn� izbu v s�krom�, alebo "izbu" (s k�pe��ou alebo viacer�mi miestnos�ami) v hoteli �i apartm�n.
Pozost�va z n�zvu ubytovania, po�tu hviezdi�iek dan�ho ubytovania, hodnotenia, adresy, popisu, po�a url vykreslovan�ch obr�zkov, po�tu izieb a mo�nost� pre filtrovanie.
Ka�d� ubytovanie sa nach�dza v destn�ci�, prisl�cha mu typ ubytovania - �i sa jedn� o hotel, apartm�n, izbu v s�krom�, chatu at�.
Ka�d� ubytovanie mus� ma� aspo� jednu izbu, v tomto pr�pade sa jedn� o miestnos� v ktorej sa nach�dza l��ko.
Ka�d�mu ubytovaniu prisl�cha v �ase pr�ve jedna cena.
#### Zostava rezerv�cie
Jedn� sa o v�zobn� entitu. Cez t�to entitu prira�ujeme k pr�ve jednej rezerv�ci� 1...n ubytovan� pre pr�ve jedn�ho pou��vate�a.
## Scen�re

### Scen�r 1 - hlavn� obrazovka
Wireframe pre scen�r �. 1 - wireframe-1.png
#### Opis scen�ra 1
Po spusten� aplik�cie sa otvor� hlavn� okno s ponukami ubytovan� ktor� sa nach�dzaj� v datab�ze. 
Inform�cie ktor� sa z�skavaj� z datab�zy:
N�zov hotela
Po�et hviezdi�iek ktor� m� dan� hotel
Obr�zok hotela (cez URL)
Filter, d�tumy od a do, n�zov destin�cie/hotela a po�et �ud� / l��ok zatia� nie s� funk�n�. Implementovan� bud� v druhom scen�ri.
#### Podscen�r 1.1 - Str�nkovanie
Tla�idlami < a > v spodnej �asti hlavn�ho okna je mo�n� pos�va� sa po str�nkach - predvolene 10 pon�k.

### Scen�r 2 - detail hotela
Wireframe pre scen�r �. 2 - wireframe-2.png
#### Opis scen�ra 2
N�h�ad na detail hotela v ktorom sa vyp�e viacero detailov ktor� neboli vidite�n� v scen�ri 1.
Stla�en�m tla�idla sp� sa dostane nazad medzi prezeran� hotely v predch�dzaj�com kroku.
#### Podscen�r 2.1 - Z�kladn� vyh�ad�vanie
Pri z�kladnom vyh�ad�van� sa o�ak�va zadanie destin�cie, d�tumov za�iatku a konca rezerv�cie, po�tu os�b a po�tu izieb.
Po stla�en� tla�idla h�ada� syst�m napln� ponuku s vyhovuj�cimi ubytovaniami.
#### Podscen�r 2.2 - Filter
Po stla�en� tla�idla filtruj sa filter aplikuje na pr�ve vyp�san� ponuky, teda pri z�kladnom scen�ri na predvolen� ponuku, po podscen�ri 2.1 na vyh�adan� ponuky.
#### Podscen�r 2.3 - Usporiadanie
Po vybrat� z ponuky pre usporiadanie (Zoradit pod�a) sa usporiadaj� pr�ve zobrazovan� ponuky.

### Scen�r 3 - rezerv�cia
#### Opis scen�ra �.3
V detaile hotela po kliknut� na tla�idlo Rezervova� sa zobraz� okno s detailami o rezervaci� (d�tum, po�et os�b, celkov� cena). Po potvrden� rezerv�cie sa dan� izba pre zvolen� d�tum vyrad� z ponuky a prid� medzi rezerv�cie pou��vate�a.
#### Podscen�r 3.1 Registr�cia
Pre rezerv�ciu je potrebn� by� zaregistrovan� a prihl�sen�. Po kliknut� na tla�idlo Registruj sa, sa otvor� okno pre vyplnenie �dajov potrebn�ch pre registr�ciu.
Po dokon�en� rezerv�cie syst�m automaticky prihl�si pou��vate�a. Syst�m vytiahne z db meno pou��vate�a a v hlavnom okne je "Vitaj meno_pou��vate�a".
#### Podscen�r 3.2 Prihl�senie
Po spr�vnom vyplnen� emailu a hesla pre prihl�senie a stla�en� tla�idla prihl�si� sa, syst�m vytiahne z db meno pou��vate�a a v hlavnom okne je "Vitaj meno_pou��vate�a".
Ak nie je spr�vny email (nebol zaregistrovan� �i je zle vyplnen�) alebo heslo je nespr�vne, ale email spr�vny, tak syst�m vyp�e chybov� hl�ku.
Tieto �daje sa nach�dzaj� v tabu�ke Pou��vate�.
## Opis n�vrhu a implement�cie
### Programov� prostredie
Aplik�cia je desktopov� ur�en� pre OS Windows, implementovan� v programovacom jazyku C#, v prostred� Visual Studio. Vyu��va postgres DB.
### N�vrhov� rozhodnutia
K DB sa pristupuje pomocou Npgsql, pripojenie k DB prebieha cez NpgsqlConnection v�dy ke� je po�iadavka na v�ber z DB. Do NpgsqlConnection vstupuje adresa servera, port, userID, heslo a n�zov DB.
Na po�iadavky na v�ber z DB je implementovan� vlastn� trieda PostGreSQL, kde do jej kon�truktora vstupuj� �daje na pripojenie do DB. T�to trieda ma vlastn� met�du Query do ktorej vstupuje string pre po�iadavku, vracia List<string> kde string m� form�t "stlpec1,stlpec2,stlpec3...stlpecN". 
### Opis implement�cie 
Z grafick�ho h�adiska pou�it� prvky poskytovn� cez Toolbox.
#### Scen�r 1
Hlavn� okno - vyu��va User Control HotelPolozka. Jednotliv� polo�ky s� dynamicky generovan� pod�a po�tu v DB pri spusten� aplik�cie v met�de napln_ponuku do ktorej vstupuje List<string> s odpove�ou z DB. Zatia� v DB nie s� ve�k� generovan� po�ty z�znamov tak�e zatia� nerie�im po�et po�et prvkov ktor� sa s��asne zobrazia, teda prech�dzanie po str�nkach. Implementovan� je iba tabu�ka izby z d�tov�ho modelu v diag-2.png

