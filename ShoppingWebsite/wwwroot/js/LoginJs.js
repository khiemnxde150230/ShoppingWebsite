"use strict";

const showPass = document.querySelector(".toggle-password");
const passField = document.getElementById("password-field");

showPass.addEventListener("click", function () {
    this.classList.toggle("fa-eye-slash");
    const type = passField.getAttribute("type") === "password" ? "text" : "password";
    passField.setAttribute("type", type);
})
