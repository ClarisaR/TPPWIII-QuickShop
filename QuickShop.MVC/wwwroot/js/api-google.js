let mapa;

function initMap() {
    const ubicacion = { lat: direccionLat, lng: direccionLng };

    mapa = new google.maps.Map(document.getElementById("map"), {
        zoom: 16,
        center: ubicacion
    });

    new google.maps.Marker({
        position: ubicacion,
        map: mapa,
        title: direccionNombre
    });
}

const modal = document.getElementById('mapModal');

modal.addEventListener('shown.bs.modal', function () {
    setTimeout(() => {
        initMap();
    }, 100);
});