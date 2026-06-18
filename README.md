# Chór Akademicki Universitas Musicae - Choir App
Aplikacja webowa stworzona w architekturze **MVC (Model-View-Controller)**, pełniąca funkcję interaktywnej wizytówki dla chóru akademickiego oraz zaawansowanego systemu zarządzania treścią i członkami zespołu (Backend/Panel Administracyjny).

## Technologie i Architektura

Projekt został zrealizowany w oparciu o nowoczesny stos technologiczny, zapewniający bezpieczeństwo, responsywność i wysoką wydajność:

* **Backend:** C#, ASP.NET Core MVC
* **Baza danych:** Microsoft SQL Server, Entity Framework Core (Code-First)
* **Frontend:** HTML5 semantyczny, CSS3, JavaScript, framework **Bootstrap 5** (RWD)
* **Autoryzacja:** ASP.NET Core Identity (zarządzanie rolami i sesjami)
* **Kontrola wersji:** Git / GitHub

## Główne funkcjonalności

Aplikacja jest podzielona na strefę publiczną oraz zabezpieczone panele dla określonych ról użytkowników:

### Warstwa Prezentacji (Frontend)
* **Responsywny interfejs (RWD):** Przystosowany do urządzeń mobilnych układ oparty na Flexbox/Grid (Bootstrap).
* **Dynamiczna Galeria:** Przegląd zdjęć z koncertów i wydarzeń.
* **Kalendarz Wydarzeń:** Podgląd nadchodzących prób i koncertów.
* **Baza Wiedzy (FAQ):** Sekcja z najczęściej zadawanymi pytaniami.

### Panel Administracyjny (CMS) i Logika Serwerowa
* **Zarządzanie treścią (CRUD):** Pełna edycja ogłoszeń, wpisów FAQ oraz wydarzeń bezpośrednio z panelu.
* **Zarządzanie Użytkownikami i Rolami:** Autentykacja i autoryzacja z podziałem na administratorów (Zarząd/Dyrygent) oraz zwykłych użytkowników.
* **Moduł Chórzysty (Dashboard):** Dedykowany, kafelkowy panel dla zalogowanych członków chóru, integrujący ich kluczowe dane.
* **Zaawansowane relacje bazodanowe (Wiele-do-wielu):** System subskrypcji pozwalający chórzystom obserwować wybrane wydarzenia.
* **Zarządzanie plikami:** Mechanizm uploadu i udostępniania materiałów (np. nut w formacie PDF) z bazy danych dla chórzystów.

---

## Instrukcja uruchomienia lokalnego

Aby uruchomić aplikację w środowisku lokalnym, postępuj zgodnie z poniższymi krokami:

### Wymagania wstępne
* Zainstalowane środowisko **Visual Studio** (rekomendowana wersja 2022).
* Zainstalowany **.NET SDK**.
* Lokalny serwer bazy danych **SQL Server** (np. LocalDB wbudowany w Visual Studio).

### Kroki uruchomienia
1. **Sklonuj repozytorium:**
   Pobierz projekt na swój dysk za pomocą terminala lub interfejsu Visual Studio

2. Otwórz projekt:
Uruchom plik rozwiązania choir_app.sln w środowisku Visual Studio.

3. Zaktualizuj bazę danych (Migracje):
Otwórz Konsolę Menedżera Pakietów (Package Manager Console) w Visual Studio (Narzędzia -> Menedżer pakietów NuGet -> Konsola menedżera pakietów) i wykonaj poniższe polecenie w celu wygenerowania struktury bazy danych:

Update-Database

4. Uruchom aplikację:
Wciśnij przycisk Uruchom (zielona strzałka na górnym pasku, profil choir_app) lub klawisz F5. Aplikacja automatycznie otworzy się w domyślnej przeglądarce internetowej.

Autorzy
Natalia Maj
Michał Król 
Dominika Kraj
Magda Kluszczyńska
