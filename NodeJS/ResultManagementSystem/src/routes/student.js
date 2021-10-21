const express = require('express');
const router = express.Router();

const Result = require("../models/Result");

//get page where student will input his details to find their result
router.get('/results/find', (req, res) => {
    res.render("student/findResult", {flash:false});
});

//handling post request when student tries to search their result
router.post('/results/find', async (req, res) => {
    try{
        const result = await Result.findOne({
            where:{
                rollNumber: req.body.rollNumber,
                dateOfBirth: new Date(req.body.dateOfBirth)
            }
        });
        if(result===null){
            res.render("student/findResult", {flash:true, errorMsg:"Please enter correct Roll Number and Date of Birth"});
        }
        res.render("student/resultDetails", {result: result});
    }
    catch(error){
        console.error(error);
        res.redirect("/");
    }
});

module.exports = router;