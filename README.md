# MongoDB Demo - Blog

## Overview

The project was created for personal development purpose to settle and improve knowledge about MongoDB and NoSQL databases in general.

The main goal was to dive deeper into practical use of MongoDB. Because of that, the project was not and will not be production-ready.

The architecture of the application was Command Query Separation - the favorite and most common architecture used by the author.

The Data layer (in this case MongoDB) of the project was separated from others layers by the Repository Pattern.

## Achieved Goals
- Get hands on experience with MongoDB CLI
- Get hands on experience with MongoDB .NET Driver
- Configure MongoDB via .NET Driver
- Implement basic CRUD operations
- Implement pagination - `GET /api/authors`, `GET api/posts`
- Implement search - `GET /api/authors`, `GET api/posts`
- Implement One-To-Zero-Or-One relationship in NoSQL database - `Author <-> Post`
- Implement One-To-Many relationship - `Post <-> Comments`
- Implement strongly typed queries
- Add indexes to the MongoDB for faster search - `Author`'s `FullNameUpperCased` and `Post`'s `TitleUpperCased`. Indexes was upper-cased in order to make search case-insensitive.
- Establish per-request session with MongoDB

## Technology stack
- ASP.NET Core 3.1
- MongoDB

## Features (Endpoints)
Swagger auto-generated documentation

<img src="https://i.ibb.co/f96XzGT/blog-api-doc.png" width="500px" alt="Swagger documentation"></img>