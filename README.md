# PWManager
det er min password manager, jeg har desværrer ikke fået min "frontend" til at virke, har haft problemer med at få min console til at printe som jeg havde lyst og havde mange problemer med at få encryption til at fungere så havde mindre tid til at kigge på min frontend, men alle systemer brude virke som det skulle.

# Iden bag min frontend
skriver lige hvordan jeg havde planer om at få det til at virke

nå du åbner programmet ved at køre det gennem visual studio, så er din første promt om du har lavet et masterpassword, ja/nej spørgsmål, masterpassword er salted & hashed og gemt, masterpassword er hashed & salted med Argon2id, hvis du har lavet et masterpassword skriver du dit masterpassword og der efter får du 2 muligheder

- Opret ny username, password og navn på der du vil gemme login til
- Se dine oprettet passwords

passwords vil blive gemt i database med AES encryption og i console vil de blive vist i plain text, masterpassword vil være det som låser dine passwords op.
