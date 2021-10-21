const {Sequelize, DataTypes} = require("sequelize");
const sequelize = require("../database/connection");

const Result = sequelize.define("Result", {
    id:{
        type: DataTypes.INTEGER,
        autoIncrement: true,
        allowNull: false,
        primaryKey: true
    },
    rollNumber:{
        type: DataTypes.INTEGER,
        allowNull: false,
        unique: true
    },
    name:{
        type: DataTypes.STRING,
        allowNull: false
    },
    dateOfBirth:{
        type: DataTypes.DATEONLY,
        allowNull: false
    },
    score:{
        type: DataTypes.INTEGER,
        allowNull: false
    }
});

module.exports = Result;