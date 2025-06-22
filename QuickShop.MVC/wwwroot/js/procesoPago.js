const radioButtons = document.querySelectorAll('input[name="FormaEntrega"]');
const cards = document.querySelectorAll('.card');
const envioElement = document.getElementById('precioEnvio');
const totalElement = document.getElementById('total');
const productoPrecio = parseInt(document.getElementById('precioProducto').innerText.replace(/\D/g, ''));

radioButtons.forEach((radio, index) => {
    radio.addEventListener('change', () => {
        cards.forEach(card => card.classList.remove('selected'));
        cards[index].classList.add('selected');

        const envioPrecio = parseInt(cards[index].querySelector('.precioEntrega').dataset.precio);
        envioElement.textContent = `$ ${envioPrecio.toLocaleString("es-AR")}`;
        totalElement.textContent = `$ ${(productoPrecio + envioPrecio).toLocaleString("es-AR")}`;
    });
});