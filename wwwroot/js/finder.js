"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/finderHub").build();

document.getElementById("searchLocation").disabled = true;

connection.start().then(function () {
    console.log("Online")
    document.getElementById("searchLocation").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});



document.getElementById("searchLocation").addEventListener("click",function (event) {
    let licensePlate = document.getElementById("licensePlate").value;

    console.log("clicked");
    
    connection.invoke("SendLocation", licensePlate).catch((err) => {
        return console.log(err.toString());
    })
    
    event.preventDefault();
})

connection.on("RecieveLocation", function (licensePlate, latitude, longitude) {
    let ul = document.getElementById("locationList");
    let liCount = ul.getElementsByTagName('li').length;
    
    let locationList = document.createElement("li");
    if(licensePlate === document.getElementById("licensePlate").value) {
        locationList.textContent = `${licensePlate} : ${latitude}, ${longitude}`;
        document.getElementById("locationList").appendChild(locationList);
    }

    if(liCount >= 10) {
        ul.removeChild(ul.firstChild);
    }

})
