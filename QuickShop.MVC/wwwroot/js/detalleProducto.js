document.addEventListener("DOMContentLoaded", () => {
    const btnAgregar = document.getElementById("btn-agregar-carrito");
    if (!btnAgregar) return;

    //agregar model al carrito
    btnAgregar.addEventListener("click", () => {
        const talla = document.getElementById("size").value;
        const color = document.getElementById("color").value;

        if (!talla || !color) {
            alert("Seleccioná talle y color");
            return;
        }

        const existente = cart.find(p => p.nombre === producto.nombre && p.talla === talla && p.color === color);
        if (existente) {
            existente.cantidad++;
        } else {
            cart.push({
                idVariante: producto.idVariante,
                nombre: producto.nombre,
                imagen: producto.imagen,
                precio: producto.precio,
                talla,
                color,
                cantidad: 1
            });

        }

        renderCart();
    });
});
