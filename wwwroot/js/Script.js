var map = L.map('map').
    setView([18.568155, -68.660057],
        10);

L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery ©️ <a href="http://cloudmade.com">CloudMade</a>',
    maxZoom: 30
}).addTo(map);
L.control.scale().addTo(map);



map.on("click", (e) => {
    let LatLng = map.mouseEventToLatLng(e.originalEvent);
    console.log(LatLng.lat, LatLng.lng);
    let lng = document.getElementById("lng");
    let lat = document.getElementById("lat");

    lat.value = LatLng.lat;
    lng.value = LatLng.lng;
});