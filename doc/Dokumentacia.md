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
![model](diagram_final.png "Aktualny datovy model")
### Opis modelu:
#### Ubytovanie
Za ubytovanie pova�ujeme miesto, na ktorom je mo�n� prespa� a v re�lnom svete ho mo�no pova�ova� �i u� za samostatn� izbu v s�krom�, alebo "izbu" (s k�pe��ou alebo viacer�mi miestnos�ami) v hoteli, �i apartm�n.
Pozost�va z n�zvu ubytovania, po�tu hviezdi�iek dan�ho ubytovania, hodnotenia, adresy, popisu, po�a url vykreslovan�ch obr�zkov, po�tu izieb a mo�nost� pre filtrovanie.
Ka�d� ubytovanie sa nach�dza v destn�ci�, prisl�cha mu typ ubytovania - �i sa jedn� o hotel, apartm�n, izbu v s�krom�, chatu at�.
Ka�d� ubytovanie mus� ma� aspo� jednu izbu, v tomto pr�pade sa jedn� o miestnos� v ktorej sa nach�dza l��ko.
Ka�d�mu ubytovaniu prisl�cha v �ase pr�ve jedna cena.
#### Zostava rezerv�cie
Jedn� sa o v�zobn� entitu. Cez t�to entitu prira�ujeme k pr�ve jednej rezerv�ci� 1...n ubytovan� pre pr�ve jedn�ho pou��vate�a.

## Scen�re

### Scen�r 1 - hlavn� obrazovka
![Hlavna_Obrazovka](wireframe-1.png "Hlavna obrazovka")
#### Opis scen�ra 1
Po spusten� aplik�cie sa otvor� hlavn� okno s ponukami ubytovan� ktor� sa nach�dzaj� v datab�ze.\
Inform�cie ktor� sa z�skavaj� z datab�zy:
* N�zov ubytovania
* Po�et hviezdi�iek ktor� m� dan� hotel
* Obr�zok ubytovania (cez URL)
* N�zov destin�cie, adresa 
* Popis
* Hodnotenie, Cena

#### Podscen�r 1.1 - Str�nkovanie
Tla�idlami < a > v spodnej �asti hlavn�ho okna je mo�n� pos�va� sa po str�nkach - predvolene 10 pon�k.
#### Podscen�r 1.2 - Z�kladn� vyh�ad�vanie
Pri z�kladnom vyh�ad�van� sa o�ak�va zadanie destin�cie, d�tumov za�iatku a konca rezerv�cie, po�tu os�b a po�tu izieb.
Po stla�en� tla�idla h�ada� syst�m napln� ponuku s vyhovuj�cimi ubytovaniami.
#### Podscen�r 1.3 - Filter
Po stla�en� tla�idla filtruj sa filter aplikuje na pr�ve vyp�san� ponuky, teda pri z�kladnom scen�ri na predvolen� ponuku, po podscen�ri 1.2 na vyh�adan� ponuky.

### Scen�r 2 - detail ubytovania
![Detail_ubytovania](wireframe-2.png "Detail ubytovania")
#### Opis scen�ra 2
N�h�ad na detail ubytovania v ktorom sa vyp�e viacero detailov ktor� neboli vidite�n� v scen�ri 1.
Stla�en�m tla�idla sp� sa dostane nazad medzi prezeran� hotely v predch�dzaj�com kroku.

### Scen�r 3 - rezerv�cia
![Rezervacia](wireframe-3.png "Rezervacia")
#### Opis scen�ra �.3
Po kliknut� na tla�idlo rezervova� sa zobraz� (zatia�) dial�gov� okno s inform�ciou "Rezerv�cia Od DD.MM.YYYY do DD.MM.YYYY bola vytvorena".\
T�to rezerv�cia sa prid� do pr�slu�n�ch tabuliek - Rezervacia, Zostava rezerv�cie.\
Pre vytvorenie rezerv�cie mus� by� pou��vate� prihl�sen�, inak mu syst�m nedovol� vytvori� rezerv�ciu.\

#### Podscen�r 3.1 Registr�cia
Pre rezerv�ciu je potrebn� by� zaregistrovan� a prihl�sen�. Po kliknut� na tla�idlo Registruj sa, sa otvor� okno pre vyplnenie �dajov potrebn�ch pre registr�ciu.
Syst�m vytiahne z db meno pou��vate�a a v hlavnom okne je "Vitaj meno_pou��vate�a".

#### Podscen�r 3.2 Prihl�senie
Po spr�vnom vyplnen� emailu a hesla pre prihl�senie a stla�en� tla�idla prihl�si� sa, syst�m vytiahne z db meno pou��vate�a a v hlavnom okne je "Vitaj meno_pou��vate�a".
Ak nie je spr�vny email (nebol zaregistrovan� �i je zle vyplnen�) alebo heslo je nespr�vne, ale email spr�vny, tak syst�m vyp�e chybov� hl�ku.
Tieto �daje sa nach�dzaj� v tabu�ke Pou��vate�.

### Scen�r 4 - Preh�ad rezerv�ci�
![Prehlad_rezervacii](wireframe-4.jpeg "Prehlad_rezervacii")
Po kliknut� na tla�idlo Moje Rezervacie sa otvor� preh�ad s inform�ciami o rezerv�ciach pre pr�ve prihl�sen�ho pou��vate�a.\
Inorm�cie zobrazovan� v preh�ade rezerv�ci�:
* ��slo rezerv�cie
* Po�et izieb za dan� rezerv�ciu
* D�tum od kedy je rezerv�cia platn�
* D�tum do kedy je rezerv�cia platn�
* N�zov ubytovania
* Adresa ubytovania
* Stav rezerv�cie
Tla�idlo s mo�nos�ou �pravy alebo zmazania rezerv�cie.

Tla�idlom sp� sa pou��vate� vr�ti na preh�ad ubytovan�

#### Podscen�r 4.1 Zmena rezerv�cie
![zmena_rezervacie](wireframe-5.jpeg "zmena_rezervacie")
Otvor� sa okno s detailami rezerv�cie, mo�nos�ou zmeny d�tumu a "�hrady" rezerv�cie.
Zmena z�znamu sa vykon�va cez transakcie.

#### Podscen�r 4.2 Zru�enie rezerv�cie
V preh�ade rezerv�ci� po kliknut� na tla�idlo Zrusit sa rezerv�cia zru�� - zma�e sa z tabu�ky a
aj v preh�ade.

## Opis n�vrhu a implement�cie
### Programov� prostredie
Aplik�cia je desktopov� ur�en� pre OS Windows, implementovan� v programovacom jazyku C#, v prostred� Visual Studio. Vyu��va postgres DB.
### N�vrhov� rozhodnutia
K DB sa pristupuje pomocou Npgsql, pripojenie k DB prebieha cez NpgsqlConnection v�dy ke� je po�iadavka na v�ber z DB. Do NpgsqlConnection vstupuje adresa servera, port, userID, heslo a n�zov DB.
Na po�iadavky na v�ber z DB je implementovan� vlastn� trieda PostGreSQL, kde do jej kon�truktora vstupuj� �daje na pripojenie do DB. T�to trieda ma vlastn� met�du Query do ktorej vstupuje string pre po�iadavku, vracia List<string> kde string m� form�t "stlpec1,stlpec2,stlpec3...stlpecN". 


### Opis implement�cie 
Z grafick�ho h�adiska pou�it� prvky poskytovn� cez Toolbox.

#### Scen�r 1 - hlavn� obrazovka
Hlavn� okno - vyu��va User Control HotelPolozka. Jednotliv� polo�ky s� dynamicky generovan� pri spusten� aplik�cie v met�de napln_ponuku. Po�et z�znamov na str�nku je 10.

#### Podscen�r 1.2 - Z�kladn� vyh�ad�vanie
V Bookme.cs btnHladat_Click - V�ber z tabuliek destinacia, stat - kde sa adresa, nazov statu alebo nazov destinacie zhoduje so zadan�m textom a naplnenie ponuky pod�a odpovede z DB.

#### Podscen�r 1.3 - Filter
V Bookme.cs btnFiltruj_Click - v�ber z tabu�ky ubytovan� pod�a checkboxov.

#### Scen�r 2 - detail ubytovania
UserControl HotelDetail(HotelPolozka hotelPolozka). D�ta s� �erpan� z polo�ky hotela, ubytovania.\
V Bookme.cs tla�idlo rezervuj - pripojenie do DB, insert do tabu�ky rezerv�ci� a zostavy rezerv�ci�.
Metoda NaplnPolozky() - naplnenie obrazovky detailu hotela,
Metoda VykresliObr() - vykreslenie n�hladu fotiek hotela, max to�ko, ko�ko je v ubytovanie obr_urls[]
Metoda Obrazky_Click() - zobrazenie vybran�ho obr�zku z n�h�adu

#### Scen�r 3 - rezerv�cia
V triede HotelDetail btnRezervuj_Click\
Insert do tabuliek rezervacia a zostava rezervacie

#### Podscen�r 3.1 - Registr�cia
V Bookme.cs btnRegistracia_Click - V novom threade sa vytvor� okno s UserControl Registracia.cs kde pou��vate� vypln� �daje.
Ak s� v�etky �daje vyplnen�, tak v Registracia.btnRegistruj_Click sa spravi insert do tabu�ky pou��vate�ov.
Ak nie, vyp�e sa chybov� hl�ka. Email na platnos� nekontrolujem, heslo je ulo�en� ako plain text, nehashujem ho.

#### Podscen�r 3.2 Prihl�senie
V Bookme.cs btnPrihlas_Click - overenie hesla k prisl�chaj�cemu emailu v tabu�ke pou��vate�ov.
Po prihl�sen� zmena pre prihl�senie na UserControl PrihlasenyHlavicka.

#### Scen�r 4 - Preh�ad rezerv�ci�
UserControl MojeRezervacie - naplnenie pod�a selektu z DB.

### Generovanie d�t
D�ta do tabuliek sa generuj� cez skript v adres�ri data./ 
D�ta je treba generova� postupne, pod�a prepojenia tabuliek.
SQL skripty na vytvorenie ��seln�kov typ_ubytovania, typ_izby, stav_rezervacie, s� v adres�ri data./
Skript pre vytvorenie tabuliek v schema/ create_tables.sql
#### S�ahovanie URL pre obr�zky
Spustenie s: -u conn_info.txt V conn_info su inform�cie pre pripojenie k DB.
S�ahovanie prebieha tak, �e sa odo�le web request, ak nieje error, url sa ulo�� do s�boru. N�sledne �ak�m 3ms (aby ma n�hodou nevypli). 
Defaultne sa �ah� z url s prefixom https://r-ak.bstatic.com/images/hotel/max500/150/150 za ktor�m nasleduje 6-��slie od 0 po 999999.
URL sa ukladaj� do urls.txt, ktor� sa spracov�va pri generovan� ubytovan�.
#### Vkladanie �t�tov
Spustenie s: -s staty.json conn_info.txt
Do tabu�ky �t�tov povkladn� n�zvy a k�dy �t�tov v subore staty.json.
#### Vkladanie Destin�ci�
Spustenie s: -d destinations.json 
Do tabu�ky destn�ci� povklad� destin�cie na z�klade k�du �t�tu v s�bore destinations.json a prid� FK.

#### Generovanie ubytovan�
Spustenie s: -a adresses.json N, kde N je po�et generovan�ch z�znamov.\
Vyu��va names.csv, urls.txt\
Skladanie n�zvu: random z typu ubytovania + meno z meno.csv\
Ukldanie adries obr�zkov z urls.txt\
Ukladanie adreis ubytovan� z adresses.json, popis ubytovanie: natvrdo dan� jeden odstavec lorem ipsum\
random: ostatn� paramentre

#### Generovanie izieb
Spustenie s: -r conn_info.txt\
Pod�a druhu ubytovania sa vygeneruje po�et izieb pre dan� ubytovanie, n�hodne sa vyberie typ l��ka a pod�a toho sa ur�� kapacita, ve�kos� izby - random.
## TODO
- [X] Scen�r 3 - Detail a potvrdenie rezerv�cie
- [X] Scen�r 2 - Izby pre dan� ubytovanie
- [X] Scen�r 2 - Detail hotela - �al�ie inform�cie
- [X] Model - Tabu�ka so mo�n�mi stavmi rezerv�ci�
- [X] Scen�r 4 - Jednotliv� vytvoren� rezerv�cie v samostatnom UserControl
- [X] Scen�r 5 - zmena, zmazanie rezerv�cie 
- [X] pou�itie transakci� + FK
- [ ] Naplni� DB zmyslupln�mi cenami
- [X] Str�nkovanie
- [X] Optimalizacia pouzitej pamati pri vytvarani a ruseni stranok
- [ ] Usporiadanie pod�a krit�ri�
- [X] V�etky Queries cez cmd.Parameters
- [X] Kompletn� podscen�r 1.2 (datum, izby, osoby)
- [X] Dorobenie lep�ieho vyskladn�vanie Query
- [ ] Automatick� prihl�senie po registr�ci�
- [ ] V dokument�ci� predpisy tvaru s�borov pre generovanie
- [X] dogenerovanie d�t
- [X] GROUP BY
## Min. poziadavky
- [X] Min. 7 tabuliek okrem ��sel�nkov
- [ ] R�dovo mil�ny v ka�dej tab. okrem ��seln�kov
- [ ] V jednej 10 mil
- [X] Join-y
- [X] Pou�itie agrega�nej funkcie
- [X] Zobrazenie preh�adu v�etk�ch z�znamov so str�nkovan�m + GRUOP BY
- [X] Filtrovanie pod�a zadan�ch kriteri�
- [X] Detail z�znamu
- [X] Vytvorenie z�znamu (Nov� pou��vate�, rezerv�cia)
- [X] Aktualiz�cia existuj�ceho z�znamu
- [X] Vymazanie z�znamu
- [X] Scen�re ktor� menia d�ta musia by� realizovan� s pou�it�m transkaci� + aspo� jeden s viacer�mi tabu�kami (FK) e
