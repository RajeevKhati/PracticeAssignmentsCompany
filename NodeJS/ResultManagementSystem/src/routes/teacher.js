const express = require('express');
const router = express.Router();

const Result = require("../models/Result");

//get all results page
router.get('/results', async (req, res) => {
    try{
        const allResults = await Result.findAll();
        res.render("teacher/allResults", {allResults});
    }
    catch(error){
        console.error(error);
        res.render("teacher/allResults");
    }
});

//get 'add new result' form page
router.get('/results/new', (req, res) => {
    res.render("teacher/newResult", {flash: false});
});

//post route handling 'new result'
router.post('/results', async (req, res) => {
    
    try{

        //check if user has entered the already existing roll number
        const resultByRollNumber = await Result.findOne({
            where:{
                rollNumber: req.body.rollNumber
            }
        });

        //if yes then sending error msg to 'new result' page as a flash message
        if(resultByRollNumber !== null){
            res.render("teacher/newResult", {flash:true, errorMsg:"Specified roll number already exists"});
        }

        const newResult = await Result.create({
                                rollNumber: req.body.rollNumber,
                                name: req.body.name,
                                dateOfBirth: new Date(req.body.dateOfBirth),
                                score: req.body.score
                            });
    }
    catch(error){
        console.error(error);
        res.redirect("/");
    }
    res.redirect('/teacher/results');
});

//get edit result form page
router.get("/results/:id/edit", async (req, res)=>{
    try{
        const resultById = await Result.findOne({
                                where:{
                                    id: req.params.id
                                }
                            });
        res.render("teacher/editResult", {result: resultById, flash:false});
    }catch(error){
        console.error(error);
        res.redirect('/');
    }
    
});

//post edited result
router.put("/results/:id", async (req, res) => {
    req.body.id = req.params.id;
    try{
        //check if user has changed the roll number
        const resultById = await Result.findOne({
            where:{
                id: req.params.id
            }
        });
        if(resultById.rollNumber !== Number(req.body.rollNumber)){
            //if yes then check if same roll number exists in db
            const resultByRollNumber = await Result.findOne({
                                            where:{
                                                rollNumber: req.body.rollNumber
                                            }
                                        });
            //if yes then send error
            if(resultByRollNumber !== null){
                //sending error msg to edit page as a flash message
                res.render("teacher/editResult", {result: req.body, flash:true, errorMsg:"Specified roll number already exists"});
            }
        }
        //if user has not changed the roll number or changed roll number does not exist in db, then simply update the current entry
        const updatedResult = await Result.update(req.body, {
            where: {
                id: req.params.id
            }
        });

        res.redirect('/teacher/results');
    }
    catch(error){
        console.error(error);
        res.redirect("/");
    }
});

//delete result
router.delete("/results/:id", async (req, res) => {
    try{
        const deletedResult = await Result.destroy({
                                    where: {
                                    id: req.params.id
                                    }
                                });
        res.redirect('/teacher/results');
    }
    catch(error){
        console.error(error);
        res.redirect('/');
    }
});

module.exports = router;