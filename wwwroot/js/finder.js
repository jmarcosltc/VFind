"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/finderHub").build();

connection.start().then(function () {
    console.log("Online")
    connection.invoke("SendLocation").catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

/*
connection.on("RecieveLocation", function (licensePlate, latitude, longitude) {
    let ul = document.getElementById("locationList");
    let liCount = ul.getElementsByTagName('li').length;

    let locationList = document.createElement("li");

    locationList.textContent = `${licensePlate} : ${latitude}, ${longitude}`;

    if(liCount >= 10) {
        ul.removeChild(ul.firstChild);
    }

    document.getElementById("locationList").appendChild(locationList);
})
*/
