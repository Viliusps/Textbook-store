# Duomenų bazė

Nudojama PostgreSql reliacinė duomenų bazė.
Duombazė implementuota naudojantis ['Docker'](www.docker.com).
Norint pasileist duomenų bazę reikės pačio ['Docker įrankio'](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?utm_source=docker&utm_medium=webreferral&utm_campaign=dd-smartbutton&utm_location=module)

## Paleidimas

Database aplankale paleidžiame komandą:

``` sh
docker-compose up
```

Norėdami pakartotinai paleisti dockerį, tai galima padaryti su ta pačia komanda arba aktyvinti konteinerį
_Docker Desktop_ programoje.

Per _Docker Desktop_ aplikaciją galima sustabdyti veikiantį konteinerį.

## Prisijungimas

Duomenų bazė paleidžiama lokaliame adrese `localhost:5432`.

Vartotojo vardas: `kirminai`, slaptažodis: `kk`, duomenų bazės pavadinimas: `postgres`.

Įrankis, su kuriuo jungiamasi prie duomenų bazės, nėra svarbus.
