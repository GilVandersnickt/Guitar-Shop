# Guitar Shop

## Project

Voor de module **Programming Integration** zou ik een webshop willen maken die allerlei producten verkoopt omtrent gitaren.  

- Een administrator zou beheer hebben over de gebruikers, producten, categorieën, subcategorieën en merken.
- Een gebruiker zou zich kunnen registreren of inloggen.
- Een gebruiker zou een winkelmandje kunnen gebruiken.
- De producten kunnen gefilterd worden op basis van de categorie, subcategorie, het merk of zoekwoord.
- De gefilterde producten worden weergegeven in een lijst voorzien van paginatie.

## Rollen

- Een **administrator** zou producten, merken, categorieën, subcategorieën en gebruikers kunnen toevoegen, editeren en verwijderen.
- Een **gebruiker** zou toegang hebben tot een winkelmandje waarin die producten zou kunnen toevoegen, editeren en verwijderen. Ook zou een gebruiker zich kunnen registreren of kunnen inloggen.

## Endpoints

### Products
- GET /api/products
- GET /api/products/id
- GET /api/categories/id/products
- GET /api/subcategories/id/products
- GET /api/brands/id/products
- POST /api/products
- PUT /api/products
- DELETE /api/products/id

### Brands
- GET /api/brands
- GET /api/brands/id
- POST /api/brands
- PUT /api/brands
- DELETE /api/brands/id

### Categories
- GET /api/categories
- GET /api/categories/id
- POST /api/categories
- PUT /api/categories
- DELETE /api/categories/id

### Subcategories
- GET /api/subcategories
- GET /api/subcategories/id
- GET /api/categories/id/subcategories
- POST /api/subcategories
- PUT /api/subcategories
- DELETE /api/subcategories/id

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

