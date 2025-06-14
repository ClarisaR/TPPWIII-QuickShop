    // Modal de registro
    const openModalBtn = document.getElementById('openRegisterModal');
    const modal = document.getElementById('registerModal');
    const closeModalBtn = document.getElementById('closeModal');

        openModalBtn.addEventListener('click', () => {
        modal.style.display = 'block';
        });

        closeModalBtn.addEventListener('click', () => {
        modal.style.display = 'none';
        });

        window.addEventListener('click', (e) => {
            if (e.target == modal) {
        modal.style.display = 'none';
            }
        });

    // Modal de inicio de sesión
    const openLoginModal = document.getElementById('openLoginModal');
    const loginModal = document.getElementById('loginModal');
    const closeLoginModal = document.getElementById('closeLoginModal');

        openLoginModal.addEventListener('click', () => {
        loginModal.style.display = 'block';
        });

        closeLoginModal.addEventListener('click', () => {
        loginModal.style.display = 'none';
        });

        window.addEventListener('click', (e) => {
            if (e.target == loginModal) {
        loginModal.style.display = 'none';
            }
        });