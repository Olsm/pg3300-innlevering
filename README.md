# Readme for PG3300 Innlevering #

Dokumenter redigeres på google docs og oppdateres i repository som oppgavenavn.pdf i tilhørende mappe.

### What is this repository for? ###

* Dette repository er til innlevering i faget PG3300 Programvarearkitektur.
* Vi skal refaktorere SnakeMess.cs, forklare multithreading begreper, og lage spillet The Cookie Bakery som en multithreaded applikasjon.

### How do I get set up? ###

* Prosjektet bruker git
* En god git tutorial finnes her: https://www.atlassian.com/git/tutorials/
* Jeg vil anbefale programmet SourceTree: https://www.sourcetreeapp.com/download
* Åpne terminal (i sourcetree klikk actions - open in terminal)
* Skriv inn default epost og navn/brukernavn
* Clon repository til din pc.
* For å laste ned endringer fra serveren gjør du pull.
* For å oppdatere på serveren gjør du push.

### Contribution guidelines ###

* Opprett "issue" på bitbucket for oppgaver, bugs, forslag til forbedringer og liknende.
* Master branch skal alltid være en fungerende versjon av spillet, test før du oppdaterer.
* Skriv dokumentasjon på google docs. Last opp som pdf og oppdater dokumentet i repository
* Vi skal i utgangspunktet følge centralized branch workflow: https://www.atlassian.com/git/tutorials/comparing-workflows/centralized-workflow
* Dersom vi skal jobbe samtidig, kan feature branch workflow brukes: https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow
* Centralized branch workflow:
    * Klon repository og lagre lokalt på pcen
    * Gjør commit etter endringer men ikke push
    * Når du er ferdig med endringene for denne feature/issue, push til master.
* Feature branch workflow:
    * Lag ny branch ved arbeid på den "feature" du jobber på, slik at flere kan jobbe samtidig eller du kan jobbe med noe uten være redd for å ødelegge master.
    * Når du er ferdig med endingen og testet at spillet fungerer tar du merge for å koble branchen sammen med master igjen.

### Who do I talk to? ###

* Vi kan chatte på facebook, eller møtes på skole eller hos hverandre.
* Opprett issue hvis du finner bugs eller har forslag til endringer/forbedringer
* Du kan kommentere endringer i hver enkelt commit, også inline kommentarer