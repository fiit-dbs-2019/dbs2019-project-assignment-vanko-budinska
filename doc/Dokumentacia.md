# Zadanie
Vo vami zvolenom prostred� vytvorte datab�zov� aplik�ciu, ktor� komplexne rie�i p� vami zadefinovan�ch scen�rov (pr�padov pou�itia) vo vami zvolenej dom�ne tak, aby ste demon�trovali vyu�itie rela�nej datab�zy pod�a pokynov uveden�ch ni��ie. Presn� rozsah a konkretiz�ciu scen�rov si dohodnete s Va�im cvi�iacim na cvi�en�. Projekt sa rie�i vo dvojiciach, pri�om sa o�ak�va, �e na synchroniz�ciu pr�ce so spolu�iakom / spolu�ia�kou pou�ijete git. 
# Aplik�cia - Bookme
Je aplik�cia na preh�adn�, jednoduch� a pohodln� rezervovanie a zak�penie ubytovania pre �ud� �o cestuj�, �i u� za pr�cou, dobrodr��stvom alebo
dovolenkou a relaxom. Registrovan� pou��vate� si m��e prezera� ponuky ubytovania v hoteloch, penzi�noch a apartm�noch z cel�ho sveta na jednom mieste.
Ponuky si vie odfiltrova� pod�a svojich potrieb a preferencii. Samozrejmos�ou je v�ber typu ubytovania, cenovej hranice, po�tu noc�, polohy ubytovania
a vzdialenosti od centra, ale vie si vybra� aj pod�a po�tu hviezdi�iek, pon�kan�ch slu�ieb (re�taur�cia, jedlo v cene ubytovania, wellness, telocvi��a,
free Wi-Fi, recepcia 24/7) ale aj pod�a odpor��an� z�kazn�kov, ktor� tam u� ubytovan� boli. Ke� si pou��vate� vyberie ubytovanie ktor� mu vyhovuje,
tak si ho m��e cez aplik�ciu, po zadan� platobnej karty a svojich �dajov ktor� si vie aj ulo�i� do bud�cna, rezervova� alebo rovno zak�pi�.
V oboch pr�padoch bude informovan� poskytovate� ubytovania a pou��vate�ovi sa v aplik�cii prid� do zoznamu jeho ubytovan�, kde si m��e sledova� aktu�lny
stav svojich rezerv�cii alebo platieb. V tomto zozname ubytovan� n�jde pou��vate�, ke� si otvor� po�adovan� polo�ku, v�etko �o potrebuje. M��e v �om zru�i�  
rezerv�ciu (pokia� nezme�kal mo�n� term�n na zru�enie rezerv�cie), komunikova� s poskytovate�om ubytovania alebo sa preuk�za� rezerva�n�m ��slom pre
jednoduch� a r�chle ubytovanie.
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
### Scen�r 2 - detail hotela
Wireframe pre scen�r �. 2 - wireframe-2.png
#### Opis scen�ra 2
Implement�cia filtra pod�a d�tumu, destin�cie, po�tu os�b pr�p. �a���ch filtrov umiestnen�ch v �avej �asti hlavnej obrazovky. Mo�nosti tohto filtra : TV, Wifi, parkovanie, non-stop recepcia, ra�ajky v cene, all-inclusive.
Po kliknut� na tla�idlo vybra� sa zobrazia bli��ie inform�cie o vybranej izbe/hoteli.
Pou��vate� bude vidie� podrobn� opis, inform�cie o poskytovan�ch slu�b�ch, rozlohe izby, adresu hotela.
Stla�en�m tla�idla sp� sa dostane nazad medzi prezeran� hotely v predch�dzaj�com kroku.
#### Scen�r 3 - rezerv�cia
### Opis scen�ra �.3
V detaile hotela po kliknut� na tla�idlo Rezervova� sa zobraz� okno s detailami o rezervaci� (d�tum, po�et os�b, celkov� cena). Po potvrden� rezerv�cie sa dan� izba pre zvolen� d�tum vyrad� z ponuky.
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

