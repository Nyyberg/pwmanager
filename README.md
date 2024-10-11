# PWManager
Detter er PWManager som kan holde styr på alle dine passwords for dig! :D

Det er simpelt og let at bruge, kom og lad mig vise dig!!

# Hvordan bruger man PWManager?

nå du åbner programmet ved at køre det gennem visual studio, som vist her!
https://cdn.discordapp.com/attachments/940898320233164820/1294408886471757855/image.png?ex=670ae7b7&is=67099637&hm=e7b2b2de6102da0fd3e3efbaea057a26e2a7a672a94ab5ec365e8114226de706&

Du bliver så promted til at oprette et masterpassword:
https://cdn.discordapp.com/attachments/940898320233164820/1294409243687911575/image.png?ex=670ae80c&is=6709968c&hm=5e87676a4b88d71f0106042d76785b0b400e807a36253abff29dafbf01ffc482&

Efter du har oprettet dit masterpassword and du så logge ind og du får så to muligheder som vist her:
https://cdn.discordapp.com/attachments/940898320233164820/1294409360528773282/image.png?ex=670ae828&is=670996a8&hm=80fb6eb4be67cb87e8043036bfc1bf066f1a7246767391ad006726bae8b5de81&
- Se dine passwords
- Opret et nyt password med disse variabler så du kan holde styr på hvilket password er til hvad
  - Et Navn
  - Dit Username
  - Dit Password
passwords vil blive gemt i database med AES encryption og i console vil de blive vist i plain text, masterpassword vil være det som låser dine passwords op.

# Security i PWManager

PWManager er beskyttet på den måde at 1. det hele er lokalt, og den skal ikke have adgang til noget som helst gennem nettet
Dit Masterpassword er så hashed og salted når det skal opbevares i databasen, så selv hvis nogen fik fat på din pc og åbnede .db filen ville de ikke kunne se hvad dit masterpassword er!
Og ud over det er dine forskellige logins Encrypted med AES256 så dine passwords er stored sikkert i din database.

# Pitfalls
nogle ting der kan være irriterende er jo selvfølgelig at det ikke står selvstændigt og du skal åbne det gennem Visual Studio, og alt koden står der, så hvis nogen fik fat på din pc, kunne de slette selve databasen og så ville de login gå tabt, de ville ikke kunne få adgang til dem, men selve databasen er skrøblig og kan blive slettet ret nemt.
