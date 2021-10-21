const express = require('express');
const router = express.Router();

//get home page
router.get('/', (req, res) => {
    res.render("home", {hide:true});
});

module.exports = router;