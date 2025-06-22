document.addEventListener("DOMContentLoaded", function () {
    // Carrusel Uno
    const container1 = document.querySelector(".cards-container.carruselUno");
    const leftBtn1 = document.querySelector(".arrow.left.uno");
    const rightBtn1 = document.querySelector(".arrow.right.uno");
    // Carrusel Dos
    const container2 = document.querySelector(".cards-container.carruselDos");
    const leftBtn2 = document.querySelector(".arrow.left.dos");
    const rightBtn2 = document.querySelector(".arrow.right.dos");
    // Carrusel Tres
    const container3 = document.querySelector(".cards-container.carruselTres");
    const leftBtn3 = document.querySelector(".arrow.left.tres");
    const rightBtn3 = document.querySelector(".arrow.right.tres");
    // Carrusel Cuatro
    const container4 = document.querySelector(".cards-container.carruselCuatro");
    const leftBtn4 = document.querySelector(".arrow.left.cuatro");
    const rightBtn4 = document.querySelector(".arrow.right.cuatro");
    // Carrusel Cinco
    const container5 = document.querySelector(".cards-container.carruselCinco");
    const leftBtn5 = document.querySelector(".arrow.left.cinco");
    const rightBtn5 = document.querySelector(".arrow.right.cinco");

    const scrollAmount = 280; // Cantidad de desplazamiento

    leftBtn1.addEventListener("click", () => {
        container1.scrollBy({
            left: -scrollAmount,
            behavior: "smooth"
        });
    });
    rightBtn1.addEventListener("click", () => {
        container1.scrollBy({
            left: scrollAmount,
            behavior: "smooth"
        });
    });

    leftBtn2.addEventListener("click", () => {
        container2.scrollBy({
            left: -scrollAmount,
            behavior: "smooth"
        });
    });
    rightBtn2.addEventListener("click", () => {
        container2.scrollBy({
            left: scrollAmount,
            behavior: "smooth"
        });
    });

    leftBtn3.addEventListener("click", () => {
        container3.scrollBy({
            left: -scrollAmount,
            behavior: "smooth"
        });
    });
    rightBtn3.addEventListener("click", () => {
        container3.scrollBy({
            left: scrollAmount,
            behavior: "smooth"
        });
    });

    leftBtn4.addEventListener("click", () => {
        container4.scrollBy({
            left: -scrollAmount,
            behavior: "smooth"
        });
    });
    rightBtn4.addEventListener("click", () => {
        container4.scrollBy({
            left: scrollAmount,
            behavior: "smooth"
        });
    });

    leftBtn5.addEventListener("click", () => {
        container5.scrollBy({
            left: -scrollAmount,
            behavior: "smooth"
        });
    });
    rightBtn5.addEventListener("click", () => {
        container5.scrollBy({
            left: scrollAmount,
            behavior: "smooth"
        });
    });
});