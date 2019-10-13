# Rate Exchange App
Aplikacja webowa napisana w C#/.net z wykorzystaniem entity framwework i  Microsoft SQL Server. Pobiera dane z api NBP (http://api.nbp.pl) i udostępnia 3 funkcjonalności w postaci zapytań GET w REST api:

##### 1. Lista dostępnych walut na których można wykonać przeliczenia
Zwraca wszystkie 3 literowe kody waluty zgodne z ISO 4217 (https://pl.wikipedia.org/wiki/ISO_4217), które są obsługiwane przez aplikację.
Można to przetestować używając komendy:
http://localhost:xxxxx/api/Exchange/Currencies

##### 2. Przeliczenie na podstawie kursu wymiany dla następujących parametrów: kwota, z jakiej waluty, do jakiej waluty
Można to przetestować używając komendy:
http://localhost:xxxxx/api/Exchange?value=number&currencyFrom=value1&currencyTo=value2
gdzie:
- value1 i value2 są to trzyliterowe kody waluty zgodne z ISO 4217 (np, USD,EUR)
- Number to ilość waluty którą chcemy wymienić. Może to być dowolna liczba zmiennoprzecinkowa (np 23.56).

Przykładowo:
http://localhost:xxxxx/api/Exchange?value=134.56&currencyFrom=USD&currencyTo=EUR
Zamienia 134.56 dolarów amerykańskich na walutę Euro. Wynikiem jest liczba euro po przeliczeniu.

##### 3. Udostępnienie aktualnych kursów dla listy walut
Zwraca wszystkie kursy walut które udostępnia NBP.
Można to przetestować używając komendy:
http://localhost:xxxxx/api/Exchange/Rates

Dodatkowo aplikacja loguje informacje o przeliczonych elementach do bazy danych mssql do której można podać namiary w web.config. Bazę można utworzyć za pomocą skryptu sql znajdującego się w repozytorium o nazwie "LogDB.sql".
