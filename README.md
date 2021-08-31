# MovieService

A movie microservice. Used asp.net core, web api, aspects, caching, loging.

The documentation page is /swagger/index.html
You have to get token firstly in /api/Login/gettoken
There are 2 type users.
OnlyRead:
{
  "userName": "URead",
  "password": "123"
}

WriteAndRead:
{
  "userName": "UWrite",
  "password": "321"
}

Category
  [POST] /api/Category/Add
    Request:
      { "id": 0, "name": "string" }
    Response:
      { "success": true, "message": null }
    
  [GET]  /api/Category/GetById
    Request:
      Id - integer
    Response:
      { "data": { "id": 1, "name": "Category 1" }, "success": true, "message": null }
    
  [GET]  /api/Category/List
    Response:
      { "data": {}, "success": false, "message": "Yetkili kullanıcı değil!" }
  
  [POST] /api/Category/Update
    Request:
      { "id": 0, "name": "string" }
    Response:
      { "success": true, "message": null }
    
  [POST] /api/Category/Delete
    Request:
      { "id": 0, "name": "string" }
    Response:
      { "success": true, "message": null }


Movie
  [POST] /api/Movie/Add
    Request:
      { "id": 0, "name": "string", "picture": "string", "detail": "string", "imdb": "string", "year": 0, "categoryId": 0, "types": [ "string" ], "medias": [ "string" ] }
    Response:
      { "success": true, "message": null }
  [GET]  /api/Movie/GetById
    Request:
      Id - integer
    Response:
      { "data": { "id": 1, "name": "Film 1", "picture": "/Images/1.png", "detail": "Detail 1", "imdb": "1", "year": 2001, "categoryId": 1, "types": [ "Type 1" ], "medias": [ "/Files/1.mgep" ] }, "success": true, "message": null }
    
  [GET]  /api/Movie/GetByCategoryId
    Request:
      Id - integer
    Response:
      { "data": {}, "success": false, "message": "Yetkili kullanıcı değil!" }
    
  [GET]  /api/Movie/List
    Response:
      { "data": {}, "success": false, "message": "Yetkili kullanıcı değil!" }
  
  [POST] /api/Movie/Update
    Request:
      { "id": 0, "name": "string", "picture": "string", "detail": "string", "imdb": "string", "year": 0, "categoryId": 0, "types": [ "string" ], "medias": [ "string" ] }
    Response:
      { "success": true, "message": null }
    
  [POST] /api/Movie/Delete
    Request:
      { "id": 0, "name": "string", "picture": "string", "detail": "string", "imdb": "string", "year": 0, "categoryId": 0, "types": [ "string" ], "medias": [ "string" ] }
    Response:
      { "success": true, "message": null }
    
    
    
Schemas

  Category{
    id	integer($int32)
    name	string
  }
  LoginForm{
    userName	string
    nullable: true
    password	string
  }
  Movie{
    id	integer($int32)
    name	string
    picture	string
    detail	string
    imdb	string
    year	integer($int32)
    categoryId	integer($int32)
    types	[string]
    medias	[string]
  }

