let cart = [
    {
        nombre: 'Camisa de Jean',
        color: 'blue',
        talla: 'M',
        precio: 17.99,
        cantidad: 1,
        imagen: 'https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Vertical/12a.webp'
    },
    {
        nombre: 'Buzo de Algodon',
        color: 'red',
        talla: 'M',
        precio: 35.99,
        cantidad: 1,
        imagen: 'https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Vertical/13a.webp'
    },
    {
        nombre: 'Buzo de Algodon',
        color: 'red',
        talla: 'M',
        precio: 35.99,
        cantidad: 1,
        imagen: 'https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Vertical/13a.webp'
    },
    {
        nombre: 'Buzo de Algodon',
        color: 'red',
        talla: 'M',
        precio: 35.99,
        cantidad: 1,
        imagen: 'https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Vertical/13a.webp'
    },
    {
        nombre: 'Buzo de Algodon',
        color: 'red',
        talla: 'M',
        precio: 35.99,
        cantidad: 1,
        imagen: 'https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Vertical/13a.webp'
    }
];

function renderCart() {
    const cartItems = document.getElementById('cart-items');
    const cartCount = document.getElementById('cart-count');
    const subtotal = document.getElementById('subtotal');
    const total = document.getElementById('total');
    const checkoutBtn = document.getElementById('checkout-btn');

    cartItems.innerHTML = '';
    let totalItems = 0;
    let sum = 0;

    if (cart.length === 0) {
        cartItems.innerHTML =
            '<div class="cart-item"><p>Carrito vacío</p></div>';
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
    renderCart();
}

function restar(index) {
    if (cart[index].cantidad > 1) {
        cart[index].cantidad--;
    } else {
        cart.splice(index, 1);
    }
    renderCart();
}

function eliminar(index) {
    cart.splice(index, 1);
    renderCart();
}

function updateCartCount(count) {
    const badge = document.getElementById('cart-count-badge');
    if (!badge) return;

    if (count === 0) {
        badge.style.display = 'none';
    } else {
        badge.style.display = 'inline-block';
        badge.textContent = count;
    }
}


document.getElementById('cart-icon').addEventListener('click', () => {
    document.getElementById('cart-slide').classList.add('open');
    document.getElementById('cart-slide').classList.remove('hidden');
    renderCart();
});

document.getElementById('close-cart').addEventListener('click', () => {
    document.getElementById('cart-slide').classList.remove('open');
});