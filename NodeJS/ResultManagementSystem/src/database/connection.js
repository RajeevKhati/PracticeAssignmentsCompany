const Sequelize = require('sequelize');

const sequelize = new Sequelize(process.env.DATABASE_NAME, null, null, {
    dialect: 'mssql',
    dialectOptions: {
      authentication: {
        type: 'ntlm',
        options: {
          domain: process.env.DOMAIN,
          userName: process.env.USERNAME,
          password: process.env.PASSWORD
        }
      },
      options: {
        instanceName: 'MSSQLSERVER'
      }
    }
});

module.exports = sequelize;