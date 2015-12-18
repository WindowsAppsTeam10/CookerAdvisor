## Users: ##

- POST /api/Account/Register - Register a user
- GET /token - Logs in user.

## Cookbooks: ##

- GET  /api/cookbooks/{userEmail} - Get user favourties
- POST /api/cookbooks - Add recipe to favourites
- DELETE /api/cookbooks - Remove recipe to favourites

## Recipes: ##

- GET /api/recipes - Supports skip and take. Gets recipes.
- POST /api/recipes - Add new recipe.
- PUT /api/recipes - Update recipe.
- DELETE /api/recipes/{id} - Delete recipe by id.
