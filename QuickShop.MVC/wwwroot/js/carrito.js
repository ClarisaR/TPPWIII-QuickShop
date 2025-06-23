// Inicializar carrito desde localStorage
let cart = [];
try {
    const storedCart = localStorage.getItem("cart");
    cart = storedCart ? JSON.parse(storedCart) : [];
    localStorage.setItem("cart", JSON.stringify(cart));
} catch (e) {
    console.error("Error al leer el carrito:", e);
    cart = [];
    localStorage.setItem("cart", JSON.stringify(cart));
}

function guardarCarrito() {
    localStorage.setItem("cart", JSON.stringify(cart));
}

function renderCart() {
    const cartItems = document.getElementById('cart-items');
    const cartCount = document.getElementById('cart-count');
    const subtotal = document.getElementById('subtotal');
    const total = document.getElementById('total');
    const checkoutBtn = document.getElementById('checkout-btn');

    if (!cartItems || !cartCount || !subtotal || !total || !checkoutBtn) return;

    cartItems.innerHTML = '';
    let totalItems = 0;
    let sum = 0;

    if (cart.length === 0) {
        cartItems.innerHTML = '<div class="cart-item"><p>Carrito vacío</p></div>';
        checkoutBtn.disabled = true;
        cartCount.innerText = 0;
        subtotal.innerText = '0.00';
        total.innerText = '0.00';
        updateCartCount(0);
        return;
    }

    cart.forEach((item, index) => {
        totalItems += item.cantidad;
        sum += item.precio * item.cantidad;

        const div = document.createElement('div');
        div.className = 'cart-item';
        div.innerHTML = `
            <img src="${item.imagen}" alt="${item.nombre}">
            <div class="item-info">
                <strong>${item.nombre}</strong><br>
                Color: ${item.color}<br>
                Talle: ${item.talla}<br>
                $${item.precio.toFixed(2)}
                <div class="qty-controls">
                    <button onclick="restar(${index})">-</button>
                    <span>${item.cantidad}</span>
                    <button onclick="sumar(${index})">+</button>
                </div>
            </div>
            <div class="item-actions">
                <button onclick="eliminar(${index})">🗑️</button>
            </div>
        `;
        cartItems.appendChild(div);
    });

    cartCount.innerText = totalItems;
    subtotal.innerText = sum.toFixed(2);
    total.innerText = sum.toFixed(2);
    checkoutBtn.disabled = false;
    updateCartCount(totalItems);
}

function sumar(index) {
    cart[index].cantidad++;
    guardarCarrito();
    renderCart();
}

function restar(index) {
    if (cart[index].cantidad > 1) {
        cart[index].cantidad--;
    } else {
        cart.splice(index, 1);
    }
    guardarCarrito();
    renderCart();
}

function eliminar(index) {
    cart.splice(index, 1);
    guardarCarrito();
    renderCart();
}

function updateCartCount(count) {
    const badge = document.getElementById('cart-count-badge');
    if (!badge) return;

    badge.style.display = count === 0 ? 'none' : 'inline-block';
    badge.textContent = count;
}

// Eventos
document.addEventListener('DOMContentLoaded', () => {
    updateCartCount(cart.reduce((total, item) => total + item.cantidad, 0));
    renderCart();

    const cartIcon = document.getElementById('cart-icon');
    const cartSlide = document.getElementById('cart-slide');
    const closeCart = document.getElementById('close-cart');

    if (cartIcon && cartSlide) {
        cartIcon.addEventListener('click', () => {
            cartSlide.classList.add('open');
            cartSlide.classList.remove('hidden');
            renderCart();
        });
    }

    if (closeCart && cartSlide) {
        closeCart.addEventListener('click', () => {
            cartSlide.classList.remove('open');
        });
    }

    const checkoutBtn = document.getElementById('checkout-btn');
    if (checkoutBtn) {
        checkoutBtn.addEventListener('click', async () => {
            const cart = JSON.parse(localStorage.getItem('cart')) || [];

            if (cart.length === 0) {
                alert("El carrito está vacío.");
                return;
            }

            if (!cart.every(item => item.idVariante)) {
                alert("Hay productos sin variante válida.");
                return;
            }

            checkoutBtn.disabled = true;
            checkoutBtn.innerText = "Procesando...";

            const pedido = {
                productos: cart.map(item => ({
                    idVariante: item.idVariante,
                    cantidad: item.cantidad,
                    precioUnitario: item.precio
                }))
            };

            try {
                const res = await fetch('/Pedido/CrearPedido', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(pedido)
                });

                if (res.ok) {
                    const data = await res.json();
                    if (data.success && data.pedidoId) {
                        localStorage.removeItem('cart');
                        window.location.href = `/Pedido/VerPedido/${data.pedidoId}`;
                    } else {
                        alert("El pedido fue creado, pero no se pudo obtener el ID.");
                    }
                }
                else {
                    alert("Error al confirmar el pedido.");
                    checkoutBtn.disabled = false;
                    checkoutBtn.innerText = "CONFIRMAR COMPRA";
                }
            } catch (error) {
                console.error("Error al enviar el pedido:", error);
                alert("Hubo un problema con la red.");
                checkoutBtn.disabled = false;
                checkoutBtn.innerText = "CONFIRMAR COMPRA";
            }
        });
    }
});
