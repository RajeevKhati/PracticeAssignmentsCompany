const express = require("express");
const router = express.Router();

const Result = require("../models/Result");

//get results
router.get("/", async (req, res) => {
    try {
        if (Object.keys(req.query).length == 0) {
            const allResults = await Result.findAll();
            res
                .status(200)
                .json({ success: true, data: allResults, message: "Results Fetched" });
        } else {
            const result = await Result.findOne({
                where: {
                    rollNumber: req.query.rollNumber,
                    dateOfBirth: new Date(req.query.dateOfBirth),
                },
            });
            if (result === null) {
                res.status(400).json({
                    success: false,
                    message: "Please enter correct Roll Number and Date of Birth",
                });
            }
            res
                .status(200)
                .json({ success: true, data: result, message: "Result Found" });
        }
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

//post result
router.post("/", async (req, res) => {
    try {
        //check if user has entered the already existing roll number
        const resultByRollNumber = await Result.findOne({
            where: {
                rollNumber: req.body.rollNumber,
            },
        });

        //if yes then sending error msg to 'new result' page as a flash message
        if (resultByRollNumber !== null) {
            res.status(400).json({
                success: false,
                message: "Specified roll number already exist",
            });
        }

        const newResult = await Result.create({
            rollNumber: req.body.rollNumber,
            name: req.body.name,
            dateOfBirth: new Date(req.body.dateOfBirth),
            score: req.body.score,
        });

        res.status(200).json({
            success: true,
            data: newResult,
            message: "Result successfully added",
        });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

//get result by id
router.get("/:id", async (req, res) => {
    try {
        const resultById = await Result.findOne({
            where: {
                id: req.params.id,
            },
        });
        if (resultById === null) {
            res.status(400).json({ success: false, message: "No Result Found." });
        }
        res.status(200).json({
            success: true,
            data: resultById,
            message: "Result successfully Found",
        });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

//edit result
router.put("/:id", async (req, res) => {
    try {
        //check if user has changed the roll number
        const resultById = await Result.findOne({
            where: {
                id: req.params.id,
            },
        });

        if (resultById.rollNumber !== Number(req.body.rollNumber)) {
            //if user has changed the roll number, then check if same roll number exists in db
            const resultByRollNumber = await Result.findOne({
                where: {
                    rollNumber: req.body.rollNumber,
                },
            });
            //if same roll number exists in db, then send error
            if (resultByRollNumber !== null) {
                //sending error msg to edit page as a flash message
                res.status(400).json({
                    success: false,
                    message: "Altered roll number already exist",
                });
            }
        }
        //if user has not changed the roll number or changed roll number does not exist in db, then simply update the current entry
        const updatedResult = await Result.update(req.body, {
            where: {
                id: req.params.id,
            },
        });

        res.status(200).json({
            success: true,
            data: updatedResult,
            message: "Result successfully updated",
        });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

//delete result
router.delete("/:id", async (req, res) => {
    try {
        const deletedResult = await Result.destroy({
            where: {
                id: req.params.id,
            },
        });
        res.status(200).json({
            success: true,
            data: deletedResult,
            message: "Result successfully deleted",
        });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

module.exports = router;
