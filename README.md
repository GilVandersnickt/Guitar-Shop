# Guitar shop

## Project
De guitar shop is een webshop die producten aanbiedt omtrent gitaren.
De administator kan producten, categorieën en merken toevoegen, aanpassen en verwijderen.

## Extra info
Informatie om het
project te kunnen uitvoeren:

- Logingegevens

  | Username                   | Password    |
  | -------------------------- | ----------- |
  | Admin@guitarshop.com       | Test123?    |
  | SuperAdmin@guitarshop.com  | Test123?    |
  
- Api instellingen

Base uri voor het instellen van ipadress is te vinden in de klasse ApiSettings.cs in de folder Constants in elk project

## Rollen

- Een **administrator** zou producten, merken, categorieën, subcategorieën en gebruikers kunnen toevoegen, editeren en verwijderen.
- Een **gebruiker** heeft toegang tot het bekijken van alle producten, categorieën en merken. Een gebruiker kan zich registreren of inloggen.

## Database structuur

### ERD schema

![Imgur](https://i.imgur.com/ozbgFju.png)

## Api Endpoints
### Brands
Methode | Endpoint | Beschrijving | Request | Response
--------|----------|--------------|---------|---------
GET | /api/Brands | Geef een lijst van merken | Niets | Collectie van brands
POST | /api/Brands | Voeg een merk toe | Brand | Brand
PUT | /api/Brands | Bewerk de gegevens van een merk | Brand | Niets
GET | /api/Brands/{id} | Geen de details van een merk op basis van id | Niets | Brands met opgegeven id
DEL | /api/Brands/{id} | Verwijder een merk | Niets | Niets
GET | /api/Brands/{id}/products | Geef een lijst van producten van een merk | Niets | Collectie van products
GET | /api/Brands/{id}/categories | Geef een lijst van categorieën van een merk | Niets | Collectie van categories
POST | /api/Brands/{id}/image | Voeg een afbeelding toe aan een merk | Brand | Brand
PUT | /api/Brands/{id}/image | Bewerk een afbeelding van een merk | Afbeelding | Niets
GET | /api/Brands/search | Merk op basis van zoekterm | Niets | Collectie van brands met opgegeven zoekterm
### Categories
Methode | Endpoint | Beschrijving | Request | Response
--------|----------|--------------|---------|---------
GET | /api/Categories | Geef een lijst van categorieën | Niets | Collectie van categorieën
POST | /api/Categories | Voeg een categorie toe | Category | Category
PUT | /api/Categories | Bewerk de gegevens van een categorie | Category | Niets
GET | /api/Categories/{id} | Geen de details van een categorie op basis van id | Niets | Category met opgegeven id
DEL | /api/Categories/{id} | Verwijder een categorie | Niets | Niets
GET | /api/Categories/{id}/products | Geef een lijst van producten van een categorie | Niets | Collectie van categories
GET | /api/Categories/{id}/brands | Geef een lijst van merken van een categorie | Niets | Collectie van brands
GET | /api/Categories/{id}/subcategories | Geef een lijst van subcategorieën van een categorie | Niets | Collectie van subcategories
POST | /api/Categories/{id}/image | Voeg een afbeelding toe aan een categorie | Category | Category
PUT | /api/Categories/{id}/image | Bewerk een afbeelding van een categorie | Afbeelding | Niets
GET | /api/Categories/search | Categorie op basis van zoekterm | Niets | Collectie van categories met opgegeven zoekterm
### Products
Methode | Endpoint | Beschrijving | Request | Response
--------|----------|--------------|---------|---------
GET | /api/Products | Geef een lijst van producten | Niets | Collectie van products
POST | /api/Products | Voeg een product toe | Product | Product
PUT | /api/Products | Bewerk de gegevens van een product | Product | Niets
GET | /api/Products/{id} | Geen de details van product op basis van id | Niets | Product met opgegeven id
DEL | /api/Products/id | Verwijder een product | Niets | Niets
POST | /api/Products/{id}/image | Voeg een afbeelding toe aan een product | Product | Product
PUT | /api/Products/{id}/image | Bewerk een afbeelding van een product | Afbeelding | Niets
GET | /api/Products/search | Product op basis van zoekterm | Niets | Collectie van products met opgegeven zoekterm
### Subcategories
Methode | Endpoint | Beschrijving | Request | Response
--------|----------|--------------|---------|---------
GET | /api/Subcategories | Geef een lijst van subcategorieën | Niets | Collectie van subcategories
POST | /api/Subcategories | Voeg een subcategorie toe | Subcategory | subcategory
PUT | /api/Subcategories | Bewerk de gegevens van een subcategorie | Subcategory | Niets
GET | /api/Subcategories/{id} | Geen de details van een subcategorie op basis van id | Niets | subcategorie met opgegeven id
DEL | /api/Subcategories/{id} | Verwijder een subcategorie | Niets | Niets
GET | /api/Subcategories/{id}/products | Geef een lijst van producten van een subcategorie | Niets | Collectie van subcategories
GET | /api/Subcategories/{id}/brands | Geef een lijst van merken van een subcategorie | Niets | Collectie van brands
GET | /api/Subcategorie/search | Subcategorie op basis van zoekterm | Niets | Collectie van subcategories met opgegeven zoekterm
