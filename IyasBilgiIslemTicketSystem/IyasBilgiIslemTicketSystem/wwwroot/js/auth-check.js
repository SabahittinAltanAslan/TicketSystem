function checkAuthorization(requiredRole) {
    const token = localStorage.getItem("token");
    if (!token) {
        alert("Lütfen önce giriş yapın!");
        window.location.href = "index.html";
        return;
    }

    const payload = JSON.parse(atob(token.split('.')[1]));
    const userRole = payload["UserRole"];

    if (userRole !== requiredRole) {
        alert("Bu sayfaya erişim yetkiniz yok!");
        window.location.href = "index.html";
    }
}
