const express = require('express');
const app = express();

require('dotenv').config();

const ejs = require('ejs');

const sequelize = require("./src/database/connection");
const result = require("./src/models/Result");

const methodOverride = require('method-override');

//importing routes
const homeRoute = require('./src/routes/home');
const teacherRoute = require('./src/routes/teacher');
const studentRoute = require('./src/routes/student');

//Static files
app.use(express.static('./public'));

//this enables ejs to send requests like PUT, DELETE
app.use(methodOverride('_method'));

//Templating engine
app.set('views','./src/views');
app.set('view engine', 'ejs');

//Parses data coming from form.
app.use(express.urlencoded({extended: false}));
app.use(express.json());


//testing the connection
(async function() {
try {
    await sequelize.authenticate();
    console.log('Connection has been established successfully.');
  } catch (error) {
    console.error('Unable to connect to the database:', error);
  }
}());

//setting up database
sequelize
.sync()
.then((result) => {
    console.log("sync successful...");
})
.catch((err) => {
    console.log(err);
});


//configuring routes
app.use(homeRoute);
app.use('/teacher', teacherRoute);
app.use('/student', studentRoute);

app.listen("3000", ()=>console.log("Listening on port 3000..."));