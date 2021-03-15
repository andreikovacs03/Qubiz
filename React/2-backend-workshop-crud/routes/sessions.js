(function () {
    'use strict'

    var sessions = [
        { id: 0, votes: 0, title: "Introduction to Ionic", speaker: "CHRISTOPHE COENRAETS", time: "9:40am", room: "Ballroom A", description: "In this session, you'll learn how to build a native-like mobile application using the Ionic Framework, AngularJS, and Cordova." },
        { id: 1, votes: 0, title: "ReactJS in 50 Minutes", speaker: "LISA SMITH", time: "10:10am", room: "Ballroom B", description: "In this session, you'll learn everything you need to know to start building next-gen JavaScript applications using AngularJS." },
        { id: 2, votes: 0, title: "Contributing to Apache Cordova", speaker: "JOHN SMITH", time: "11:10am", room: "Ballroom A", description: "In this session, John will tell you all you need to know to start contributing to Apache Cordova and become an Open Source Rock Star." },
        { id: 3, votes: 0, title: "Mobile Performance Techniques", speaker: "JESSICA WONG", time: "3:10Pm", room: "Ballroom B", description: "In this session, you will learn performance techniques to speed up your mobile application." },
        { id: 4, votes: 0, title: "Building Modular Applications", speaker: "LAURA TAYLOR", time: "2:00pm", room: "Ballroom A", description: "Join Laura to learn different approaches to build modular JavaScript applications." }
    ];

    //GET
    exports.findAll = function (req, res, next) {
        res.send(sessions);
    };

    exports.findById = function (req, res, next) {
        var index = indexOf(req.params.id);

        if (index >= 0 && index < sessions.length) {
            res.send(sessions[index]);
        } else {
            res.json(false);
        }
    };

    // POST
    exports.addSession = function (req, res) {
        if (req.headers['access-token'] == 'AccessToken') {
            var item = req.body;
            item.id = sessions[sessions.length - 1].id + 1;
            sessions.push(req.body);
            res.json(req.body);
        }
        else
            res.status(401).json(false);
    };

    // PUT
    exports.editSession = function (req, res) {
        if (req.headers['access-token'] == 'AccessToken') {
            var index = indexOf(req.params.id);

            if (index >= 0 && index < sessions.length) {
                sessions[index] = req.body;
                res.json(true);
            } else {
                res.json(false);
            }
        }
        else
            res.status(401).json(false);
    };

    // DELETE
    exports.deleteSession = function (req, res, next) {
        if (req.headers['access-token'] == 'AccessToken') {
            var index = indexOf(req.params.id);

            if (index >= 0 && index < sessions.length) {
                sessions.splice(index, 1);
                res.json(true);
            } else {
                res.json(false);
            }
        }
        else
            res.status(401).json(false);
    };

    function indexOf(id) {
        var result = grep(sessions, function (e) { return e.id == id; });
        if (result.length == 0) {
            // not found
            console.log("Item not found!")
            return -1;
        } else if (result.length == 1) {
            // access the foo property using result[0].foo
            return sessions.indexOf(result[0]);
        } else {
            // multiple items found
            console.log("Multiple items found!");
            return -1;
        }
    }

    function grep(items, callback) {
        var filtered = [],
            len = items.length,
            i = 0;
        for (i; i < len; i++) {
            var item = items[i];
            var cond = callback(item);
            if (cond) {
                filtered.push(item);
            }
        }
        return filtered;
    };
})()