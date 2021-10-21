# Result Management System

This project lets you manage Results of an Exam.

There are two sections:-
- A Teacher can Create, Read, Update and Delete a Result.
- A Student can only view result using their name and roll number.


## Environment Variables

To run this project, you will need to add the following environment variables to your .env file

`DATABASE_NAME`

`DOMAIN`

`USERNAME`

`PASSWORD`

Domain is needed if you're using windows authentication in the sql server.
To configure for different database server visit
https://sequelize.org/master/manual/dialect-specific-things.html


## Run Locally

Clone the project

Go to the project directory

```bash
  cd ResultManagementSystem
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run start
```


## Tech Stack

**Client:** ejs, CSS, Bootstrap, Javascript

**Server:** Node, Express

**Database:** Sql Server

**ORM:** Sequelize

  