# PWManager
Detter er PWManager som kan holde styr på alle dine passwords for dig! :D

Det er simpelt og let at bruge, kom og lad mig vise dig!!

# Hvordan bruger man PWManager?

nå du åbner programmet ved at køre det gennem visual studio, som vist her!

![image](https://github.com/user-attachments/assets/77cb39ac-e5da-4d91-8b2b-855c04e638c9)


Du bliver så promted til at oprette et masterpassword:

![image](https://github.com/user-attachments/assets/d51f639f-1651-4e14-bd41-d256047513f3)


Efter du har oprettet dit masterpassword and du så logge ind og du får så to muligheder som vist her:

![image](https://github.com/user-attachments/assets/14b6ac1b-4a9c-411c-a0dc-0e4869d45a3f)

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
