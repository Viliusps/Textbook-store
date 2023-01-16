# Knygų Kirminai

Čia pateikiamas šioks toks quickstart'as. Projekto eigoje jis gali
būti papildomas.

## Išankstiniai reikalavimai

Projekte bus dirbama su C# (.NET 6) backend dalei sukurti ir Vue.JS
karkasas frontend'ui. Vue.JS šiuo metu sukonfiguruotas darbus su
typescript kalba, siekiant išvengi įkyrių su tipais susijusių
klaidų, kurios pasitaiko dirbant su javascript'u, tačiau šią
konfiguraciją galima gan lengvai ir pakeisti.

Prieš pradedant darbą reikia turėt įsiinstaliavus
['Docker'](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?utm_source=docker&utm_medium=webreferral&utm_campaign=dd-smartbutton&utm_location=module)
['NodeJS'](https://nodejs.org/en/download/) ir
['.NET 6'](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Žemiau pateiktos naudojimo instrukcijos naudoja šių įrankių
konsolės sąsajas, bet viską galimą atlikti ir per grafines sąsajas.

Kodo redagavimo priemonės nėra itin svarbios. Rekomenduojamas
['VSCode'](https://code.visualstudio.com), bet esant norui galima
dirbti ir su [notepad++](https://notepad-plus-plus.org/downloads/)
ar [nano](https://www.nano-editor.org/download.php).

## Backend

Norint pasieleist backend'ą pakanka konsolėje paleisti:
```sh
dotnet run
```

Paleidus komandą konsolės lange bus matoma kuriame port'e
galima pasiekti api, formatas: `localhost:{port}/`

Norint ištestuoti api enpoint'us galima naudotis jau instaliuotu
'Swagger' įrankiu, kuris yra pasiekiamas `localhost:{port}/swagger`

## Frontend

Prieš pradedant darbą su frontend'u reikia atsisiųst visus reikiamus
_node_ modulius:
```sh
npm install
```

Frontend'ą galima pasileisti su šia komanda:
```sh
npm run dev
```
Taip bus paleista 'development' aplinka, kurioje kodo pakeitimai
rodomi gyvai.

Prieš kiekvieną commit'ą rekomenduojama pasitikrinti kodą su ESLint'u

```sh
npm run lint
```

## Database

Database aplankale paleidžiame komandą:

``` sh
docker-compose up
```

Norėdami pakartotinai paleisti dockerį, tai galima padaryti su ta pačia komanda arba aktyvinti konteinerį
_Docker Desktop_ programoje.

Per _Docker Desktop_ aplikaciją galima sustabdyti veikiantį konteinerį.


## `git` šakų formatas

Dėl tvarkos rekomenduojamas toks šakų formatas
`{problemos tipas}/{Jira ID}`

Sakykim dirbama su feature'u, kurio id Jir'oje yra 'KK-12',
šakos pavadinimas turėtų atrodyti taip: `feature/KK-12`
