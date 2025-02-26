﻿document.getElementById("login-form").addEventListener("submit", async function (e) {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password })
    });

    const data = await response.json();

    if (response.ok) {
        localStorage.setItem("token", data.token);

        const payload = JSON.parse(atob(data.token.split('.')[1]));
        const userRole = payload["UserRole"];

        if (userRole === "ITEmployee") {
            window.location.href = "it-panel.html";
        } else {
            alert("Yetkisiz giriş!");
        }
    } else {
        document.getElementById("error-msg").classList.remove("d-none");
    }
});
