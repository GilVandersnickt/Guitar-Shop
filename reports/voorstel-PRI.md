# Guitar Shop

## Project

Voor de module **Programming Integration** zou ik een webshop willen maken die allerlei producten verkoopt omtrent gitaren.  

- Een gebruiker zou kunnen registreren/inloggen.
- Een gebruiker zou een winkelmandje kunnen gebruiken.
- De producten kunnen gefilterd worden op basis van de categorie, subcategorie, het merk of zoekwoord.
- De gefilterde producten worden weergegeven in een lijst voorzien van paginatie.

## Rollen

- Een **administrator** zou producten, merken, categorieën, subcategorieën en leden kunnen toevoegen, editeren en verwijderen.
- Een **gebruiker** zou toegang hebben tot een winkelmandje waarin die producten zou kunnen toevoegen, editeren en verwijderen. Ook kan een gebruiker zich registreren of inloggen.

## Database structuur

### Entiteiten

- Een **product** bevat: 
    - Een merk (Fender, Marshall, Yamaha, etc ...)
    - Een categorie (Gitaren, versterkers, snaren, etc ...)
    - Een subcategorie (Elektrische gitaren, buizenversterkers, nylonsnaren, etc ...)
&nbsp;  
&nbsp; 
- Een **merk** bevat: 
    - Meerdere producten
    - Meerdere categorieën
    - Meerdere subcategorieën
&nbsp;  
&nbsp;
- Een **categorie** bevat:
    - Meerdere producten
    - Meerdere subcategorieën
    - Meerdere merken
&nbsp;  
&nbsp;
- Een **subcategorie** bevat:
    - Een categorie
    - Meerdere producten
    - Meerdere merken

### ERD schema

![Imgur](https://i.imgur.com/ozbgFju.png)

