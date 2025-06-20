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

    const scrollAmount = 350; // Cantidad de desplazamiento

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
});