# Tim24-Lavovi

# Tema: Rent a car


Članovi tima:

  1. Ehvan Građanin
  2. Almedin Mrnđić
  3. Senadin Terović


## Opis teme

Rent a car sistem omogucuje osobi da rezervise vozilo tako sto uplati odredenu svotu novca kompanija koja izdaje vozila i kontrolise transakciju putem interneta. Potencijal Rent a car sistema je najvise iskoristen u razvijenim zemljama kao sto su Engleska i Australija gdje 
elektronska trgovina prihvacane u potpunosti u zajednici. Osnovne funkcije Rent a car sistema ( u daljem tekstu RACS) su da vodi zapis o vozilima , osoblju, te naravno o klijentima i rezervaciji. RACS pruza korisne informacije osoblju kompanije kao sto su dnevni izvjestaji o vozilima koja ce biti dodjeljenja odredenom klijentu, u isto vrijeme RACS pruza informacije i izvrsava menadment vozila koristeci informacije o broju predenih kilometara, te cijeni samog vozila. Potencijalne prednosti koje bi kompanija mogla imati ako se odluci implementirati ovaj sistem kao sastavni dio biznisa su: usteda vremena, usteda prostora, reducirani troskovi, pouzdanost i sigurnost. Kompanije koje  ne koriste slican sistem bi se mogle naci u problemima koji su upravo suprotnost navedeni beneficija kao sto su veliki troskovi, potreba za osiguravanjem prostora velike povrsine na kojem bi se mogla eksponirati vozila, naravno dolazi i do bespotrebne potrosnje vremena. S naglaskom na navedene beneficije i nedostatke u slucaju da se kompanija odluci da ne osigura novi nacin poslovanja kao sto je RACS, vjerujemo da je ovaj sistem pravo rjesenje.




## Procesi

**Rezervacija**

Sistem prvo omogucuva klijentu da se registruje za rezervaciju. Dalje, nakon uspjesne registracije korisnik dobiva username i password, te ima priliku da vidi detelja opisa za odredeno vozilo. Prilikom rezervacije vozila koje nije dostupno korisnik se obavjestava i nudi mu se izbor slicni vozila. Sistem pruza korisniku opciju pretrazivanja vozila po specificnim kriterijima. Nakon sto korisnik izabere zeljeno vozilo pojavljuje se dijalog za upis broja kartice, tek kad korisnik unese vazecu kreditnu karticu sistem mu pruza jedinstveni broj narudbe pomocu kojeg kasnije mjenja navedenu rezervaciju po zelji, kao naprimjer ako zeli povecati broj dana rezervacije. Korisnik nakon uspjesne rezervacije dobiva poruku na broj mobitela koji je upisao prilikom registracije. Sistem ce omoguciti osoblju da vrsi update informacija vezanih za rezervaciju. Na kraju ostaje opcija da korisnik pomocu jedinstvenog broja otkaze rezervaciju.



**Prijava**

Sistem dozvoljava menaderu i osoblju prijavu na sistem koristeci username i password. Nakon uspjesne prijave sistem pruza odredene opcije u zavisnosti da li se prijavio menader ili zaposlenik. Omogucena je i opcija promjene lozinke kako za menadera tako i za osoblje. Nakon zavrsenih duznosti na sistemu osoblje i menader se odjavljuju sa sistema pomocu opcije odjavi se.



**Vozila**

Na pocetku osoblje registruje vozila koja su u ponudi. Za vec postojeca vozila osoblje mjenja informacije po zelji. Omogucena je i pretraga po specificnim opcijama kao sto su broj predjeni kilometara. Menader nabavlja nova vozila i sklapa ugovore s auto-kompanijama. Nakon update ili kreiranja novog vozila osoblje/menader moze napustiti prostor za rad s vozilima uz pomoc opcije izlaz.



**Rentanje**

Prilikom rentanja osoblje registrira klijenta u listu rezervacija. Ako bude potrebe osoblje moze promjeniti informacije o klijentu poslije rezervacije. Ako je klijent vec rento vozilo u datoj kompaniji to ce biti zabiljezeno u njegovom zapisu kao poeni koji se akumuliraju u zvjezdice ( max 5 zvjezdica) pri cemu svako dodatna zvjezdica daje veci popust na rezervaciju. Poslije uspjesne rezervacije osoblje dobiva osobni rezime rezervacije koja ce mu kasnije donijeti potencijalnu povisicu na platu, sto vise rezervacija to je veca sansa da zaposleni dobije povisicu (sistem na principu get paid for referrals). 




## Funkcionalnosti


- Opcija prijave za osoblje i menadera

- Opcija regisstracije klijenta

- Menader ima opcije pregleda, dodavanja, promjene, brisanja, snimanja detalja o osoblju

- Osoblje ima opcije pregleda, dodavanja, promjene, brisanja, snimanja detalja o vozilima

- Osoblje upravalja detaljima klijenata pomocu zapisi o rezervaciji

- Klijenti mogu mjenjati vlastite podatke

- Osoblje moze dobiti dnevni, sedmicni i mjesecne izvjestaj o vozilima

- Klijentu je omoguceno da izabere vozilo i napravi rezervaciju

- Opcija obaveznog snimanja pomocu puta koji klijent bude presao s vozilom da bi se u slucaju stete ili kazne sankcionise klijent u vidu dodatne naplate

- Servis koji pruza informacije i loada vozila na osnovu rijeci pretrage

- Obezbjeden gps sistem radi pracenja vozila

- Prilikom uspjesne rezervacije korisniku se salje message na mobilni uredaj

- Opcija VIP pomocu koje korisnik iznajmljuje VIP vozilo uz osobnog vozaca






## Akteri


1. Korisnik usluga je osoba koja ima mogućnost iznajmljivanja i rezervacije vozila 
2. Uposlenik/Osoblje je osoba koja radi za firmu Rent-a-car i radi na poslovima iznajmljivanja, rezervacije, naplaćivanja i izdavanja vozila
3. Supervizor/Menader - Supervizor ima zadatak da nadgleda primopredaju vozila, nabavlja vozila, te vrši manipulaciju nad podacima o osoblju
4. Vozač - Vozač ima zadatak da po želji klijenta vrši usluge vožnje po unaprijed određenim rutama




 



 


