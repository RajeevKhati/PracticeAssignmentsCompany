require('dotenv').config();

const express = require('express');
const app = express();
const cors = require('cors');
app.use(
    cors({
        origin: "http://localhost:4200"
    })
);

const sequelize = require("./database/connection");
const result = require("./models/Result");

//importing routes
const resultApiRoute = require("./routes/result");

app.use(express.json());

//testing the connection
(async function () {
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
app.use('/api/results', resultApiRoute);


app.listen(process.env.PORT, () => console.log(`Server is listening on port ${process.env.PORT}...`));